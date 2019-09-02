using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInserter : MonoBehaviour {

    public string inputUserName;
    public string inputPassword;
    public string inputEmail;

    string createUserURL = "https://gregjohn.000webhostapp.com/InsertUser.php";
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateUser(inputUserName, inputPassword, inputEmail);
            Debug.Log("Uploaded");
        }
	}
    public void CreateUser(string username, string password, string email)
    {
        // a class that allows us to send a form to a php
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        form.AddField("emailPost", email);

        WWW www = new WWW(createUserURL,form);
    }
}
