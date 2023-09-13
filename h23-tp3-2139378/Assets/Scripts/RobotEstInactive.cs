using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotEstInactive : EtatEnnemi
{
    public RobotEstInactive(GameObject obj) : base(obj)
    {
    }

    public override void Enter()
    {
        Animateur.SetBool("isInactive", true);
        Ennemi.isStopped = true;
    }

    public override void Handle(float deltaTime)
    {
        
    }

    public override void Leave()
    {
        
    }
}
