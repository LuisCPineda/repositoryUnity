using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotImmobile : EtatEnnemi
{
    public RobotImmobile(GameObject obj) : base(obj)
    {
    }

    public override void Enter()
    {
        Animateur.SetBool("isWalking", false);
        Animateur.SetBool("isInactive", false);
        Ennemi.isStopped = true;
    }

    public override void Handle(float deltaTime)
    {
        
    }

    public override void Leave()
    {
        Ennemi.isStopped = false;
    }
}
