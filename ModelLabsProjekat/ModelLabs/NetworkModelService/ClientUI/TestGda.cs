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

        private ModelResourcesDesc modelResourcesDesc = new ModelResourcesDesc();

        private Dictionary<DMSType, List<ModelCode>> _DMSType_Reference = new Dictionary<DMSType, List<ModelCode>>();
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
        }

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
            Dictionary<DMSType, List<ModelCode>> DMSType_ModelCodes = new Dictionary<DMSType, List<ModelCode>>();            

            try //TRY
            {                    
                foreach (DMSType _DMSType in modelResourcesDesc.AllDMSTypes)
                {
                    if (_DMSType != DMSType.MASK_TYPE)                    
                        DMSType_ModelCodes.Add(_DMSType, modelResourcesDesc.GetAllPropertyIds(_DMSType));                    
                }                
            }
            catch (Exception e)
            {       
                Console.WriteLine(string.Format("TestGda->get_DMSType_ModelCodes failed:\n\t{0}", e.Message));
                DMSType_ModelCodes = null;
            }

            return DMSType_ModelCodes;
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

        #region Test Methods

        public Dictionary<string, (long, DMSType)> TestGetExtentValuesAllTypes()
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
        }

        #region GDAUpdate Service
        /*
        public UpdateResult TestApplyDeltaInsert()
        {
            string message = "Apply update method started.";
            Console.WriteLine(message);
            CommonTrace.WriteTrace(CommonTrace.TraceInfo, message);


            UpdateResult updateResult = null;

            try
            {
                Dictionary<DMSType, ResourceDescription> updates = CreateResourcesToInsert();
                Delta delta = new Delta();

                foreach (ResourceDescription rd in updates.Values)
                {
                    delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                }

                updateResult = GdaQueryProxy.ApplyUpdate(delta);

                message = "Apply update method finished. \n" + updateResult.ToString();
                Console.WriteLine(message);
                CommonTrace.WriteTrace(CommonTrace.TraceInfo, message);

            }
            catch (Exception ex)
            {
                message = string.Format("Apply update method failed. {0}\n", ex.Message);

                if (updateResult != null)
                {
                    message += updateResult.ToString();
                }

                Console.WriteLine(message);
                CommonTrace.WriteTrace(CommonTrace.TraceError, message);
            }

            return updateResult;
        }

        public UpdateResult TestApplyDeltaUpdate(List<long> gids)
        {
            string message = "Testing apply delta update method started.";
            Console.WriteLine(message);
            CommonTrace.WriteTrace(CommonTrace.TraceInfo, message);

            UpdateResult updateResult = null;

            try
            {
                Dictionary<DMSType, ResourceDescription> updates = CreateResourcesForUpdate(gids);
                Delta delta = new Delta();

                foreach (ResourceDescription rd in updates.Values)
                {
                    delta.AddDeltaOperation(DeltaOpType.Update, rd, true);
                }

                updateResult = GdaQueryProxy.ApplyUpdate(delta);

                message = "Testing apply delta update method finished. \n" + updateResult.ToString();
                Console.WriteLine(message);
                CommonTrace.WriteTrace(CommonTrace.TraceInfo, message);
            }
            catch (Exception ex)
            {
                message = string.Format("Testing apply delta update method failed. {0}\n", ex.Message);

                if (updateResult != null)
                {
                    message += updateResult.ToString();
                }

                Console.WriteLine(message);
                CommonTrace.WriteTrace(CommonTrace.TraceError, message);
            }

            return updateResult;
        }

        public UpdateResult TestApplyDeltaDelete(List<long> gids)
        {
            string message = "Testing apply delta delete method started.";
            Console.WriteLine(message);
            CommonTrace.WriteTrace(CommonTrace.TraceInfo, message);

            UpdateResult updateResult = null;

            try
            {
                Delta delta = new Delta();
                ResourceDescription rd = null;

                foreach (long gid in gids)
                {
                    rd = new ResourceDescription(gid);
                    delta.AddDeltaOperation(DeltaOpType.Delete, rd, true);
                }

                updateResult = GdaQueryProxy.ApplyUpdate(delta);

                message = "Testing apply delta delete method finished. \n" + updateResult.ToString();
                Console.WriteLine(message);
                CommonTrace.WriteTrace(CommonTrace.TraceInfo, message);
            }
            catch (Exception ex)
            {
                message = string.Format("Testing apply delta delete method failed. {0}\n", ex.Message);

                if (updateResult != null)
                {
                    message += updateResult.ToString();
                }

                Console.WriteLine(message);
                CommonTrace.WriteTrace(CommonTrace.TraceError, message);
            }

            return updateResult;
        }

        public UpdateResult TestApplyDeltaInsertUpdateDelete()
        {
            UpdateResult updateResult = null;

            try
            {
                updateResult = TestApplyDeltaInsert();

                if (updateResult != null && updateResult.Result == ResultType.Succeeded)
                {
                    List<long> gids = new List<long>();
                    foreach (KeyValuePair<long, long> kvp in updateResult.GlobalIdPairs)
                    {
                        gids.Add(kvp.Value);
                    }

                    updateResult = TestApplyDeltaUpdate(gids);

                    updateResult = TestApplyDeltaDelete(gids);
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("Test apply delta: Insert - Update - Delete failed.\t{0}", ex.Message);

                if (updateResult != null)
                {
                    message += updateResult.ToString();
                }

                Console.WriteLine(message);
                CommonTrace.WriteTrace(CommonTrace.TraceError, message);
            }

            return updateResult;
        }

        public void TestApplyDeltaInsertUpdate(long modelVersionId)
        {
            UpdateResult updateResult = null;
            try
            {
                updateResult = TestApplyDeltaInsert();

                if (updateResult != null && updateResult.Result == ResultType.Succeeded)
                {
                    List<long> gids = new List<long>();
                    foreach (KeyValuePair<long, long> kvp in updateResult.GlobalIdPairs)
                    {
                        gids.Add(kvp.Value);
                    }

                    updateResult = TestApplyDeltaUpdate(gids);
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("Test apply delta: Insert - Update failed.\t{0}", ex.Message);

                if (updateResult != null)
                {
                    message += updateResult.ToString();
                }

                Console.WriteLine(message);
                CommonTrace.WriteTrace(CommonTrace.TraceError, message);
            }
        }

        private Dictionary<DMSType, ResourceDescription> CreateResourcesToInsert()
        {
            long globalId = 0;
            ResourceDescription rd = null;
            List<ModelCode> propertyIDs = null;
            Dictionary<DMSType, ResourceDescription> updates = new Dictionary<DMSType, ResourceDescription>(new DMSTypeComparer());

            #region Create resources

            foreach (DMSType type in modelResourcesDesc.AllDMSTypes)
            {
                if (type != DMSType.MASK_TYPE)
                {
                    globalId = ModelCodeHelper.CreateGlobalId(0, (short)type, -1);
                    propertyIDs = modelResourcesDesc.GetAllPropertyIds(modelResourcesDesc.GetModelCodeFromType(type));
                    rd = new ResourceDescription(globalId);

                    foreach (ModelCode propertyId in propertyIDs)
                    {
                        if (!modelResourcesDesc.NotSettablePropertyIds.Contains(propertyId))
                        {
                            switch (Property.GetPropertyType(propertyId))
                            {
                                case PropertyType.Bool:
                                    rd.AddProperty(new Property(propertyId, true));
                                    break;

                                case PropertyType.Byte:
                                    rd.AddProperty(new Property(propertyId, (byte)100));
                                    break;

                                case PropertyType.Int32:
                                    rd.AddProperty(new Property(propertyId, (int)4));
                                    break;

                                case PropertyType.Int64:
                                case PropertyType.TimeSpan:
                                case PropertyType.DateTime:
                                    rd.AddProperty(new Property(propertyId, (long)101));
                                    break;

                                case PropertyType.Enum:
                                    rd.AddProperty(new Property(propertyId, (short)1));
                                    break;

                                case PropertyType.Reference:
                                    rd.AddProperty(new Property(propertyId));
                                    break;

                                case PropertyType.Float:
                                    rd.AddProperty(new Property(propertyId, (float)10.5));
                                    break;

                                case PropertyType.String:
                                    rd.AddProperty(new Property(propertyId, "TestString"));
                                    break;

                                case PropertyType.Int64Vector:
                                    List<long> longVector = new List<long>();
                                    longVector.Add((long)10);
                                    longVector.Add((long)11);
                                    longVector.Add((long)12);
                                    longVector.Add((long)13);
                                    longVector.Add((long)14);
                                    longVector.Add((long)15);
                                    rd.AddProperty(new Property(propertyId, longVector));
                                    break;

                                case PropertyType.FloatVector:
                                    List<float> floatVector = new List<float>();
                                    floatVector.Add((float)11.1);
                                    floatVector.Add((float)12.2);
                                    floatVector.Add((float)13.3);
                                    floatVector.Add((float)14.4);
                                    floatVector.Add((float)15.5);
                                    rd.AddProperty(new Property(propertyId, floatVector));
                                    break;

                                case PropertyType.EnumVector:
                                    List<short> enumVector = new List<short>();
                                    enumVector.Add((short)1);
                                    enumVector.Add((short)2);
                                    enumVector.Add((short)3);
                                    rd.AddProperty(new Property(propertyId, enumVector));
                                    break;

                                case PropertyType.StringVector:
                                    List<string> stringVector = new List<string>();
                                    stringVector.Add("TestString1");
                                    stringVector.Add("TestString2");
                                    stringVector.Add("TestString3");
                                    stringVector.Add("TestString4");
                                    rd.AddProperty(new Property(propertyId, stringVector));
                                    break;

                                case PropertyType.Int32Vector:
                                    List<int> intVector = new List<int>();
                                    intVector.Add(11);
                                    intVector.Add(12);
                                    intVector.Add(13);
                                    intVector.Add(14);
                                    rd.AddProperty(new Property(propertyId, intVector));
                                    break;

                                default:
                                    break;
                            }
                        }
                    }

                    updates[type] = rd;
                }
            }

            #endregion Create resources

            #region Set references

            //SetPowerTransformerReferences(updates);
            //SetTransformerWindingReferences(updates);
            //SetWindingTestRefernces(updates);

            #endregion Set references

            return updates;
        }

        private Dictionary<DMSType, ResourceDescription> CreateResourcesForUpdate(List<long> gids)
        {
            Dictionary<DMSType, ResourceDescription> updates = new Dictionary<DMSType, ResourceDescription>(new DMSTypeComparer());
            Delta delta = new Delta();

            ResourceDescription rd = null;
            List<ModelCode> propertyIDs = null;
            DMSType type;

            #region Creating resources

            foreach (long gid in gids)
            {
                type = (DMSType)ModelCodeHelper.ExtractTypeFromGlobalId(gid);
                propertyIDs = modelResourcesDesc.GetAllPropertyIds(modelResourcesDesc.GetModelCodeFromType(type));
                rd = new ResourceDescription(gid);

                foreach (ModelCode propertyId in propertyIDs)
                {
                    if (!modelResourcesDesc.NotSettablePropertyIds.Contains(propertyId))
                    {
                        switch (Property.GetPropertyType(propertyId))
                        {
                            case PropertyType.Bool:
                                rd.AddProperty(new Property(propertyId, true));
                                break;

                            case PropertyType.Byte:
                                rd.AddProperty(new Property(propertyId, (byte)7));
                                break;

                            case PropertyType.Int32:
                                rd.AddProperty(new Property(propertyId, (int)500));
                                break;

                            case PropertyType.Int64:
                            case PropertyType.TimeSpan:
                            case PropertyType.DateTime:
                                rd.AddProperty(new Property(propertyId, (long)3112));
                                break;

                            case PropertyType.Enum:
                                rd.AddProperty(new Property(propertyId, (short)2));
                                break;

                            case PropertyType.Reference:
                                rd.AddProperty(new Property(propertyId, (long)0));
                                break;

                            case PropertyType.Float:
                                rd.AddProperty(new Property(propertyId, (float)1.05));
                                break;

                            case PropertyType.String:
                                rd.AddProperty(new Property(propertyId, "UpdateString"));
                                break;

                            case PropertyType.Int64Vector:
                                List<long> longVector = new List<long>();
                                longVector.Add((long)20);
                                longVector.Add((long)21);
                                longVector.Add((long)22);
                                longVector.Add((long)23);
                                longVector.Add((long)24);
                                longVector.Add((long)25);
                                rd.AddProperty(new Property(propertyId, longVector));
                                break;

                            case PropertyType.FloatVector:
                                List<float> floatVector = new List<float>();
                                floatVector.Add((float)21.1);
                                floatVector.Add((float)22.2);
                                floatVector.Add((float)23.3);
                                floatVector.Add((float)24.4);
                                floatVector.Add((float)25.5);
                                rd.AddProperty(new Property(propertyId, floatVector));
                                break;

                            case PropertyType.EnumVector:
                                List<short> enumVector = new List<short>();
                                enumVector.Add((short)44);
                                enumVector.Add((short)45);
                                enumVector.Add((short)46);
                                rd.AddProperty(new Property(propertyId, enumVector));
                                break;
                            default:
                                break;
                        }
                    }
                }

                if (!updates.ContainsKey(type))
                {
                    updates.Add(type, rd);
                    delta.AddDeltaOperation(DeltaOpType.Update, rd, true);
                }
            }
            #endregion Creating resources

            #region Set references

            //SetPowerTransformerReferences(updates);
            //SetTransformerWindingReferences(updates);
            //SetWindingTestRefernces(updates);

            #endregion Set references

            return updates;
        }

        #region set references

        //private void SetPowerTransformerReferences(Dictionary<DMSType, ResourceDescription> updates)
        //{
        //    for (int i = 0; i < updates[DMSType.POWERTR].Properties.Count; i++)
        //    {
        //        if (updates[DMSType.POWERTR].Properties[i].Id == ModelCode.PSR_LOCATION)
        //        {
        //            updates[DMSType.POWERTR].Properties[i].SetValue(updates[DMSType.LOCATION].Id);
        //        }
        //    }
        //}

        //private void SetTransformerWindingReferences(Dictionary<DMSType, ResourceDescription> updates)
        //{
        //    for (int i = 0; i < updates[DMSType.POWERTRWINDING].Properties.Count; i++)
        //    {
        //        if (updates[DMSType.POWERTRWINDING].Properties[i].Id == ModelCode.CONDEQ_BASVOLTAGE)
        //        {
        //            updates[DMSType.POWERTRWINDING].Properties[i].SetValue(updates[DMSType.BASEVOLTAGE].Id);
        //        }

        //        if (updates[DMSType.POWERTRWINDING].Properties[i].Id == ModelCode.PSR_LOCATION)
        //        {
        //            updates[DMSType.POWERTRWINDING].Properties[i].SetValue(updates[DMSType.LOCATION].Id);
        //        }

        //        if (updates[DMSType.POWERTRWINDING].Properties[i].Id == ModelCode.POWERTRWINDING_POWERTRW)
        //        {
        //            updates[DMSType.POWERTRWINDING].Properties[i].SetValue(updates[DMSType.POWERTR].Id);
        //        }
        //    }
        //}

        //private void SetWindingTestRefernces(Dictionary<DMSType, ResourceDescription> updates)
        //{
        //    for (int i = 0; i < updates[DMSType.WINDINGTEST].Properties.Count; i++)
        //    {
        //        if (updates[DMSType.WINDINGTEST].Properties[i].Id == ModelCode.WINDINGTEST_POWERTRWINDING)
        //        {
        //            updates[DMSType.WINDINGTEST].Properties[i].SetValue(updates[DMSType.POWERTRWINDING].Id);
        //        }
        //    }
        //}

        #endregion set references
        */
        #endregion GDAUpdate Service

        #endregion Test Methods

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
