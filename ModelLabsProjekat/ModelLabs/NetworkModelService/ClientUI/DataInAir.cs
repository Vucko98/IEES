using FTN.Common;
using System;
using System.Collections.Generic;

namespace ClientUI
{
    public static class DataInAir
    {
        public static TestGda tGDA = null;
        public static Dictionary<string, (long, DMSType)> strGID__GID_DMSType = new Dictionary<string, (long, DMSType)>();
        public static Dictionary<DMSType, List<ModelCode>> DMSType_ModelCodes = new Dictionary<DMSType, List<ModelCode>>();
        public static Dictionary<DMSType, List<ModelCode>> DMSType_Reference = new Dictionary<DMSType, List<ModelCode>>();
        
        static DataInAir()
        {
            InitializeTestGda();
            tGDA.TestGetExtentValuesAllTypes(ref strGID__GID_DMSType, ref DMSType_Reference);
            DMSType_ModelCodes = get_DMSType_ModelCodes();
        }

        private static void InitializeTestGda()
        {
            try //TRY
            {
                tGDA = new TestGda();
            }
            catch (Exception exc)
            {
                Console.WriteLine(string.Format("DataInAir->InitializeTestGda failed:\n\t{0}", exc.Message));
                tGDA = null;
                //throw;
            }
        }

        private static Dictionary<DMSType, List<ModelCode>> get_DMSType_ModelCodes()
        {            
            Dictionary<DMSType, List<ModelCode>> _DMSType_ModelCodes = new Dictionary<DMSType, List<ModelCode>>();

            try //TRY
            {                                
                foreach (DMSType _DMSType in tGDA.modelResourcesDesc.AllDMSTypes)
                {
                    if (_DMSType != DMSType.MASK_TYPE)
                        _DMSType_ModelCodes.Add(_DMSType, tGDA.modelResourcesDesc.GetAllPropertyIds(_DMSType));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("DataInAir->get_DMSType_ModelCodes failed:\n\t{0}", e.Message));
                _DMSType_ModelCodes = null;
            }

            return _DMSType_ModelCodes;
        }
    }
}
