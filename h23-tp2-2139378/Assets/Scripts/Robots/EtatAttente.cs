using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatAttente : EtatRobot
{
    private float _tempAttente;

    public EtatAttente(MouvementRobot1 robot, GameObject joueur) : base(robot, joueur)
    {
        _tempAttente = 0.0f;
    }

    public override void Enter()
    {
        _tempAttente = UnityEngine.Random.Range(3.0f, 5.0f);
        AgentMouvement.destination = Robot.transform.position;
    }

    public override void Handle(float deltaTime)
    {
        _tempAttente -= deltaTime;
        if (_tempAttente < 0.0f)
        {
            MouvementRobot1 mouvement = Robot.GetComponent<MouvementRobot1>();
            mouvement.ChangerEtat(mouvement.Patrouille);
        }
        else if (JoueurVisible())
        {
            MouvementRobot1 mouvement = Robot.GetComponent<MouvementRobot1>();
            mouvement.ChangerEtat(mouvement.Poursuite);
        }
    }

    public override void Leave()
    {
    }
}
