using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using FTN.Common;
using FTN.ServiceContracts;
using System.Collections;

namespace ClientUI
{
    public class TestGda : IDisposable
    {

        public ModelResourcesDesc modelResourcesDesc = new ModelResourcesDesc();

         /*private Dictionary<DMSType, List<ModelCode>> _DMSType_Reference = new Dictionary<DMSType, List<ModelCode>>();
        public Dictionary<DMSType, List<ModelCode>> DMSType_Reference
        {
            get
            {
                return _DMSType_Reference;
            }
            set
            {
                _DMSType_Reference = value;
            }
        }*/

        private NetworkModelGDAProxy gdaQueryProxy = null;
        private NetworkModelGDAProxy GdaQueryProxy
        {
            get
            {
                if (gdaQueryProxy != null)
                {
                    gdaQueryProxy.Abort();
                    gdaQueryProxy = null;
                }

                gdaQueryProxy = new NetworkModelGDAProxy("NetworkModelGDAEndpoint");
                gdaQueryProxy.Open();

                return gdaQueryProxy;
            }
        }

        public TestGda()
        {
        }

        public Dictionary<DMSType, List<ModelCode>> get_DMSType_ModelCodes()
        {
            Dictionary<DMSType, List<ModelCode>> _DMSType_ModelCodes = new Dictionary<DMSType, List<ModelCode>>();

            try //TRY
            {
                foreach (DMSType _DMSType in modelResourcesDesc.AllDMSTypes)
                {
                    if (_DMSType != DMSType.MASK_TYPE)
                        _DMSType_ModelCodes.Add(_DMSType, modelResourcesDesc.GetAllPropertyIds(_DMSType));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("TestGda->get_DMSType_ModelCodes failed:\n\t{0}", e.Message));
                _DMSType_ModelCodes = null;
            }

            return _DMSType_ModelCodes;
        }

        private string GetValuesToString(ResourceDescription rd)
        {
            string text = string.Empty;
            try //TRY
            {
                foreach (Property property in rd.Properties)
                {
                    text += PropertyToString(property, "");
                }                    
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("TestGda->GetValuesToString failed.\n\t{0}", e.Message));
                text = null;
            }

            return text;
        }

        private string GetExtentValuesToString(List<ResourceDescription> rds)
        {
            string text = string.Empty;
            try //TRY
            {
                foreach (ResourceDescription rd in rds)
                {                    
                    text += "Resource_GID: " + "0x" + rd.Id.ToString("X16") + "\n";
                    foreach (Property property in rd.Properties)
                    {
                        text += PropertyToString(property, "\t");
                    }                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("TestGda->GetValuesToString failed.\n\t{0}", e.Message));
                text = null;
            }

            return text;
        }

        private string PropertyToString(Property property, string tab)
        {
            string result = string.Empty;
            try //TRY
            {
                PropertyType propertyType = property.Type;
                if (propertyType == PropertyType.DateTime)
                {
                    result = tab + property.Id + ": " + property.AsDateTime() + "\n";
                }
                else if (propertyType == PropertyType.Enum)
                {
                    EnumDescs enumDescs = new EnumDescs();
                    result = tab + property.Id + ": " + enumDescs.GetStringFromEnum(property.Id, property.AsEnum()) + "\n";
                }
                else if (propertyType == PropertyType.Reference)
                {
                    result = tab + property.Id + ": " + "0x" + ((long)property.GetValue()).ToString("X16") + "\n";
                }
                else if (propertyType == PropertyType.String)
                {
                    if (property.PropertyValue.StringValue == null)
                        property.PropertyValue.StringValue = string.Empty;
                    result = tab + property.Id + ": " + property.AsString() + "\n";
                }
                else if(propertyType == PropertyType.ReferenceVector)
                {
                    result = tab + property.Id + ":\n";
                    foreach (long refGID in (IList)property.GetValue())
                    {
                        result += tab + "\t" + "0x" + refGID.ToString("X16") + "\n";
                    }
                }
                else
                {
                    if (property.Id == ModelCode.IDObject_GID_)
                    {
                        result = tab + property.Id + ": " + "0x" + ((long)property.GetValue()).ToString("X16") + "\n";
                    }
                    else
                    {
                        result = tab + property.Id + ": " + property.GetValue() + "\n";
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("TestGda->PropertyToString failed.\n\t{0}", e.Message));
                result = null;              
            }

            return result;
        }

        #region GDAQueryService

        public string GetValues(long globalId, List<ModelCode> properties)
        {
            Console.WriteLine("Getting values method started.");

            ResourceDescription rd = null;
            try
            {
                rd = GdaQueryProxy.GetValues(globalId, properties);                

                Console.WriteLine("Getting values method successfully finished.");
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Getting values method for entered id = {0} failed.\n\t{1}", globalId, e.Message));             
            }
            
            return GetValuesToString(rd);
        }

        public string GetExtentValues(ModelCode SelectedConcreteClass, List<ModelCode> properties)
        {
            Console.WriteLine("Getting extent values method started.");
            
            int iteratorId, i, resourcesLeft, numberOfResources = 20;
            List<ResourceDescription> rds = new List<ResourceDescription>();
            try
            {                                          
                iteratorId = GdaQueryProxy.GetExtentValues(SelectedConcreteClass, properties);
                resourcesLeft = GdaQueryProxy.IteratorResourcesLeft(iteratorId);
                while (resourcesLeft > 0)
                {                    
                    rds.AddRange(GdaQueryProxy.IteratorNext(numberOfResources, iteratorId));

                    resourcesLeft = GdaQueryProxy.IteratorResourcesLeft(iteratorId);
                }

                GdaQueryProxy.IteratorClose(iteratorId);
                Console.WriteLine("Getting extent values method successfully finished.");
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Getting extent values method failed for {0}.\n\t{1}", SelectedConcreteClass, e.Message));
                rds = null;
            }

            return GetExtentValuesToString(rds);
        }

        public string GetRelatedValues(long sourceGlobalId, List<ModelCode> properties, Association association)
        {            
            Console.WriteLine("Getting related values method started.");            
                     
            int iteratorId, i, resourcesLeft, numberOfResources = 20;
            List<ResourceDescription> rds = new List<ResourceDescription>();
            try
            {
                iteratorId = GdaQueryProxy.GetRelatedValues(sourceGlobalId, properties, association);
                resourcesLeft = GdaQueryProxy.IteratorResourcesLeft(iteratorId);
                while (resourcesLeft > 0)
                {
                    rds.AddRange(GdaQueryProxy.IteratorNext(numberOfResources, iteratorId));

                    resourcesLeft = GdaQueryProxy.IteratorResourcesLeft(iteratorId);
                }

                GdaQueryProxy.IteratorClose(iteratorId);
                
                Console.WriteLine("Getting related values method successfully finished.");                
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Getting related values method  failed for sourceGlobalId = {0} and association (propertyId = {1}, type = {2}). Reason: {3}", sourceGlobalId, association.PropertyId, association.Type, e.Message));
            }

            return GetExtentValuesToString(rds);
        }        

        #endregion GDAQueryService

        /*public Dictionary<string, (long, DMSType)> TestGetExtentValuesAllTypes()
        {            
            Console.WriteLine("Getting extent values for all DMS types started.");
            Dictionary <string, (long, DMSType)> _0xGID_GID_DMSType = new Dictionary<string, (long, DMSType)>();

            List<ModelCode> properties = new List<ModelCode>();
            int iteratorId, resourcesLeft, i, numberOfResources = 20;
            string xGID, result;
            try
            {
                foreach (DMSType type in Enum.GetValues(typeof(DMSType)))
                {
                    if (type == DMSType.MASK_TYPE)
                        continue;

                    _DMSType_Reference.Add(type, new List<ModelCode>());

                    properties = modelResourcesDesc.GetAllPropertyIds(type);                    
                    iteratorId = GdaQueryProxy.GetExtentValues(modelResourcesDesc.GetModelCodeFromType(type), properties);
                    resourcesLeft = GdaQueryProxy.IteratorResourcesLeft(iteratorId);

                    result = string.Format("DMSType <{0}> contains reference ModelCode: ", type);
                    while (resourcesLeft > 0)
                    {
                        List<ResourceDescription> rds = GdaQueryProxy.IteratorNext(numberOfResources, iteratorId);                        
                        
                        foreach (Property property in rds[0].Properties)
                        {
                            if (property.Type == PropertyType.Reference || property.Type == PropertyType.ReferenceVector)
                            {
                                _DMSType_Reference[type].Add(property.Id);
                                result += "\n\t" + property.Id;
                            }                                
                        }                        

                        for (i = 0; i < rds.Count; i++)
                        {
                            xGID = "0x" + rds[i].Id.ToString("X16");
                            _0xGID_GID_DMSType.Add(xGID, (rds[i].Id, type));                            
                            Console.WriteLine(string.Format("Resource_GID <{0}>--><{1}>, DMSType <{2}>.", _0xGID_GID_DMSType[xGID].Item1, xGID, _0xGID_GID_DMSType[xGID].Item2));
                        }
                        
                        resourcesLeft = GdaQueryProxy.IteratorResourcesLeft(iteratorId);
                        
                    }
                    
                    GdaQueryProxy.IteratorClose(iteratorId);
                    Console.WriteLine(result);
                }
                
                Console.WriteLine("Getting extent values for all DMS types successfully ended.");
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Getting extent values for all DMS types failed:\n\t{0}", e.Message));
                _0xGID_GID_DMSType = null;
            }

            return _0xGID_GID_DMSType;
        }*/

        public void TestGetExtentValuesAllTypes(ref Dictionary<string, (long, DMSType)> _strGID__GID_DMSType, ref Dictionary<DMSType, List<ModelCode>> _DMSType_Reference)
        {
            Console.WriteLine("Getting extent values for ALL DMS types started.");            

            List<ModelCode> properties = new List<ModelCode>();
            List<ResourceDescription> rds = new List<ResourceDescription>();
            int iteratorId, resourcesLeft, i, numberOfResources = 20;
            long GID;
            string strGID, traceLog;            
            try
            {
                foreach (DMSType type in Enum.GetValues(typeof(DMSType)))
                {
                    if (type == DMSType.MASK_TYPE)
                        continue;

                    _DMSType_Reference.Add(type, new List<ModelCode>());

                    properties = modelResourcesDesc.GetAllPropertyIds(type);
                    iteratorId = GdaQueryProxy.GetExtentValues(modelResourcesDesc.GetModelCodeFromType(type), properties);
                    resourcesLeft = GdaQueryProxy.IteratorResourcesLeft(iteratorId);

                    traceLog = "DMSType <" + type + "> contains references in ModelCode:";
                    while (resourcesLeft > 0)
                    {
                        rds = GdaQueryProxy.IteratorNext(numberOfResources, iteratorId);

                        foreach (Property property in rds[0].Properties)
                        {
                            if (property.Type == PropertyType.Reference || property.Type == PropertyType.ReferenceVector)
                            {
                                _DMSType_Reference[type].Add(property.Id);
                                traceLog += "\n\t" + property.Id;
                            }
                        }

                        for (i = 0; i < rds.Count; i++)
                        {
                            GID = rds[i].Id;
                            strGID = "0x" + GID.ToString("X16");
                            _strGID__GID_DMSType.Add(strGID, (GID, type));
                            Console.WriteLine(string.Format("Resource_GID <{0}>--><{1}>, DMSType <{2}>.", GID, strGID, type));
                        }

                        resourcesLeft = GdaQueryProxy.IteratorResourcesLeft(iteratorId);
                    }

                    GdaQueryProxy.IteratorClose(iteratorId);
                    Console.WriteLine(traceLog);
                }

                Console.WriteLine("Getting extent values for ALL DMS types successfully ended.");
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Getting extent values for ALL DMS types failed:\n\t{0}", e.Message));
                _DMSType_Reference = null;
                _strGID__GID_DMSType = null;
            }            
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
