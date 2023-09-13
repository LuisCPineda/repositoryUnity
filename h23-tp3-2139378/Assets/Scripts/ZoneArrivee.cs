using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneArrivee : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        print("Ève est entré dans zone d'arrivée");
        
        if (other.gameObject.name== "PersonnageRouge")
        {
            StartCoroutine(EndGame());
        }   
    }
    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Victoire");
    }
}
