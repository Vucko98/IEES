using System;
using System.Collections.Generic;
using System.Text;

namespace FTN.Common
{
	
	public enum DMSType : short
	{		
		MASK_TYPE							= unchecked((short)0xFFFF),
        
        SwitchingOp_ =								0x0001,
        RegularTP_ =								0x0002,
        IrregularTP_ =								0x0003,
        RegularIntervalSdle_ =						0x0004,
        OutageSdle_ =								0x0005,
        Disconnector_ =								0x0006,
    }

    [Flags]
	public enum ModelCode : long
	{
        IDObject_ =							0x1000000000000000,
        IDObject_GID_ =						0x1000000000000100,
        IDObject_AName_ =					0x1000000000000200,
        IDObject_MRID_ =					0x1000000000000300,
        IDObject_Name_ =					0x1000000000000400,

        PowerSystemResource_ =				0x1100000000000000,

        SwitchingOp_ =						0x1200000000010000,
        SwitchingOp_NewState_ =				0x1200000000010100,
        SwitchingOp_OpTime_ =				0x1200000000010200,
        SwitchingOp_OutageSdle_ =			0x1200000000010300,
        SwitchingOp_Switches_ =				0x1200000000010400,

		BasicIntervalSdle_ =				0x1300000000000000,
		BasicIntervalSdle_StartT_ =			0x1300000000000100,
		BasicIntervalSdle_V1Mplr_ =			0x1300000000000200,
		BasicIntervalSdle_V1Unit_ =			0x1300000000000300,
		BasicIntervalSdle_V2Mplr_ =			0x1300000000000400,
		BasicIntervalSdle_V2Unit_ =			0x1300000000000500,

		RegularTP_ =						0x1400000000020000,
		RegularTP_SequenceNum_ =			0x1400000000020100,
		RegularTP_V1_ =						0x1400000000020200,
		RegularTP_V2_ =						0x1400000000020300,
		RegularTP_IntervalSdle_ =			0x1400000000020400,

		IrregularTP_ =						0x1500000000030000,
		IrregularTP_time_ =					0x1500000000030100,
		IrregularTP_V1_ =					0x1500000000030200,
		IrregularTP_V2_ =					0x1500000000030300,
		IrregularTP_IntervalSdle_ =			0x1500000000030400,

		Equipment_ =						0x1110000000000000,

		IrregularIntervalSdle_ =			0x1310000000000000,
		IrregularIntervalSdle_TPs_ =		0x1310000000000100,

		RegularIntervalSdle_ =				0x1320000000040000,
		RegularIntervalSdle_EndT_ =			0x1320000000040100,
		RegularIntervalSdle_TStep_ =		0x1320000000040200,
		RegularIntervalSdle_TPs_ =			0x1320000000040300,

		ConductingEquipment_ =				0x1111000000000000,

		OutageSdle_ =						0x1311000000050000,
		OutageSdle_SwitchingOps_ =			0x1311000000050100,

		Switch_ =							0x1111100000000000,
		Switch_SwitchingOp_ =				0x1111100000000010,

		Disconnector_ =						0x1111110000060000,
	}

    [Flags]
	public enum ModelCodeMask : long
	{
		MASK_TYPE			 = 0x00000000ffff0000,
		MASK_ATTRIBUTE_INDEX = 0x000000000000ff00,
		MASK_ATTRIBUTE_TYPE	 = 0x00000000000000ff,

		MASK_INHERITANCE_ONLY = unchecked((long)0xffffffff00000000),
		MASK_FIRSTNBL		  = unchecked((long)0xf000000000000000),
		MASK_DELFROMNBL8	  = unchecked((long)0xfffffff000000000),		
	}																		
}
