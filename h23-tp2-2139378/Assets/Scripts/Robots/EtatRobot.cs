using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EtatRobot 
{
    public MouvementRobot1 Robot
    {
        set;
        get;
    }
    public GameObject Joueur
    {
        set;
        get;
    }

    public NavMeshAgent AgentMouvement
    {
        set;
        get;
    }

    public Animator Animateur
    {
        set;
        get;
    }

    public EtatRobot(MouvementRobot1 robot, GameObject joueur)
    {
        Robot = robot;
        Joueur = joueur;
        AgentMouvement = robot.GetComponent<NavMeshAgent>();
        Animateur = robot.GetComponent<Animator>();
    }

    protected bool JoueurVisible()
    {
        bool visible = false;
        RaycastHit hit;

        Vector3 positionJoueur = new Vector3(Joueur.transform.position.x, 0.5f, Joueur.transform.position.z);
        Vector3 positionSquelette = new Vector3(Robot.transform.position.x, 0.5f, Robot.transform.position.z);
        Vector3 directionJoueur = positionJoueur - positionSquelette;

        
        if (Physics.Raycast(positionSquelette, directionJoueur, out hit))
        {
            if (hit.transform == Joueur.transform)
            {
                // Il n'y a pas d'obstacle, on vérifie l'angle
                float angle = Vector3.Angle(Robot.transform.forward, directionJoueur);
                visible = angle <= 60.0f;
            }
        }

        return visible;
    }

    public abstract void Enter();
    public abstract void Handle(float deltaTime);
    public abstract void Leave();
}
