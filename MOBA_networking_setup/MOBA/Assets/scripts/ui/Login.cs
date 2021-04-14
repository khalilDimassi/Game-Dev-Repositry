using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passField;

    public Button submitBtn;

    public void callLogin()
    {
        StartCoroutine(loggingIn(nameField.text, passField.text));
    }

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
                Debug.Log("user Login failed. Error number #: " + www.downloadHandler.text);
            }
            else
            {
                DbManager.username = nameField.text;
                DbManager.userInfo = www.downloadHandler.text.Split('\t');
                UnityEngine.SceneManagement.SceneManager.LoadScene(2);
            }
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
