using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraBalle : MonoBehaviour
{
    [SerializeField] GameObject balle;
    private Vector3 _positionInitialeBalle;
    private float differenceDistance;
    private GameObject _camera;
    
    public GameObject CameraActive
    {
        set 
        { 
            _camera = value; 
        }
        get 
        { 
            return _camera; 
        } 
    }

    public GameObject BalleActive
    {
        set
        {
            balle = value;
        }
        get
        {
            return balle;
        }
    }
    void Start()
    {
        _positionInitialeBalle = BalleActive.transform.position;
        differenceDistance = transform.localPosition.x - _positionInitialeBalle.x;
        PlacerCamera();
    }

    // Update is called once per frame
    void Update()
    {
        PlacerCamera();
    }

    private void PlacerCamera()
    {
        float x = BalleActive.transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        float positionRelative = x + differenceDistance;

        if (BalleActive.transform.position.x < 120f && BalleActive.transform.position.x >82f)
        {
            transform.localPosition= new Vector3(positionRelative, y, z);

        }
    }
}
