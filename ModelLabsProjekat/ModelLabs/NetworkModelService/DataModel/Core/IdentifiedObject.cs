//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Reflection;
using FTN.Common;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    public enum TypeOfReference : short
    {
        Reference = 1,
        Target = 2,
        Both = 3,
    }
    /// This is a root class to provide common identification for all classes needing identification and naming attributes.
    public class IdentifiedObject
    {
        private static ModelResourcesDesc resourcesDescs = new ModelResourcesDesc();

        #region globalId
        private long globalId;

        public long GlobalId
        {
            get
            {
                return globalId;
            }

            set
            {
                globalId = value;
            }
        }        
        #endregion globalId

        public IdentifiedObject(long globalId)
        {
            this.globalId = globalId;
        }

        #region aliasName
        /// The aliasName is free text human readable name of the object alternative to IdentifiedObject.name. It may be non unique and may not correlate to a naming hierarchy.
        ///The attribute aliasName is retained because of backwards compatibility between CIM relases. It is however recommended to replace aliasName with the Name class as aliasName is planned for retirement at a future time.
        private string cim_aliasName;
        
        private const bool isAliasNameMandatory = false;
        
        private const string _aliasNamePrefix = "cim";

        public virtual string AliasName
        {
            get
            {
                return this.cim_aliasName;
            }
            set
            {
                this.cim_aliasName = value;
            }
        }

        public virtual bool AliasNameHasValue
        {
            get
            {
                return this.cim_aliasName != null;
            }
        }

        public static bool IsAliasNameMandatory
        {
            get
            {
                return isAliasNameMandatory;
            }
        }

        public static string AliasNamePrefix
        {
            get
            {
                return _aliasNamePrefix;
            }
        }
        #endregion aliasName
        #region mRID
        /// Master resource identifier issued by a model authority. The mRID is globally unique within an exchange context.
        ///Global uniqeness is easily achived by using a UUID for the mRID. It is strongly recommended to do this.
        ///For CIMXML data files in RDF syntax, the mRID is mapped to rdf:ID or rdf:about attributes that identify CIM object elements.
        private string cim_mRID;
        
        private const bool isMRIDMandatory = false;
        
        private const string _mRIDPrefix = "cim";

        public virtual string MRID
        {
            get
            {
                return this.cim_mRID;
            }
            set
            {
                this.cim_mRID = value;
            }
        }

        public virtual bool MRIDHasValue
        {
            get
            {
                return this.cim_mRID != null;
            }
        }

        public static bool IsMRIDMandatory
        {
            get
            {
                return isMRIDMandatory;
            }
        }

        public static string MRIDPrefix
        {
            get
            {
                return _mRIDPrefix;
            }
        }
        #endregion mRID
        #region name
        /// The name is any free human readable and possibly non unique text naming the object.
        private string cim_name;
        
        private const bool isNameMandatory = false;
        
        private const string _namePrefix = "cim";

        public virtual string Name
        {
            get
            {
                return this.cim_name;
            }
            set
            {
                this.cim_name = value;
            }
        }

        public virtual bool NameHasValue
        {
            get
            {
                return this.cim_name != null;
            }
        }

        public static bool IsNameMandatory
        {
            get
            {
                return isNameMandatory;
            }
        }

        public static string NamePrefix
        {
            get
            {
                return _namePrefix;
            }
        }
        #endregion name              

        public static bool operator ==(IdentifiedObject x, IdentifiedObject y)
        {
            if (Object.ReferenceEquals(x, null) && Object.ReferenceEquals(y, null))
            {
                return true;
            }
            else if ((Object.ReferenceEquals(x, null) && !Object.ReferenceEquals(y, null)) || (!Object.ReferenceEquals(x, null) && Object.ReferenceEquals(y, null)))
            {
                return false;
            }
            else
            {
                return x.Equals(y);
            }
        }

        public static bool operator !=(IdentifiedObject x, IdentifiedObject y)
        {
            return !(x == y);
        }

        public override bool Equals(object x)
        {
            if (Object.ReferenceEquals(x, null))
            {
                return false;
            }
            else
            {
                IdentifiedObject io = (IdentifiedObject)x;
                return ((io.globalId == this.globalId) && 
                        (io.cim_name == this.cim_name) && 
                        (io.cim_mRID == this.cim_mRID) && 
                        (io.cim_aliasName == this.cim_aliasName));
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region IAccess implementation

        public virtual bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.IDObject_GID_:
                case ModelCode.IDObject_Name_:
                case ModelCode.IDObject_AName_:
                case ModelCode.IDObject_MRID_:
                    return true;

                default:
                    return false;
            }
        }

        public virtual void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.IDObject_GID_:
                    property.SetValue(globalId);
                    break;

                case ModelCode.IDObject_Name_:
                    property.SetValue(cim_name);
                    break;

                case ModelCode.IDObject_MRID_:
                    property.SetValue(cim_mRID);
                    break;

                case ModelCode.IDObject_AName_:
                    property.SetValue(cim_aliasName);
                    break;

                default:
                    string message = string.Format("Unknown property id = {0} for entity (GID = 0x{1:x16}).", property.Id.ToString(), this.GlobalId);
                    CommonTrace.WriteTrace(CommonTrace.TraceError, message);
                    throw new Exception(message);
            }
        }

        public virtual void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.IDObject_Name_:
                    cim_name = property.AsString();
                    break;

                case ModelCode.IDObject_AName_:
                    cim_aliasName = property.AsString();
                    break;

                case ModelCode.IDObject_MRID_:
                    cim_mRID = property.AsString();
                    break;

                default:
                    string message = string.Format("Unknown property id = {0} for entity (GID = 0x{1:x16}).", property.Id.ToString(), this.GlobalId);
                    CommonTrace.WriteTrace(CommonTrace.TraceError, message);
                    throw new Exception(message);
            }
        }

        #endregion IAccess implementation

        #region IReference implementation	

        public virtual bool IsReferenced
        {
            get
            {
                return false;
            }
        }

        public virtual void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            return;
        }

        public virtual void AddReference(ModelCode referenceId, long globalId)
        {
            string message = string.Format("Can not add reference {0} to entity (GID = 0x{1:x16}).", referenceId, this.GlobalId);
            CommonTrace.WriteTrace(CommonTrace.TraceError, message);
            throw new Exception(message);
        }

        public virtual void RemoveReference(ModelCode referenceId, long globalId)
        {
            string message = string.Format("Can not remove reference {0} from entity (GID = 0x{1:x16}).", referenceId, this.GlobalId);
            CommonTrace.WriteTrace(CommonTrace.TraceError, message);
            throw new ModelException(message);
        }

        #endregion IReference implementation

        #region utility methods

        public void GetReferences(Dictionary<ModelCode, List<long>> references)
        {
            GetReferences(references, TypeOfReference.Target | TypeOfReference.Reference);
        }

        public ResourceDescription GetAsResourceDescription(bool onlySettableAttributes)
        {
            ResourceDescription rd = new ResourceDescription(globalId);
            List<ModelCode> props = new List<ModelCode>();

            if (onlySettableAttributes == true)
            {
                props = resourcesDescs.GetAllSettablePropertyIdsForEntityId(globalId);
            }
            else
            {
                props = resourcesDescs.GetAllPropertyIdsForEntityId(globalId);
            }

            return rd;
        }

        public ResourceDescription GetAsResourceDescription(List<ModelCode> propIds)
        {
            ResourceDescription rd = new ResourceDescription(globalId);

            for (int i = 0; i < propIds.Count; i++)
            {
                rd.AddProperty(GetProperty(propIds[i]));
            }

            return rd;
        }

        public virtual Property GetProperty(ModelCode propId)
        {
            Property property = new Property(propId);
            GetProperty(property);
            return property;
        }

        public void GetDifferentProperties(IdentifiedObject compared, out List<Property> valuesInOriginal, out List<Property> valuesInCompared)
        {
            valuesInCompared = new List<Property>();
            valuesInOriginal = new List<Property>();

            ResourceDescription rd = this.GetAsResourceDescription(false);

            if (compared != null)
            {
                ResourceDescription rdCompared = compared.GetAsResourceDescription(false);

                for (int i = 0; i < rd.Properties.Count; i++)
                {
                    if (rd.Properties[i] != rdCompared.Properties[i])
                    {
                        valuesInOriginal.Add(rd.Properties[i]);
                        valuesInCompared.Add(rdCompared.Properties[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < rd.Properties.Count; i++)
                {
                    valuesInOriginal.Add(rd.Properties[i]);
                }
            }
        }

        #endregion utility methods
    }
}
