using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject balle;
    //[SerializeField] private TMP_Text champPoints;
    [SerializeField] private ZoneAuFond zone;
    [SerializeField] private CameraBalle scriptCamera;
    [SerializeField] private GameObject laCamera;
    [SerializeField] private QuillesAbattues scriptQuille0;
    [SerializeField] private QuillesAbattues scriptQuille1;
    [SerializeField] private QuillesAbattues scriptQuille2;
    [SerializeField] private QuillesAbattues scriptQuille3;
    [SerializeField] private QuillesAbattues scriptQuille4;
    [SerializeField] private QuillesAbattues scriptQuille5;
    [SerializeField] private QuillesAbattues scriptQuille6;
    [SerializeField] private QuillesAbattues scriptQuille7;
    [SerializeField] private QuillesAbattues scriptQuille8;
    [SerializeField] private QuillesAbattues scriptQuille9;
    [SerializeField] private TMP_Text champPoints;


    private Vector3 _positionDepartBalle;
    private Vector3 _positionDepartCamera;
    private int quillesAba;


    void Start()
    {
        zone.ZoneAtteinteHandler += ReplacerCamera;
        zone.ZoneAtteinteHandler += ReplacerBalle;
        scriptQuille0.QuilleAbattueTriggerHandler += CompterQuillesAbattues;
        scriptQuille1.QuilleAbattueTriggerHandler += CompterQuillesAbattues;
        scriptQuille2.QuilleAbattueTriggerHandler += CompterQuillesAbattues;
        scriptQuille3.QuilleAbattueTriggerHandler += CompterQuillesAbattues;
        scriptQuille4.QuilleAbattueTriggerHandler += CompterQuillesAbattues;
        scriptQuille5.QuilleAbattueTriggerHandler += CompterQuillesAbattues;
        scriptQuille6.QuilleAbattueTriggerHandler += CompterQuillesAbattues;
        scriptQuille7.QuilleAbattueTriggerHandler += CompterQuillesAbattues;
        scriptQuille8.QuilleAbattueTriggerHandler += CompterQuillesAbattues;
        scriptQuille9.QuilleAbattueTriggerHandler += CompterQuillesAbattues;
        _positionDepartBalle = balle.transform.position;
        _positionDepartCamera= laCamera.transform.position;
        quillesAba = 0;
    }

    private void OnGUI()
    {
        champPoints.text = quillesAba.ToString();
    }

    private void ReplacerBalle() 
    {
        GameObject nouvelleBalle = GameObject.Instantiate(balle);
        nouvelleBalle.transform.localPosition = _positionDepartBalle;
        nouvelleBalle.transform.rotation=new Quaternion(0,0,0,0);
        zone.BalleActive = nouvelleBalle;
        scriptCamera.BalleActive = nouvelleBalle;
        Destroy(balle.GetComponent<MouvementBoule>());
        balle = nouvelleBalle;
    }
    private void ReplacerCamera()
    {
        GameObject nouvelleCamera = Camera.Instantiate(laCamera);
        nouvelleCamera.transform.localPosition = _positionDepartCamera;
        scriptCamera.CameraActive = nouvelleCamera;
        Destroy(laCamera.GetComponent<CameraBalle>());
        laCamera = nouvelleCamera;
    }
    private void CompterQuillesAbattues()
    {
        Debug.Log("Abattue");
        quillesAba++;
    }
}
