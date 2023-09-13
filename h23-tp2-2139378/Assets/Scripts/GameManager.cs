using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance ;
    public static GameManager Instance
    {
        get { return _instance; }
    }
    
    [SerializeField] public TMP_Text nomAgent;
    [SerializeField] private TMP_Text _point1;
    [SerializeField] private TMP_Text _point2;
    
    
    private void Start()
    {
        nomAgent.text = Nom1;
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
    private void Update()
    {
        
    }
    public GameManager()
    {
        Nom1 = "Bob";
        Nom2 = "Jimmy";
        Point1 = 8;
        Point2 = 8;
        Tours = 10;
    }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    private void OnGUI()
    {
        nomAgent.text = Nom1;
        _point1.text = Point1.ToString();
        _point2.text = Point2.ToString();
    }

}
