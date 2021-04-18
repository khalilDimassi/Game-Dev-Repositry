using UnityEngine;

public class GamePreps : MonoBehaviour
{
    public static GamePreps PI;

    public int selectedCharacter;
    public int selectedSkin;

    public GameObject[] allCharacters;
    public Color[] allSkins;

    private void OnEnable()
    {
        if (GamePreps.PI == null)   GamePreps.PI = this;
        else if (GamePreps.PI != this)
        {
            Destroy(GamePreps.PI.gameObject);
            GamePreps.PI = this;
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("selectedCharacter")) selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        else
        {
            selectedCharacter = 0;
            PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        }

        if (PlayerPrefs.HasKey("selectedSkin")) selectedSkin = PlayerPrefs.GetInt("selectedSkin");
        else
        {
            selectedSkin = 0;
            PlayerPrefs.SetInt("selectedSkin", selectedSkin);
        }
    }

}
