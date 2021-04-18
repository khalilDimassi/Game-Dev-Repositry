using System;
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
        }
    }
    public void onPickSkin(int whichskin)
    {
        if (GamePreps.PI != null)
        {         
            GamePreps.PI.selectedSkin = whichskin;
            PlayerPrefs.SetInt("selectedSkin", whichskin);
        }
    }
}
