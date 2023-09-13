using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Comparers;
using UnityEngine.EventSystems;

public class OuverturePortes : MonoBehaviour
{

    [SerializeField] private GameObject _porteDroite;
    [SerializeField] private GameObject _porteGauche;

    private bool _ouvert;
    private bool proche;
    private Coroutine _deplacerPorte;
    private Coroutine _deplacerPorteGuache;
    // Start is called before the first frame update
    void Start()
    {
        _ouvert = false;
        proche = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r") && proche)
        {
            _deplacerPorte = StartCoroutine(DeplacerPorteLaPorte());
            _deplacerPorteGuache = StartCoroutine(DeplacerPorteLaPorteGauche());
            _ouvert = true;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            proche = true;
        }

    }
    private IEnumerator DeplacerPorteLaPorteGauche()
    {
        bool termine = false;
        while (!termine)
        {
            Vector3 positionFinale = new Vector3(6.0f, _porteDroite.transform.localPosition.y, _porteDroite.transform.localPosition.z);
            Vector3 positionActuelle = _porteDroite.transform.localPosition;
            float distance = Vector3.Distance(positionActuelle, positionFinale);
            if (distance>=0.01f) {
                Vector3 direction = positionFinale - positionActuelle;
                direction = direction.normalized;
                
                _porteDroite.transform.Translate(direction * 10.0f * Time.fixedDeltaTime);

                yield return new WaitForFixedUpdate();
            } else
            {
                _porteDroite.transform.localPosition = positionFinale;
                termine = true;
            }
        }
        yield return new WaitForFixedUpdate();
    }
    private IEnumerator DeplacerPorteLaPorte()
    {
        bool termine = false;
        while (!termine)
        {
            Vector3 positionFinale = new Vector3(-6.0f, _porteGauche.transform.localPosition.y, _porteGauche.transform.localPosition.z);
            Vector3 positionActuelle = _porteGauche.transform.localPosition;
            float distance = Vector3.Distance(positionActuelle, positionFinale);
            if (distance <= 0.01f)
            {
                Vector3 direction = positionFinale - positionActuelle;
                direction = direction.normalized;

                _porteGauche.transform.Translate(direction * 10.0f * Time.fixedDeltaTime);

                yield return new WaitForFixedUpdate();
            }
            else
            {
                _porteGauche.transform.localPosition = positionFinale;
                termine = true;
            }
        }
        yield return new WaitForFixedUpdate();
    }

    public void OuvrirPorte()
    {
        Debug.Log(proche);
        if (proche)
        {
            _deplacerPorte = StartCoroutine(DeplacerPorteLaPorte());
            _deplacerPorteGuache = StartCoroutine(DeplacerPorteLaPorteGauche());
            _ouvert = true;
        }
    }

}
