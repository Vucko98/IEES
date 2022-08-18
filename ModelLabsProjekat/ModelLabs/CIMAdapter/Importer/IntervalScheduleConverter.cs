namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	using FTN.Common;

	/// <summary>
	/// PowerTransformerConverter has methods for populating
	/// ResourceDescription objects using PowerTransformerCIMProfile_Labs objects.
	/// </summary>
	public static class IntervalScheduleConverter
	{

		#region Populate ResourceDescription
        //10000000
		public static void PopulateIdentifiedObjectProperties(FTN.IdentifiedObject cimIdentifiedObject, ResourceDescription rd)
		{
			if ((cimIdentifiedObject != null) && (rd != null))
			{
				if (cimIdentifiedObject.MRIDHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDObject_MRID_, cimIdentifiedObject.MRID));
				}
				if (cimIdentifiedObject.NameHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDObject_Name_, cimIdentifiedObject.Name));
				}
				if (cimIdentifiedObject.AliasNameHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDObject_AName_, cimIdentifiedObject.AliasName));
				}
			}
		}
        //11000000
        public static void PopulatePowerSystemResourceProperties(FTN.PowerSystemResource cimPowerSystemResource, ResourceDescription rd)
        {
            if ((cimPowerSystemResource != null) && (rd != null))
            {
                IntervalScheduleConverter.PopulateIdentifiedObjectProperties(cimPowerSystemResource, rd);
            }
        }
        //12000000
        public static void PopulateSwitchingOperationProperties(FTN.SwitchingOperation cimSwitchingOperation, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimSwitchingOperation != null) && (rd != null))
            {
                IntervalScheduleConverter.PopulateIdentifiedObjectProperties(cimSwitchingOperation, rd);

                if (cimSwitchingOperation.NewStateHasValue)
                {
                    //rd.AddProperty(new Property(ModelCode.SwitchingOp_NewState_, (short)GetDMSSwitchState(cimSwitchingOperation.NewState)));
                    rd.AddProperty(new Property(ModelCode.SwitchingOp_NewState_, (short)cimSwitchingOperation.NewState));
                }
                if (cimSwitchingOperation.OperationTimeHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.SwitchingOp_OpTime_, cimSwitchingOperation.OperationTime));
                }
                if (cimSwitchingOperation.OutageScheduleHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimSwitchingOperation.OutageSchedule.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimSwitchingOperation.GetType().ToString()).Append(" rdfID = \"").Append(cimSwitchingOperation.ID);
                        report.Report.Append("\" - Failed to set reference to OutageSchedule: rdfID \"").Append(cimSwitchingOperation.OutageSchedule.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.SwitchingOp_OutageSdle_, gid));
                }                                                                                               
            }
        }
        //13000000
        public static void PopulateBasicIntervalScheduleProperties(FTN.BasicIntervalSchedule cimBasicIntervalSchedule, ResourceDescription rd)
        {
            if ((cimBasicIntervalSchedule != null) && (rd != null))
            {
                IntervalScheduleConverter.PopulateIdentifiedObjectProperties(cimBasicIntervalSchedule, rd);

                if (cimBasicIntervalSchedule.StartTimeHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.BasicIntervalSdle_StartT_, cimBasicIntervalSchedule.StartTime));
                }
                if (cimBasicIntervalSchedule.Value1MultiplierHasValue)
                {
                    //rd.AddProperty(new Property(ModelCode.BasicIntervalSdle_V1Mplr_, (short)GetDMSUnitMultiplier(cimBasicIntervalSchedule.Value1Multiplier)));
                    rd.AddProperty(new Property(ModelCode.BasicIntervalSdle_V1Mplr_, (short)cimBasicIntervalSchedule.Value1Multiplier));
                }
                if (cimBasicIntervalSchedule.Value2MultiplierHasValue)
                {
                    //rd.AddProperty(new Property(ModelCode.BasicIntervalSdle_V2Mplr_, (short)GetDMSUnitMultiplier(cimBasicIntervalSchedule.Value2Multiplier)));
                    rd.AddProperty(new Property(ModelCode.BasicIntervalSdle_V2Mplr_, (short)cimBasicIntervalSchedule.Value2Multiplier));
                }
                if (cimBasicIntervalSchedule.Value1UnitHasValue)
                {
                    //rd.AddProperty(new Property(ModelCode.BasicIntervalSdle_V1Unit_, (short)GetDMSUnitSymbol(cimBasicIntervalSchedule.Value1Unit)));
                    rd.AddProperty(new Property(ModelCode.BasicIntervalSdle_V1Unit_, (short)cimBasicIntervalSchedule.Value1Unit));
                }
                if (cimBasicIntervalSchedule.Value2UnitHasValue)
                {
                    //rd.AddProperty(new Property(ModelCode.BasicIntervalSdle_V2Unit_, (short)GetDMSUnitSymbol(cimBasicIntervalSchedule.Value2Unit)));
                    rd.AddProperty(new Property(ModelCode.BasicIntervalSdle_V2Unit_, (short)cimBasicIntervalSchedule.Value2Unit));
                }
            }
        }
        //14000000
        public static void PopulateRegularTimePointProperties(FTN.RegularTimePoint cimRegularTimePoint, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimRegularTimePoint != null) && (rd != null))
            {
                IntervalScheduleConverter.PopulateIdentifiedObjectProperties(cimRegularTimePoint, rd);

                if (cimRegularTimePoint.SequenceNumberHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.RegularTP_SequenceNum_, cimRegularTimePoint.SequenceNumber));
                }
                if (cimRegularTimePoint.Value1HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.RegularTP_V1_, cimRegularTimePoint.Value1));
                }
                if (cimRegularTimePoint.Value2HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.RegularTP_V2_, cimRegularTimePoint.Value2));
                }
                if (cimRegularTimePoint.IntervalScheduleHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimRegularTimePoint.IntervalSchedule.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimRegularTimePoint.GetType().ToString()).Append(" rdfID = \"").Append(cimRegularTimePoint.ID);
                        report.Report.Append("\" - Failed to set reference to IntervalSchedule: rdfID \"").Append(cimRegularTimePoint.IntervalSchedule.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.RegularTP_IntervalSdle_, gid));
                }
            }
        }
        //15000000
        public static void PopulateIrregularTimePointProperties(FTN.IrregularTimePoint cimIrregularTimePoint, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimIrregularTimePoint != null) && (rd != null))
            {
                IntervalScheduleConverter.PopulateIdentifiedObjectProperties(cimIrregularTimePoint, rd);

                if (cimIrregularTimePoint.TimeHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.IrregularTP_time_, cimIrregularTimePoint.Time));
                }
                if (cimIrregularTimePoint.Value1HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.IrregularTP_V1_, cimIrregularTimePoint.Value1));
                }
                if (cimIrregularTimePoint.Value2HasValue)
                {
                    rd.AddProperty(new Property(ModelCode.IrregularTP_V2_, cimIrregularTimePoint.Value2));
                }
                if (cimIrregularTimePoint.IntervalScheduleHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimIrregularTimePoint.IntervalSchedule.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimIrregularTimePoint.GetType().ToString()).Append(" rdfID = \"").Append(cimIrregularTimePoint.ID);
                        report.Report.Append("\" - Failed to set reference to IntervalSchedule: rdfID \"").Append(cimIrregularTimePoint.IntervalSchedule.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.IrregularTP_IntervalSdle_, gid));
                }
            }
        }
        //11100000
        public static void PopulateEquipmentProperties(FTN.Equipment cimEquipment, ResourceDescription rd)
        {
            if ((cimEquipment != null) && (rd != null))
            {
                IntervalScheduleConverter.PopulatePowerSystemResourceProperties(cimEquipment, rd);
            }
        }
        //13100000
        public static void PopulateIrregularIntervalScheduleProperties(FTN.IrregularIntervalSchedule cimIrregularIntervalSchedule, ResourceDescription rd)
        {
            if ((cimIrregularIntervalSchedule != null) && (rd != null))
            {
                IntervalScheduleConverter.PopulateBasicIntervalScheduleProperties(cimIrregularIntervalSchedule, rd);
            }
        }
        //13200000
        public static void PopulateRegularIntervalScheduleProperties(FTN.RegularIntervalSchedule cimRegularIntervalSchedule, ResourceDescription rd)
        {
            if ((cimRegularIntervalSchedule != null) && (rd != null))
            {
                IntervalScheduleConverter.PopulateBasicIntervalScheduleProperties(cimRegularIntervalSchedule, rd);

                if (cimRegularIntervalSchedule.EndTimeHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.RegularIntervalSdle_EndT_, cimRegularIntervalSchedule.EndTime));
                }
                if (cimRegularIntervalSchedule.TimeStepHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.RegularIntervalSdle_TStep_, cimRegularIntervalSchedule.TimeStep));
                }
            }
        }
        //11110000
        public static void PopulateConductingEquipmentProperties(FTN.ConductingEquipment cimConductingEquipment, ResourceDescription rd)
        {
            if ((cimConductingEquipment != null) && (rd != null))
            {
                IntervalScheduleConverter.PopulateEquipmentProperties(cimConductingEquipment, rd);
            }
        }
        //13110000
        public static void PopulateOutageScheduleProperties(FTN.OutageSchedule cimOutageSchedule, ResourceDescription rd)
        {
            if ((cimOutageSchedule != null) && (rd != null))
            {
                IntervalScheduleConverter.PopulateIrregularIntervalScheduleProperties(cimOutageSchedule, rd);
            }
        }
        //11111000
        public static void PopulateSwitchProperties(FTN.Switch cimSwitch, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimSwitch != null) && (rd != null))
            {
                IntervalScheduleConverter.PopulateConductingEquipmentProperties(cimSwitch, rd);

                if (cimSwitch.SwitchingOperationsHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimSwitch.SwitchingOperations.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").Append(cimSwitch.GetType().ToString()).Append(" rdfID = \"").Append(cimSwitch.ID);
                        report.Report.Append("\" - Failed to set reference to SwitchingOperations: rdfID \"").Append(cimSwitch.SwitchingOperations.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.Switch_SwitchingOp_, gid));
                }
            }
        }
        //11111100
        public static void PopulateDisconnectorProperties(FTN.Disconnector cimDisconnector, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimDisconnector != null) && (rd != null))
            {
                IntervalScheduleConverter.PopulateSwitchProperties(cimDisconnector, rd, importHelper, report);
            }
        }
        #endregion Populate ResourceDescription

        #region Enums convert

        public static UnitMultiplier GetDMSUnitMultiplier(FTN.UnitMultiplier unitMultiplier)
        {
            switch (unitMultiplier)
            {
                case FTN.UnitMultiplier.c:
                    return UnitMultiplier.c;
                case FTN.UnitMultiplier.d:
                    return UnitMultiplier.d;
                case FTN.UnitMultiplier.G:
                    return UnitMultiplier.G;
                case FTN.UnitMultiplier.k:
                    return UnitMultiplier.k;
                case FTN.UnitMultiplier.m:
                    return UnitMultiplier.m;
                case FTN.UnitMultiplier.M:
                    return UnitMultiplier.M;
                case FTN.UnitMultiplier.micro:
                    return UnitMultiplier.micro;
                case FTN.UnitMultiplier.n:
                    return UnitMultiplier.n;
                case FTN.UnitMultiplier.none:
                    return UnitMultiplier.none;
                case FTN.UnitMultiplier.p:
                    return UnitMultiplier.p;
                //case FTN.UnitMultiplier.T:
                default:
                    return UnitMultiplier.T;
            }
        }
        
        public static UnitSymbol GetDMSUnitSymbol(FTN.UnitSymbol unitSymbol)
        {
            switch (unitSymbol)
            {
                case FTN.UnitSymbol.A:
                    return UnitSymbol.A;
                case FTN.UnitSymbol.deg:
                    return UnitSymbol.deg;
                case FTN.UnitSymbol.degC:
                    return UnitSymbol.degC;
                case FTN.UnitSymbol.F:
                    return UnitSymbol.F;
                case FTN.UnitSymbol.g:
                    return UnitSymbol.g;
                case FTN.UnitSymbol.h:
                    return UnitSymbol.h;
                case FTN.UnitSymbol.H:
                    return UnitSymbol.H;
                case FTN.UnitSymbol.Hz:
                    return UnitSymbol.Hz;
                case FTN.UnitSymbol.J:
                    return UnitSymbol.J;
                case FTN.UnitSymbol.m:
                    return UnitSymbol.m;
                case FTN.UnitSymbol.m2:
                    return UnitSymbol.m2;
                case FTN.UnitSymbol.m3:
                    return UnitSymbol.m3;
                case FTN.UnitSymbol.min:
                    return UnitSymbol.min;
                case FTN.UnitSymbol.N:
                    return UnitSymbol.N;
                case FTN.UnitSymbol.none:
                    return UnitSymbol.none;
                case FTN.UnitSymbol.ohm:
                    return UnitSymbol.ohm;
                case FTN.UnitSymbol.Pa:
                    return UnitSymbol.Pa;
                case FTN.UnitSymbol.rad:
                    return UnitSymbol.rad;
                case FTN.UnitSymbol.s:
                    return UnitSymbol.s;
                case FTN.UnitSymbol.S:
                    return UnitSymbol.S;
                case FTN.UnitSymbol.V:
                    return UnitSymbol.V;
                case FTN.UnitSymbol.VA:
                    return UnitSymbol.VA;
                case FTN.UnitSymbol.VAh:
                    return UnitSymbol.VAh;
                case FTN.UnitSymbol.VAr:
                    return UnitSymbol.VAr;
                case FTN.UnitSymbol.VArh:
                    return UnitSymbol.VArh;
                case FTN.UnitSymbol.W:
                    return UnitSymbol.W;
                //case FTN.UnitSymbol.Wh:
                default:
                    return UnitSymbol.Wh;
            }
        }

        public static SwitchState GetDMSSwitchState(FTN.SwitchState switchState)
		{
			switch (switchState)
			{
                case FTN.SwitchState.open:
					return SwitchState.open;
				default:
					return SwitchState.close;
			}
		}

        #endregion Enums convert
    }
}
