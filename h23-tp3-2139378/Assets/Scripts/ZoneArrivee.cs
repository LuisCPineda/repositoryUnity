using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneArrivee : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        print("�ve est entr� dans zone d'arriv�e");
        
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
