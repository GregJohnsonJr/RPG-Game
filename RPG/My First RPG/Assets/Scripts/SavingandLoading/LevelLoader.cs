using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {
    public GameObject loadingScreen;
    public Slider slider;
    bool isChecked = false;
    float progress;
	public void LoadLevel(int sceneIndex)
    {
        // 
        
        StartCoroutine(LoadAsynchronoulsy(sceneIndex));
        // continually updates ui to show this, courtines also
       
    }

    IEnumerator LoadAsynchronoulsy(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        if(!isChecked)
        {
            slider.value = 0;
            isChecked = true;
        }
        while(!operation.isDone)
        {
            progress = Mathf.Clamp01(operation.progress / .9f);
            if (operation.progress == 0.9f)
            {
                slider.value = 1;
            }
            else if (operation.progress < 0.9f)
            {
                slider.value = operation.progress;
            }
            Debug.Log(progress);
            yield return null;
        }

    }
}
