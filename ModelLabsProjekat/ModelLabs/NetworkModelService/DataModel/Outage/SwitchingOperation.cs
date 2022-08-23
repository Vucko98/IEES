//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;

namespace FTN.Services.NetworkModelService.DataModel.Outage
{
    /// A SwitchingOperation is used to define individual switch operations for an OutageSchedule. This OutageSchedule may be associated with another item of Substation such as a Transformer, Line, or Generator; or with the Switch itself as a PowerSystemResource. A Switch may be referenced by many OutageSchedules.
    public class SwitchingOperation : IdentifiedObject {

        public SwitchingOperation(long globalId) : base(globalId)
        {
        }

        #region newState
        /// The switch position that shall result from this SwitchingOperation.
        private SwitchState? cim_newState;
        
        private const bool isNewStateMandatory = false;
        
        private const string _newStatePrefix = "cim";

        public virtual SwitchState NewState
        {
            get
            {
                return this.cim_newState.GetValueOrDefault();
            }
            set
            {
                this.cim_newState = value;
            }
        }

        public virtual bool NewStateHasValue
        {
            get
            {
                return this.cim_newState != null;
            }
        }

        public static bool IsNewStateMandatory
        {
            get
            {
                return isNewStateMandatory;
            }
        }

        public static string NewStatePrefix
        {
            get
            {
                return _newStatePrefix;
            }
        }

        #endregion newState

        #region operationTime
        /// Time of operation in same units as OutageSchedule.xAxixUnits.
        private System.DateTime? cim_operationTime;
        
        private const bool isOperationTimeMandatory = false;
        
        private const string _operationTimePrefix = "cim";

        public virtual System.DateTime OperationTime
        {
            get
            {
                return this.cim_operationTime.GetValueOrDefault();
            }
            set
            {
                this.cim_operationTime = value;
            }
        }

        public virtual bool OperationTimeHasValue
        {
            get
            {
                return this.cim_operationTime != null;
            }
        }

        public static bool IsOperationTimeMandatory
        {
            get
            {
                return isOperationTimeMandatory;
            }
        }

        public static string OperationTimePrefix
        {
            get
            {
                return _operationTimePrefix;
            }
        }

        #endregion operationTime

        #region OutageSchedule
        /// An OutageSchedule may operate many switches.
        private long cim_OutageSchedule = 0;
        
        private const bool isOutageScheduleMandatory = false;
        
        private const string _OutageSchedulePrefix = "cim";

        public virtual long OutageSchedule
        {
            get
            {
                return this.cim_OutageSchedule;
            }
            set
            {
                this.cim_OutageSchedule = value;
            }
        }

        public virtual bool OutageScheduleHasValue
        {
            get
            {
                return this.cim_OutageSchedule != null;
            }
        }

        public static bool IsOutageScheduleMandatory
        {
            get
            {
                return isOutageScheduleMandatory;
            }
        }

        public static string OutageSchedulePrefix
        {
            get
            {
                return _OutageSchedulePrefix;
            }
        }

        #endregion OutageSchedule        

        #region Switches

        List<long> cim_Switches = new List<long>();

        public List<long> Switches
        {
            get
            {
                return cim_Switches;
            }
            set
            {
                cim_Switches = value;
            }
        }

        #endregion TimePoints

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                SwitchingOperation sw = (SwitchingOperation)obj;
                return (sw.cim_newState == this.cim_newState &&
                        sw.cim_operationTime == this.cim_operationTime &&
                        sw.cim_OutageSchedule == this.cim_OutageSchedule &&
                        CompareHelper.CompareLists(sw.cim_Switches, this.cim_Switches));
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region IAccess implementation

        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.SwitchingOp_NewState_:
                case ModelCode.SwitchingOp_OpTime_:
                case ModelCode.SwitchingOp_OutageSdle_:
                case ModelCode.SwitchingOp_Switches_:
                    return true;

                default:
                    return base.HasProperty(property);
                    break;
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.SwitchingOp_NewState_:
                    property.SetValue((short)cim_newState);
                    break;

                case ModelCode.SwitchingOp_OpTime_:
                    property.SetValue(OperationTime);
                    break;

                case ModelCode.SwitchingOp_OutageSdle_:
                    property.SetValue(cim_OutageSchedule);
                    break;

                case ModelCode.SwitchingOp_Switches_:
                    property.SetValue(cim_Switches);
                    break;

                default:
                    base.GetProperty(property);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.RegularTP_SequenceNum_:
                    cim_newState = (SwitchState)property.AsEnum();
                    break;

                case ModelCode.RegularTP_V1_:
                    cim_operationTime = property.AsDateTime();
                    break;

                case ModelCode.SwitchingOp_Switches_:
                    cim_OutageSchedule = property.AsReference();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation

        public override bool IsReferenced
        {
            get
            {
                return cim_Switches.Count > 0 ||  base.IsReferenced;
            }
        }

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (cim_Switches != null && cim_Switches.Count != 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.SwitchingOp_Switches_] = cim_Switches.GetRange(0, cim_Switches.Count);
            }

            if (cim_OutageSchedule != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.SwitchingOp_OutageSdle_] = new List<long>();
                references[ModelCode.SwitchingOp_OutageSdle_].Add(cim_OutageSchedule);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.Switch_SwitchingOp_:
                    cim_Switches.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.Switch_SwitchingOp_:

                    if (cim_Switches.Contains(globalId))
                    {
                        cim_Switches.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }

        #endregion IReference implementation
    }
}
