using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DbManager 
{
    public static string username;
    public static string userInfo;

    public static bool loggedIn { get { return username != null; } }
    public static void logOut()
    {
        username = null;
        userInfo = null;
    }


}
