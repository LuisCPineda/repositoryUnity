using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChaquePorte : MonoBehaviour
{
    public bool proche;
    public GameObject joueur;
    // Start is called before the first frame update
    void Start()
    {
        proche = false;
        joueur=null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!proche) 
        {
            joueur = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Joueur est entré dans zone");
        if (other.gameObject.CompareTag("PlayerCharacter"))
        {
            proche = true;
            joueur=other.gameObject; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        print("Joueur est sorti de la zone");
        if (other.gameObject.CompareTag("PlayerCharacter"))
        {
            proche = false;
            joueur = other.gameObject;
        }
    }
}
