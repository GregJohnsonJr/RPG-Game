using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FinalizeCharacterSelection : MonoBehaviour
{
    public Text characterName;
    public Text characterDesc;
    // Start is called before the first frame update
    public void SetNameAndDesc()
    {
        GameInformation.PlayerName = characterName.text;
        GameInformation.PlayerBio = characterDesc.text;
        //Load next scene and Initialize Game information
    }
}
