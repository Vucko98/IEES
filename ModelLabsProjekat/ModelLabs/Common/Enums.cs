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
}
