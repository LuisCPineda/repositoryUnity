using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouvementJoueur : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private Vector3 _position;
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_agent.pathPending)
        {
            if (Input.GetMouseButtonDown(0))
            {

                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    _agent.destination = hit.point;
                    _position = hit.point;
                    _animator.SetBool("Walking", true);
                }
            }
            if (_position.x == _transform.position.x && _position.z == _transform.position.z)
            {
                _animator.SetBool("Walking", false);
            }
        }
    }
}
