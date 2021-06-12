using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void ontriggerEnter(collider other)
    { if (other.tag == "player")
        {
            Destroy(objToDestroy);
        }
        Destroy
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
