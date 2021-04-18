using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] public GameObject myCharacter;
    public int localHealth;

    [SerializeField] public Text healthDisplay;

    // Start is called before the first frame update
    void Start()
    {
        localHealth = myCharacter.GetComponent<AvatarSetup>().playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (localHealth != int.Parse(healthDisplay.text))
        {
            healthDisplay.text = localHealth.ToString();
        }
    }
}
