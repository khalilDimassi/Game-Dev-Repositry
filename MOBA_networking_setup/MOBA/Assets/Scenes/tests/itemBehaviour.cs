using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBehaviour : MonoBehaviour
{
    [SerializeField]
    private string designation;
    [SerializeField]
    public SphereCollider detectionZone;
    [SerializeField]
    private string collidedPlayer = "none";

    void Start()
    {
        detectionZone.isTrigger = true;
        collidedPlayer = "none";
    }

    void onCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "character")
        {
            collidedPlayer = other.gameObject.name;
            Destroy(gameObject);
        }
    }
}
