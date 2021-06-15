using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    private GameObject objToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void ontriggerEnter(Collider other)
    { 
        if (other.tag == "player")
        {
            Destroy(objToDestroy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
