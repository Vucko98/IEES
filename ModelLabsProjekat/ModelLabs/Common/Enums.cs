using System;

namespace FTN.Common
{
    public enum UnitMultiplier : short
    {
        c = 0,  // Centi 10**-2.
        d,      // Deci 10**-1.
        G,      // Giga 10**9.
        k,      // Kilo 10**3.        
        m,      // Milli 10**-3.        
        M,      // Mega 10**6.
        micro,  // Micro 10**-6.
        n,      // Nano 10**-9.
        none,   // No multiplier or equivalently multiply by 1.        
        p,      // Pico 10**-12.
        T       // Tera 10**12.
    }

    public enum UnitSymbol : short
    {        
        A = 0,  // Current in ampere.        
        deg,    // Plane angle in degrees.        
        degC,   // Relative temperature in degrees Celsius. In the SI unit system the symbol is ºC. Electric charge is measured in coulomb that has the unit symbol C. To destinguish degree Celsius form coulomb the symbol used in the UML is degC. Reason for not using ºC is the special character º is difficult to manage in software.        
        F,      // Capacitance in farad.        
        g,      // Mass in gram.        
        h,      // Time in hours.        
        H,      // Inductance in henry.        
        Hz,     // Frequency in hertz.       
        J,      // Energy in joule.       
        m,      // Length in meter.        
        m2,     // Area in square meters.        
        m3,     // Volume in cubic meters.        
        min,    // Time in minutes.        
        N,      // Force in newton.        
        none,   // Dimension less quantity, e.g. count, per unit, etc.        
        ohm,    // Resistance in ohm.        
        Pa,     // Pressure in pascal (n/m2).        
        rad,    // Plane angle in radians.        
        s,      // Time in seconds.        
        S,      // Conductance in siemens.        
        V,      // Voltage in volt.        
        VA,     // Apparent power in volt ampere.        
        VAh,    // Apparent energy in volt ampere hours.        
        VAr,    // Reactive power in volt ampere reactive.        
        VArh,   // Reactive energy in volt ampere reactive hours.        
        W,      // Active power in watt.        
        Wh      // Real energy in what hours.
    }

    public enum SwitchState : short
    {        
        close = 0,  // Switch is closed.       
        open        // Switch is open.
    }

    /* OLD ENUMs*/
    public enum PhaseCode : short
	{
		Unknown = 0x0,
		N = 0x1,
		C = 0x2,
		CN = 0x3,
		B = 0x4,
		BN = 0x5,
		BC = 0x6,
		BCN = 0x7,
		A = 0x8,
		AN = 0x9,
		AC = 0xA,
		ACN = 0xB,
		AB = 0xC,
		ABN = 0xD,
		ABC = 0xE,
		ABCN = 0xF
	}
	
	public enum TransformerFunction : short
	{
		Supply = 1,				// Supply transformer
		Consumer = 2,			// Transformer supplying a consumer
		Grounding = 3,			// Transformer used only for grounding of network neutral
		Voltreg = 4,			// Feeder voltage regulator
		Step = 5,				// Step
		Generator = 6,			// Step-up transformer next to a generator.
		Transmission = 7,		// HV/HV transformer within transmission network.
		Interconnection = 8		// HV/HV transformer linking transmission network with other transmission networks.
	}
	
	public enum WindingConnection : short
	{
		Y = 1,		// Wye
		D = 2,		// Delta
		Z = 3,		// ZigZag
		I = 4,		// Single-phase connection. Phase-to-phase or phase-to-ground is determined by elements' phase attribute.
		Scott = 5,   // Scott T-connection. The primary winding is 2-phase, split in 8.66:1 ratio
		OY = 6,		// 2-phase open wye. Not used in Network Model, only as result of Topology Analysis.
		OD = 7		// 2-phase open delta. Not used in Network Model, only as result of Topology Analysis.
	}

	public enum WindingType : short
	{
		None = 0,
		Primary = 1,
		Secondary = 2,
		Tertiary = 3
	}	
    /**/
}
