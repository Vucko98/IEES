//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FTN.Common;

namespace FTN.Services.NetworkModelService.DataModel.Core
{
    /// TimePoints for a schedule where the time between the points varies.
    public class IrregularTimePoint : IdentifiedObject {
        
        /// An IrregularTimePoint belongs to an IrregularIntervalSchedule.
        private IrregularIntervalSchedule cim_IntervalSchedule;
        
        private const bool isIntervalScheduleMandatory = true;
        
        private const string _IntervalSchedulePrefix = "cim";
        
        /// The time is relative to the schedule starting time.
        private System.Single? cim_time;
        
        private const bool isTimeMandatory = false;
        
        private const string _timePrefix = "cim";
        
        /// The first value at the time. The meaning of the value is defined by the derived type of the associated schedule.
        private System.Single? cim_value1;
        
        private const bool isValue1Mandatory = false;
        
        private const string _value1Prefix = "cim";
        
        /// The second value at the time. The meaning of the value is defined by the derived type of the associated schedule.
        private System.Single? cim_value2;
        
        private const bool isValue2Mandatory = false;
        
        private const string _value2Prefix = "cim";
        
        public virtual IrregularIntervalSchedule IntervalSchedule {
            get {
                return this.cim_IntervalSchedule;
            }
            set {
                this.cim_IntervalSchedule = value;
            }
        }
        
        public virtual bool IntervalScheduleHasValue {
            get {
                return this.cim_IntervalSchedule != null;
            }
        }
        
        public static bool IsIntervalScheduleMandatory {
            get {
                return isIntervalScheduleMandatory;
            }
        }
        
        public static string IntervalSchedulePrefix {
            get {
                return _IntervalSchedulePrefix;
            }
        }
        
        public virtual float Time {
            get {
                return this.cim_time.GetValueOrDefault();
            }
            set {
                this.cim_time = value;
            }
        }
        
        public virtual bool TimeHasValue {
            get {
                return this.cim_time != null;
            }
        }
        
        public static bool IsTimeMandatory {
            get {
                return isTimeMandatory;
            }
        }
        
        public static string TimePrefix {
            get {
                return _timePrefix;
            }
        }
        
        public virtual float Value1 {
            get {
                return this.cim_value1.GetValueOrDefault();
            }
            set {
                this.cim_value1 = value;
            }
        }
        
        public virtual bool Value1HasValue {
            get {
                return this.cim_value1 != null;
            }
        }
        
        public static bool IsValue1Mandatory {
            get {
                return isValue1Mandatory;
            }
        }
        
        public static string Value1Prefix {
            get {
                return _value1Prefix;
            }
        }
        
        public virtual float Value2 {
            get {
                return this.cim_value2.GetValueOrDefault();
            }
            set {
                this.cim_value2 = value;
            }
        }
        
        public virtual bool Value2HasValue {
            get {
                return this.cim_value2 != null;
            }
        }
        
        public static bool IsValue2Mandatory {
            get {
                return isValue2Mandatory;
            }
        }
        
        public static string Value2Prefix {
            get {
                return _value2Prefix;
            }
        }
    }
}
