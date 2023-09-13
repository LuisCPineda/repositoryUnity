using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiberationPrisonnier : MonoBehaviour
{
    private Animator _animator;
    private GameObject gameManager;
    private GestionnairePersonnages personnages;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("Saved", false);
        gameManager = GameObject.FindGameObjectWithTag("gameManager");
        personnages = gameManager.GetComponent<GestionnairePersonnages>();
    }

    public void OnTriggerEnter(Collider other)
    {
        _animator.SetBool("Saved", true);
        if (other.gameObject.CompareTag("PlayerCharacter"))
        {
            _animator.SetBool("Idle", true);
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity=false;
        }
        //StartCoroutine(EndGame());
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Victoire");
    }
}
