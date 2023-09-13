using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementCible : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _keyZ;
    private bool _kyeX;
    private Vector3 _positionInitiale;

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
    void Start()
    {
        PositionInitiale = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _keyZ = Input.GetKey("z");
        _kyeX = Input.GetKey("x");
    }
    void FixedUpdate()
    {
        if (_keyZ && transform.position.z > -2f) 
        {
            Vector3 deplacerBalle = new Vector3(0, 0, -1);
            Vector3 forceApplicable = deplacerBalle * 10 * Time.deltaTime;
            transform.Translate(forceApplicable);
        }
        if (_kyeX && transform.position.z < 2f) 
        {
            Vector3 deplacerBalle = new Vector3(0, 0, 1);
            Vector3 forceApplicable = deplacerBalle * 10 * Time.deltaTime;
            transform.Translate(forceApplicable);
        }
    }
}
