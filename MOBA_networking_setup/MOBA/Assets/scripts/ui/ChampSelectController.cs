using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampSelectController : MonoBehaviour
{
    public void onPickCharacter(int whichCharacter)
    {
        if (GamePreps.PI != null)
        {
            GamePreps.PI.selectedCharacter = whichCharacter;
            PlayerPrefs.SetInt("selectedCharacter", whichCharacter);
            Debug.LogError("character selected: " + GamePreps.PI.allCharacters[whichCharacter].name);
        }
    }
}
