using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using EasyUI.Dialogs;
using System;

public class Login : MonoBehaviour
{
    public int ProfileMenuSceneIndex;

    public InputField nameField;
    public InputField passField;
    public Button submitBtn;


    [SerializeField] GameObject dialogCanvas;
    [SerializeField] Text errorMsgDisplay;
    [SerializeField] Button closeBtn;


    IEnumerator loggingIn(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/GameDevRep/MOBA_networking_setup/players_accounts/loginRequest.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("user Login failed. Error number " + www.downloadHandler.text);
            }
            else
            {
                if (www.downloadHandler.text.Split('\t')[0] != "0")
                {
                    //displaying popup
                    errorMsgDisplay.text = www.downloadHandler.text; ;
                    dialogCanvas.SetActive(true);
                }
                else
                {
                    DbManager.userInfo = www.downloadHandler.text.Split('\t');
                    DbManager.username = DbManager.userInfo[11];
                    SceneManager.LoadScene(ProfileMenuSceneIndex);
                }
            }
        }
    }

    public void callLogin()
    {
        StartCoroutine(loggingIn(nameField.text, passField.text));
        
    }

    public void hide()
    {
        dialogCanvas.SetActive(false);
        //reset dialog (just in case)
        errorMsgDisplay.text = "";
    }

    private void Awake()
    {
        if (dialogCanvas.activeSelf)
        {
            dialogCanvas.SetActive(false);
        }
    }

    private void Update()
    {
        if ((nameField.text != "") && (passField.text != ""))
        {
            submitBtn.interactable = true;
        }
    }
}
