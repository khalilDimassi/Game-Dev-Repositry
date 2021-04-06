using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passField;

    public Button submitBtn;

    public void callLogin()
    {
        StartCoroutine(loggingIn());
    }

   
    IEnumerator loggingIn()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", nameField.text);
        form.AddField("password", passField.text);

        
        WWW www = new WWW("http://localhost/GameDevRep/MOBA_networking_setup/players_accounts/server_conn.php", form);
        yield return www;

        if (www.text[0] == '0')
        {
            DbManager.username = nameField.text;
            DbManager.userInfo = www.text.Split('\t');
            UnityEngine.SceneManagement.SceneManager.LoadScene(2); 
            
        }
        else
        {
            Debug.Log("user Login failed. Error number #: " + www.text);
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
