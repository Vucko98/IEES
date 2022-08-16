﻿using System;
using System.Collections.Generic;
using CIM.Model;
using FTN.Common;
using FTN.ESI.SIMES.CIM.CIMAdapter.Manager;

namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	/// <summary>
	/// PowerTransformerImporter
	/// </summary>
	public class PowerTransformerImporter
	{
		/// <summary> Singleton </summary>
		private static PowerTransformerImporter ptImporter = null;
		private static object singletoneLock = new object();

		private ConcreteModel concreteModel;
		private Delta delta;
		private ImportHelper importHelper;
		private TransformAndLoadReport report;


		#region Properties
		public static PowerTransformerImporter Instance
		{
			get
			{
				if (ptImporter == null)
				{
					lock (singletoneLock)
					{
						if (ptImporter == null)
						{
							ptImporter = new PowerTransformerImporter();
							ptImporter.Reset();
						}
					}
				}
				return ptImporter;
			}
		}

		public Delta NMSDelta
		{
			get 
			{
				return delta;
			}
		}
		#endregion Properties


		public void Reset()
		{
			concreteModel = null;
			delta = new Delta();
			importHelper = new ImportHelper();
			report = null;
		}

		public TransformAndLoadReport CreateNMSDelta(ConcreteModel cimConcreteModel)
		{
			LogManager.Log("Importing PowerTransformer Elements...", LogLevel.Info);
			report = new TransformAndLoadReport();
			concreteModel = cimConcreteModel;
			delta.ClearDeltaOperations();

			if ((concreteModel != null) && (concreteModel.ModelMap != null))
			{
				try
				{
					// convert into DMS elements
					ConvertModelAndPopulateDelta();
				}
				catch (Exception ex)
				{
					string message = string.Format("{0} - ERROR in data import - {1}", DateTime.Now, ex.Message);
					LogManager.Log(message);
					report.Report.AppendLine(ex.Message);
					report.Success = false;
				}
			}
			LogManager.Log("Importing PowerTransformer Elements - END.", LogLevel.Info);
			return report;
		}

		/// <summary>
		/// Method performs conversion of network elements from CIM based concrete model into DMS model.
		/// </summary>
		private void ConvertModelAndPopulateDelta()
		{
			LogManager.Log("Loading elements and creating delta...", LogLevel.Info);

            //// import all concrete model types (DMSType enum)
            ImportRegularIntervalSchedules();
            ImportRegularTimePoints();
            ImportOutageSchedules();
            ImportIrregularTimePoints();
            ImportSwitchingOperations();
            ImportDisconnectors();

            LogManager.Log("Loading elements and creating delta completed.", LogLevel.Info);
		}

        #region Import
        private void ImportRegularIntervalSchedules()
        {
            SortedDictionary<string, object> cimRegularIntervalSchedules = concreteModel.GetAllObjectsOfType("FTN.RegularIntervalSchedule");
            if (cimRegularIntervalSchedules != null)
            {
                foreach (KeyValuePair<string, object> cimRegularIntervalSchedulePair in cimRegularIntervalSchedules)
                {
                    FTN.RegularIntervalSchedule cimRegularIntervalSchedule = cimRegularIntervalSchedulePair.Value as FTN.RegularIntervalSchedule;

                    ResourceDescription rd = CreateRegularIntervalScheduleResourceDescription(cimRegularIntervalSchedule);
                    if (rd != null)
                    {
                        delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                        report.Report.Append("RegularIntervalSchedule ID = ").Append(cimRegularIntervalSchedule.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
                    }
                    else
                    {
                        report.Report.Append("RegularIntervalSchedule ID = ").Append(cimRegularIntervalSchedule.ID).AppendLine(" FAILED to be converted");
                    }
                }
                report.Report.AppendLine();
            }
        }

        private ResourceDescription CreateRegularIntervalScheduleResourceDescription(FTN.RegularIntervalSchedule cimRegularIntervalSchedule)
        {
            ResourceDescription rd = null;
            if (cimRegularIntervalSchedule != null)
            {
                long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.RegularIntervalSdle_, importHelper.CheckOutIndexForDMSType(DMSType.RegularIntervalSdle_));
                rd = new ResourceDescription(gid);
                importHelper.DefineIDMapping(cimRegularIntervalSchedule.ID, gid);

                ////populate ResourceDescription
                PowerTransformerConverter.PopulateRegularIntervalScheduleProperties(cimRegularIntervalSchedule, rd);
            }
            return rd;
        }

        private void ImportRegularTimePoints()
        {
            SortedDictionary<string, object> cimRegularTimePoints = concreteModel.GetAllObjectsOfType("FTN.RegularTimePoint");
            if (cimRegularTimePoints != null)
            {
                foreach (KeyValuePair<string, object> cimRegularTimePointPair in cimRegularTimePoints)
                {
                    FTN.RegularTimePoint cimRegularTimePoint = cimRegularTimePointPair.Value as FTN.RegularTimePoint;

                    ResourceDescription rd = CreateRegularTimePointResourceDescription(cimRegularTimePoint);
                    if (rd != null)
                    {
                        delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                        report.Report.Append("RegularTimePoint ID = ").Append(cimRegularTimePoint.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
                    }
                    else
                    {
                        report.Report.Append("RegularTimePoint ID = ").Append(cimRegularTimePoint.ID).AppendLine(" FAILED to be converted");
                    }
                }
                report.Report.AppendLine();
            }
        }

        private ResourceDescription CreateRegularTimePointResourceDescription(FTN.RegularTimePoint cimRegularTimePoint)
        {
            ResourceDescription rd = null;
            if (cimRegularTimePoint != null)
            {
                long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.RegularTP_, importHelper.CheckOutIndexForDMSType(DMSType.RegularTP_));
                rd = new ResourceDescription(gid);
                importHelper.DefineIDMapping(cimRegularTimePoint.ID, gid);

                ////populate ResourceDescription
                PowerTransformerConverter.PopulateRegularTimePointProperties(cimRegularTimePoint, rd, importHelper, report);
            }
            return rd;
        }

        private void ImportOutageSchedules()
        {
            SortedDictionary<string, object> cimOutageSchedules = concreteModel.GetAllObjectsOfType("FTN.OutageSchedule");
            if (cimOutageSchedules != null)
            {
                foreach (KeyValuePair<string, object> cimOutageSchedulePair in cimOutageSchedules)
                {
                    FTN.OutageSchedule cimOutageSchedule = cimOutageSchedulePair.Value as FTN.OutageSchedule;

                    ResourceDescription rd = CreateOutageScheduleResourceDescription(cimOutageSchedule);
                    if (rd != null)
                    {
                        delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                        report.Report.Append("OutageSchedule ID = ").Append(cimOutageSchedule.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
                    }
                    else
                    {
                        report.Report.Append("OutageSchedule ID = ").Append(cimOutageSchedule.ID).AppendLine(" FAILED to be converted");
                    }
                }
                report.Report.AppendLine();
            }
        }

        private ResourceDescription CreateOutageScheduleResourceDescription(FTN.OutageSchedule cimOutageSchedule)
        {
            ResourceDescription rd = null;
            if (cimOutageSchedule != null)
            {
                long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.OutageSdle_, importHelper.CheckOutIndexForDMSType(DMSType.OutageSdle_));
                rd = new ResourceDescription(gid);
                importHelper.DefineIDMapping(cimOutageSchedule.ID, gid);

                ////populate ResourceDescription
                PowerTransformerConverter.PopulateOutageScheduleProperties(cimOutageSchedule, rd);
            }
            return rd;
        }

        private void ImportIrregularTimePoints()
        {
            SortedDictionary<string, object> cimIrregularTimePoints = concreteModel.GetAllObjectsOfType("FTN.IrregularTimePoint");
            if (cimIrregularTimePoints != null)
            {
                foreach (KeyValuePair<string, object> cimIrregularTimePointPair in cimIrregularTimePoints)
                {
                    FTN.IrregularTimePoint cimIrregularTimePoint = cimIrregularTimePointPair.Value as FTN.IrregularTimePoint;
                    ResourceDescription rd = CreateIrregularTimePointResourceDescription(cimIrregularTimePoint);
                    if (rd != null)
                    {
                        delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                        report.Report.Append("IrregularTimePoint ID = ").Append(cimIrregularTimePoint.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
                    }
                    else
                    {
                        report.Report.Append("IrregularTimePoint ID = ").Append(cimIrregularTimePoint.ID).AppendLine(" FAILED to be converted");
                    }
                }
                report.Report.AppendLine();
            }
        }

        private ResourceDescription CreateIrregularTimePointResourceDescription(FTN.IrregularTimePoint cimIrregularTimePoint)
        {
            ResourceDescription rd = null;
            if (cimIrregularTimePoint != null)
            {
                long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.IrregularTP_, importHelper.CheckOutIndexForDMSType(DMSType.IrregularTP_));
                rd = new ResourceDescription(gid);
                importHelper.DefineIDMapping(cimIrregularTimePoint.ID, gid);

                ////populate ResourceDescription
                PowerTransformerConverter.PopulateIrregularTimePointProperties(cimIrregularTimePoint, rd, importHelper, report);
            }
            return rd;
        }

        private void ImportSwitchingOperations()
        {
            SortedDictionary<string, object> cimSwitchingOperations = concreteModel.GetAllObjectsOfType("FTN.SwitchingOperation");
            if (cimSwitchingOperations != null)
            {
                foreach (KeyValuePair<string, object> cimSwitchingOperationPair in cimSwitchingOperations)
                {
                    FTN.SwitchingOperation cimSwitchingOperation = cimSwitchingOperationPair.Value as FTN.SwitchingOperation;

                    ResourceDescription rd = CreateSwitchingOperationResourceDescription(cimSwitchingOperation);
                    if (rd != null)
                    {
                        delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                        report.Report.Append("SwitchingOperation ID = ").Append(cimSwitchingOperation.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
                    }
                    else
                    {
                        report.Report.Append("SwitchingOperation ID = ").Append(cimSwitchingOperation.ID).AppendLine(" FAILED to be converted");
                    }
                }
                report.Report.AppendLine();
            }
        }

        private ResourceDescription CreateSwitchingOperationResourceDescription(FTN.SwitchingOperation cimSwitchingOperation)
        {
            ResourceDescription rd = null;
            if (cimSwitchingOperation != null)
            {
                long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.SwitchingOp_, importHelper.CheckOutIndexForDMSType(DMSType.SwitchingOp_));
                rd = new ResourceDescription(gid);
                importHelper.DefineIDMapping(cimSwitchingOperation.ID, gid);

                ////populate ResourceDescription
                PowerTransformerConverter.PopulateSwitchingOperationProperties(cimSwitchingOperation, rd, importHelper, report);
            }
            return rd;
        }

        private void ImportDisconnectors()
        {
            SortedDictionary<string, object> cimDisconnectors = concreteModel.GetAllObjectsOfType("FTN.Disconnector");
            if (cimDisconnectors != null)
            {
                foreach (KeyValuePair<string, object> cimDisconnectorPair in cimDisconnectors)
                {
                    FTN.Disconnector cimDisconnector = cimDisconnectorPair.Value as FTN.Disconnector;

                    ResourceDescription rd = CreateDisconnectorResourceDescription(cimDisconnector);
                    if (rd != null)
                    {
                        delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
                        report.Report.Append("Disconnector ID = ").Append(cimDisconnector.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
                    }
                    else
                    {
                        report.Report.Append("Disconnector ID = ").Append(cimDisconnector.ID).AppendLine(" FAILED to be converted");
                    }
                }
                report.Report.AppendLine();
            }
        }

        private ResourceDescription CreateDisconnectorResourceDescription(FTN.Disconnector cimDisconnector)
        {
            ResourceDescription rd = null;
            if (cimDisconnector != null)
            {
                long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.Disconnector_, importHelper.CheckOutIndexForDMSType(DMSType.Disconnector_));
                rd = new ResourceDescription(gid);
                importHelper.DefineIDMapping(cimDisconnector.ID, gid);

                ////populate ResourceDescription
                PowerTransformerConverter.PopulateDisconnectorProperties(cimDisconnector, rd, importHelper, report);
            }
            return rd;
        }       
        #endregion Import
    }
}

