using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void QuilleAbattueTrigger();
public class QuillesAbattues : MonoBehaviour
{
    public event QuilleAbattueTrigger QuilleAbattueTriggerHandler;
    // Start is called before the first frame update
    [SerializeField] private GameObject balleActive;
    private Vector3 _positionDepart;
    private Quaternion _rotationDepart;
    private bool _abattue;
    public GameObject BalleActive
    {
        set
        {
            balleActive = value;
        }
        get
        {
            return balleActive;
        }
    }
    void Start()
    {
        _positionDepart=transform.position;
        _rotationDepart=transform.rotation;
        _abattue=false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if ((transform.rotation.z != _rotationDepart.z || transform.rotation.x != _rotationDepart.x)
            &&!_abattue)
        {
            _abattue = true;
            QuilleAbattueTriggerHandler();
        }

    }
}
