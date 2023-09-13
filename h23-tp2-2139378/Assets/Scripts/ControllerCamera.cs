using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class ControllerCamera : MonoBehaviour
{
    private CharacterController _characterController;
    private float _vitesse;
    //private Vector3 _positionCentre;
    
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _vitesse = 15.0f;
        //_positionCentre = new Vector3(transform.position.x,0.0f,transform.position.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * _vitesse * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * _vitesse * Time.deltaTime;

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        _characterController.Move(direction);
        
        
        if (Input.GetKeyDown("e"))
        {
            transform.Rotate(0, -90.0f, 0);
        }
        if (Input.GetKeyDown("q"))
        {
            transform.Rotate(0, 90.0f , 0);
        }

    }

}
