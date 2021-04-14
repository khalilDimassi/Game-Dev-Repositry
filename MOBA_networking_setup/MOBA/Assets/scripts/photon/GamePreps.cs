using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePreps : MonoBehaviour
{
    public static GamePreps PI;

    public int selectedCharacter;
    public GameObject[] allCharacters;

    private void OnEnable()
    {
        if (GamePreps.PI == null)   GamePreps.PI = this;
        else if (GamePreps.PI != this)
        {
            Destroy(GamePreps.PI.gameObject);
            GamePreps.PI = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("selectedCharacter")) selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        else
        {
            selectedCharacter = 0;
            PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        }
    }

}
