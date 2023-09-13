using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteGauche : MonoBehaviour
{
    private bool _ouvert;
    private bool proche;
    private Coroutine _deplacerPorte;
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
    private IEnumerator DeplacerPorteLaPorte()
    {
        bool termine = false;
        while (!termine)
        {
            Vector3 positionFinale = new Vector3(-6.0f, transform.localPosition.y, transform.localPosition.z);
            Vector3 positionActuelle = transform.localPosition;
            float distance = Vector3.Distance(positionActuelle, positionFinale);
            if (distance <= 0.01f)
            {
                Vector3 direction = positionFinale - positionActuelle;
                direction = direction.normalized;

                transform.Translate(direction * 10.0f * Time.fixedDeltaTime);

                yield return new WaitForFixedUpdate();
            }
            else
            {
                transform.localPosition = positionFinale;
                termine = true;
            }
        }
        yield return new WaitForFixedUpdate();
    }
}
