using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChampSelectController : MonoBehaviour
{
    public Button SelectBtn;

    [SerializeField]
    private Image Displayer;
    [SerializeReference]
    private Text NameDisplayer;

    [SerializeField]
    private Sprite[] CharsDisplay;
    private String[] Names = new string[] {"Ely", "Serasi", "Elix", "Rogue", "Enigma", "Asaurus", "Trixy", "Leora", "Rhiannon"};

    private int pickedOne;

    public void onPickCharacter(int whichCharacter)
    {
        if (GamePreps.PI != null)
        {         
            GamePreps.PI.selectedCharacter = whichCharacter;
            PlayerPrefs.SetInt("selectedCharacter", whichCharacter);
        }

        pickedOne = whichCharacter;
    }

    public void onSelectCharacter()
    {
        Color cr1 = NameDisplayer.GetComponentInParent<Image>().color;
        cr1.a = 1;
        NameDisplayer.GetComponentInParent<Image>().color = cr1;
        NameDisplayer.text = Names[pickedOne];

        Displayer.sprite = CharsDisplay[pickedOne];
        Color cr2 = Displayer.color;
        cr2.a = 1;
        Displayer.color = cr2;
    }
}
