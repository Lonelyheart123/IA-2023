using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : Pursuit
{
    public Evade(Transform entity, EntityBase target, float predictionTime) : base (entity, target, predictionTime)
    {

    }
    public override Vector3 GetDir()
    {
        return -base.GetDir();
    }
}