using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametrePartie 
{

    private static ParametrePartie _instance = new ParametrePartie();

    public static ParametrePartie Instance
    {
        get { return _instance; }
    }
    public string Nom1
    {
        set;
        get;
    }
    public string Nom2
    {
        set;
        get;
    }
    public float Point1
    {
        set;
        get;
    }
    public float Point2
    {
        set;
        get;
    }
    public int Tours
    {
        set;
        get;
    }
    private ParametrePartie()
    {
        Nom1 = "Bob";
        Nom2 = "Jimmy";
        Point1 = 8;
        Point2 = 8;
        Tours = 10;
    }
}
