using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotEnMarche : EtatEnnemi
{
    public RobotEnMarche(GameObject obj) : base(obj)
    {
    }

    public override void Enter()
    {
        Animateur.SetBool("isWalking", true);
    }

    public override void Handle(float deltaTime)
    {
       
    }

    public override void Leave()
    {
        Animateur.SetBool("isWalking", false);
    }
}

