using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getUser : MonoBehaviour {

    string userName = null;
    public InputField txtUserName;

    public void getUserName()
    {
        userName = txtUserName.text;

        if (userName.Length > 0)
        {
            Debug.Log(userName);
            Datos.UserName = userName;
        }

        else
        {
            userName = "anonymous";
            Debug.Log(userName);
            Datos.UserName = userName;
        }
    }
}
