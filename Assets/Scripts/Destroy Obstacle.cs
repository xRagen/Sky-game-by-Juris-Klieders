using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacle : BaseObstacle
{
    internal override void OnHit()
    {
        base.OnHit();
        Destroy(gameObject);
    }

}
