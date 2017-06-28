using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Datos2
{
    private static int _hueHigh;

    public static int _HueHigh
    {
        get
        {
            return Datos2._hueHigh;
        }
        set
        {
            Datos2._hueHigh = value;
        }
    }


    private static int _hueLow;

    public static int _HueLow
    {
        get
        {
            return Datos2._hueLow;
        }
        set
        {
            Datos2._hueLow = value;
        }
    }


    private static int _satHigh;

    public static int _SatHigh
    {
        get
        {
            return Datos2._satHigh;
        }
        set
        {
            Datos2._satHigh = value;
        }
    }

    private static int _satLow;

    public static int _SatLow
    {
        get
        {
            return Datos2._satLow;
        }
        set
        {
            Datos2._satLow = value;
        }
    }
}

