using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMvts : Bolt.EntityBehaviour<IcustomSphereS>
{
    //void start():
    public override void Attached()
    {
        state.SetTransforms(state.playerTransform, transform);
    }

    //void update():
    public override void SimulateOwner()
    {
        var speed = 4f;
        var mvtDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.Q))
        {
            mvtDirection.x -= 1f; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            mvtDirection.x += 1f; 
        }
        if (Input.GetKey(KeyCode.Z))
        {
            mvtDirection.z += 1f; 
        }
        if (Input.GetKey(KeyCode.S))
        {
            mvtDirection.z -= 1f; 
        }

        if (mvtDirection != Vector3.zero)
        {
            transform.position = transform.position + (mvtDirection.normalized * speed * BoltNetwork.FrameDeltaTime);
        }
    }
}
