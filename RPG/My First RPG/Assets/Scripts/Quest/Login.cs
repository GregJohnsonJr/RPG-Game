using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour {

    public string inputUsername;
    public string inputPassword;
    string LoginURL = "https://gregjohn.000webhostapp.com/Login.php";
    // Use this for initialization
    void Start () {
		
	}
	// So we went to this 000website to create a database
    // we used the data inthere to make the database online and store are information there using php and stuff
    //now that it is online we can access it from anywhere!
	// Update is called once per frame
	void Update () {
       if(Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(LoginToDB(inputUsername, inputPassword));                      
        }
	}
    IEnumerator LoginToDB(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        WWW www = new WWW(LoginURL, form);
        yield return www;
        Debug.Log(www.text);
    }
}
