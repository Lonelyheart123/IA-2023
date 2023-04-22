using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : Seek
{
    public Flee(Transform entity, Transform target): base(entity, target)
    {

    }

    public override Vector3 GetDir()
    {
        return -base.GetDir();
    }
}
