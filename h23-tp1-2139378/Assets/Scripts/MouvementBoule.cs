
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementBoule : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject cible;
    private Rigidbody _rbody;
    private float _horizontal;
    private bool _tirerBalle;
    private Vector3 _positionInitiale;
    private Vector3 _directionCible;
    private float angleBalleCible;


    public Vector3 PositionInitiale
    {
        set 
        { 
            _positionInitiale = value; 
        }
        get 
        { 
            return _positionInitiale; 
        }
    }
    private void Awake()
    {
        _rbody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        PositionInitiale = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");    
        _tirerBalle = Input.GetKey("space");
        _directionCible = cible.transform.position - transform.position;
        
    }
    void FixedUpdate()
    {
        
        Vector3 deplacerBalle = new Vector3(0, 0, _horizontal);
        Vector3 forceApplicable = deplacerBalle * 5 * Time.deltaTime;
        transform.Translate(forceApplicable);
        
        if (_tirerBalle && transform.position.x > 119f)
        {
            int valeur = Random.Range(-5,5);
            Vector3 tirerBalle = new Vector3(-4, 0, (_directionCible.z/10)-(valeur/5));
            Debug.Log(valeur);
            Vector3 forceTirer = tirerBalle * 2000;
            _rbody.AddForce(forceTirer);
        }

    }
}
