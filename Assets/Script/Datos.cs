using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class Datos
{
    private static string userName;

    public static string UserName
    {
        get
        {
            return Datos.userName;
        }
        set
        {
            Datos.userName = value;
        }
    }

    private static int cantidad;

    public static int Cantidad
    {
        get
        {
            return Datos.cantidad;
        }
        set
        {
            Datos.cantidad= value;
        }
    }

    private static int score;

    public static int Score
    {
        get
        {
            return Datos.score;
        }
        set
        {
            Datos.score = value;
        }
    }

    private static string pathXmlGlobal;

    public static string PathXmlGlobal
    {
        get
        {
            return Datos.pathXmlGlobal;
        }
        set
        {
            Datos.pathXmlGlobal = value;
        }
    }

    private static int minX;

    public static int MinX
    {
        get
        {
            return Datos.minX;
        }
        set
        {
            Datos.minX = value;
        }
    }

    private static int maxX;

    public static int MaxX
    {
        get
        {
            return Datos.maxX;
        }
        set
        {
            Datos.maxX = value;
        }
    }

}
