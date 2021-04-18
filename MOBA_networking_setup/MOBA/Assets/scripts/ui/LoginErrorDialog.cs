using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EasyUI.Dialogs
{
    public class Dialog
    {
        public string errorMessage;
    }

    public class LoginErrorDialog : MonoBehaviour
    {
        [SerializeField] GameObject dialogCanvas;
        [SerializeField] Text errorMsgDisplay;
        [SerializeField] Button closeBtn;
        [SerializeField] Button bigCloseBtn;

        Dialog dialog = new Dialog();

        //singleton pattern
        public static LoginErrorDialog popInstance;


        private void Awake()
        {
            popInstance = this;
        }

        //set error name
        public LoginErrorDialog setErrorMsg(string errorMsg)
        {
            dialog.errorMessage = errorMsg;
            return popInstance;
        }

        //show popup
        public void show()
        {
            errorMsgDisplay.text = dialog.errorMessage;
            dialogCanvas.SetActive(true);
        }

        //hide popup
        public void hide()
        {
            dialogCanvas.SetActive(false);
            //reset dialog (just in case)
            dialog = new Dialog();
        }

    }
}
