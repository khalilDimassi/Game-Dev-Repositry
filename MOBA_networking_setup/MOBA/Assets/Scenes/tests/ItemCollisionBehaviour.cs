using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollisionBehaviour : MonoBehaviour
{
    [SerializeField]
    public string[] collidedWith = {};


    void onControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit != null)
        {
            print("i hit :" + hit.transform.tag);
        }
    }


}
