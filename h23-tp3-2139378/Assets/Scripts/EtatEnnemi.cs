using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EtatEnnemi 
{
    public MouvementRobot MR
    {
        private set;
        get;
    }

    public Animator Animateur
    {
        private set;
        get;
    }

    public NavMeshAgent Ennemi
    {
        private set;
        get;
    }

    public EtatEnnemi(GameObject obj)
    {
        MR = obj.GetComponent<MouvementRobot>();
        Animateur = obj.GetComponent<Animator>();
        Ennemi = obj.GetComponent<NavMeshAgent>();
    }

    public abstract void Enter();
    public abstract void Handle(float deltaTime);
    public abstract void Leave();
}
