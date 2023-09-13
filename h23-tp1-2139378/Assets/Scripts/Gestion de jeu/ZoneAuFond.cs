using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void ZoneAtteinte();
public class ZoneAuFond : MonoBehaviour
{
    public event ZoneAtteinte ZoneAtteinteHandler;

    [SerializeField] private GameObject balleActive;
 

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
    

    private IEnumerator ReplacerBalle()
    {
        yield return new WaitForSeconds(3);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == balleActive) 
        {
            if (ZoneAtteinteHandler!= null) 
            {
                ReplacerBalle();
                ZoneAtteinteHandler();
            }
        }
    }
}
