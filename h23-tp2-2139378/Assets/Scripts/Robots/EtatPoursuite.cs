using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatPoursuite : EtatRobot
{
    public EtatPoursuite(MouvementRobot1 robot, GameObject joueur) : base(robot, joueur)
    {

    }

    public override void Enter()
    {
        Animateur.SetBool("Walking", true);
    
        
        AgentMouvement.destination = Joueur.transform.position;  
    }

    public override void Handle(float deltaTime)
    {
        bool attaque_requise = false;
        if (!JoueurVisible())
        {
            MouvementRobot1 mouvement = Robot.GetComponent<MouvementRobot1>();
            mouvement.ChangerEtat(mouvement.Attente);
        }
        else
        {
            AgentMouvement.destination = Joueur.transform.position;
            //Reviser position d'attaque
            attaque_requise = Vector3.Distance(Robot.transform.position, Joueur.transform.position) <= 2.0f;
        }
        Debug.Log("Defait");
        //Animateur.SetBool("Attack", attaque_requise);
    }

    public override void Leave()
    {
        Animateur.SetBool("Walking", false);

    }
}
