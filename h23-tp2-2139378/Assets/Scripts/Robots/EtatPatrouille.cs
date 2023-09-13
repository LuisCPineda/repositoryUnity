using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtatPatrouille : EtatRobot
{
    private Transform[] _points;
    private int _indexPatrouille;

    public EtatPatrouille(MouvementRobot1 robot, GameObject joueur, Transform[] points) : base(robot, joueur)
    {
        _points = points;
        _indexPatrouille = 0;
    }


    public override void Enter()
    {
        Animateur.SetBool("Walking", true);
    }

    public override void Handle(float deltaTime)
    {
        if (!AgentMouvement.pathPending)
        {
            if (AgentMouvement.remainingDistance <= 0.1f)
            {
                AgentMouvement.destination = _points[_indexPatrouille].position;
                _indexPatrouille = (_indexPatrouille + 1) % _points.Length;
            }
        }

        if (JoueurVisible())
        {
            MouvementRobot1 mouvement = Robot.GetComponent<MouvementRobot1>();
            mouvement.ChangerEtat(mouvement.Poursuite);
        }

    }

    public override void Leave()
    {
        Animateur.SetBool("Walking", false);
    }
}
