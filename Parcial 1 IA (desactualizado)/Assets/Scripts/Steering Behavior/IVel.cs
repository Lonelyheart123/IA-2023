using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVel
{
    //Magnitud
    float GetVel { get; }
    //Dir N
    Vector3 GetFoward { get; }
}
