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
    /// Schedule of values at points in time.
    public class BasicIntervalSchedule : IdentifiedObject {
        
        /// The time for the first time point.
        private System.DateTime? cim_startTime;
        
        private const bool isStartTimeMandatory = false;
        
        private const string _startTimePrefix = "cim";
        
        /// Multiplier for value1.
        private UnitMultiplier? cim_value1Multiplier;
        
        private const bool isValue1MultiplierMandatory = false;
        
        private const string _value1MultiplierPrefix = "cim";
        
        /// Value1 units of measure.
        private UnitSymbol? cim_value1Unit;
        
        private const bool isValue1UnitMandatory = false;
        
        private const string _value1UnitPrefix = "cim";
        
        /// Multiplier for value2.
        private UnitMultiplier? cim_value2Multiplier;
        
        private const bool isValue2MultiplierMandatory = false;
        
        private const string _value2MultiplierPrefix = "cim";
        
        /// Value2 units of measure.
        private UnitSymbol? cim_value2Unit;
        
        private const bool isValue2UnitMandatory = false;
        
        private const string _value2UnitPrefix = "cim";
        
        public virtual System.DateTime StartTime {
            get {
                return this.cim_startTime.GetValueOrDefault();
            }
            set {
                this.cim_startTime = value;
            }
        }
        
        public virtual bool StartTimeHasValue {
            get {
                return this.cim_startTime != null;
            }
        }
        
        public static bool IsStartTimeMandatory {
            get {
                return isStartTimeMandatory;
            }
        }
        
        public static string StartTimePrefix {
            get {
                return _startTimePrefix;
            }
        }
        
        public virtual UnitMultiplier Value1Multiplier {
            get {
                return this.cim_value1Multiplier.GetValueOrDefault();
            }
            set {
                this.cim_value1Multiplier = value;
            }
        }
        
        public virtual bool Value1MultiplierHasValue {
            get {
                return this.cim_value1Multiplier != null;
            }
        }
        
        public static bool IsValue1MultiplierMandatory {
            get {
                return isValue1MultiplierMandatory;
            }
        }
        
        public static string Value1MultiplierPrefix {
            get {
                return _value1MultiplierPrefix;
            }
        }
        
        public virtual UnitSymbol Value1Unit {
            get {
                return this.cim_value1Unit.GetValueOrDefault();
            }
            set {
                this.cim_value1Unit = value;
            }
        }
        
        public virtual bool Value1UnitHasValue {
            get {
                return this.cim_value1Unit != null;
            }
        }
        
        public static bool IsValue1UnitMandatory {
            get {
                return isValue1UnitMandatory;
            }
        }
        
        public static string Value1UnitPrefix {
            get {
                return _value1UnitPrefix;
            }
        }
        
        public virtual UnitMultiplier Value2Multiplier {
            get {
                return this.cim_value2Multiplier.GetValueOrDefault();
            }
            set {
                this.cim_value2Multiplier = value;
            }
        }
        
        public virtual bool Value2MultiplierHasValue {
            get {
                return this.cim_value2Multiplier != null;
            }
        }
        
        public static bool IsValue2MultiplierMandatory {
            get {
                return isValue2MultiplierMandatory;
            }
        }
        
        public static string Value2MultiplierPrefix {
            get {
                return _value2MultiplierPrefix;
            }
        }
        
        public virtual UnitSymbol Value2Unit {
            get {
                return this.cim_value2Unit.GetValueOrDefault();
            }
            set {
                this.cim_value2Unit = value;
            }
        }
        
        public virtual bool Value2UnitHasValue {
            get {
                return this.cim_value2Unit != null;
            }
        }
        
        public static bool IsValue2UnitMandatory {
            get {
                return isValue2UnitMandatory;
            }
        }
        
        public static string Value2UnitPrefix {
            get {
                return _value2UnitPrefix;
            }
        }
    }
}
