using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookFollowCamera : CameraBehaviour
{
    protected override void UpdateBehaviour()
    {
        transform.rotation = Quaternion.LookRotation(TargetPosition - transform.position);
    }
}
