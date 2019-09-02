using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// OBSOLETE FOUND A BETTER WAY TO USE FLOATING TEXT
[System.Obsolete]
public class FloatingText : MonoBehaviour {
    public Text text;
    bool isFlying = false;
    List<GameObject> flyingText;
    GameObject temporary;
    bool isWaiting = false;
    //When you are hit, create a floating text object above the player with a specific color
    // Color changes whether it is a heal or damage.
    // The text is then sent flying and once it reaches a certain height it is destroyed.
    // That should work for floating text
    //Going to be for all kinds of attacks
    //
    private void Awake()
    {
        flyingText = new List<GameObject>();
        if(text && text.GetComponent<Animator>())
        text.GetComponent<Animator>().enabled = false;
    }
    void Initalized()
    {

    }
    private void Update()
    {    
        if (flyingText.Count > 0 && !isWaiting)
        {
          
            StartCoroutine(Destroy());
        }
        else if(flyingText.Count > 0)
        {
            for (int i = 0; i < flyingText.Count; i++)
            {
                if (flyingText[i])
                {
                    if (!flyingText[i].GetComponent<Animation>().IsPlaying("FloatingText"))
                    {
                        Destroy(flyingText[i]);
                        flyingText.RemoveAt(i);
                        
                    }
                    if (flyingText.Count > i)
                    {
                        flyingText[i].transform.LookAt(Camera.main.transform);
                        flyingText[i].transform.localEulerAngles += new Vector3(-flyingText[i].transform.localEulerAngles.x, 180f, -flyingText[i].transform.localEulerAngles.z);
                    }
                    //Debug.DrawRay(transform.position, newDir, Color.red);
                    // Move our position a step closer to the target.4
                    // Rotating it with the player is a little much because the player always rotates i have to rotate with the camera view maybe...
                    //newDir.y += 180f;
                    // newDir.x = 0;
                    // newDir = GameObject.FindGameObjectWithTag("Player").transform.eulerAngles;
                    //flyingText[i].transform.localRotation = Quaternion.LookRotation(newDir);
                    //flyingText[i].GetComponent<RectTransform>().eulerAngles = newDir;

                }
                
            }
        }
       
    }
    //I need a method to destroy all the objects in the list at a specific time. 
    // so it will destroy the first object, (pushback) then we will wait and destroy the next one tell the list is empty.

    public void DamageText(Vector3 pos, int damage, GameObject hitObject)
    {
        GameObject temp;
        if (text.gameObject)
        {
            temp = Instantiate(text.gameObject);
            if (temp)
            {
                temp.transform.SetParent(hitObject.transform.Find("Damage").transform);
                temp.GetComponent<Text>().text = damage.ToString();
                temp.GetComponent<RectTransform>().position = pos + new Vector3(0, 185, 0);
                // I HAVE TO SET THE PARENT TO THE ACTUAL PARENT OF THE OBJECT
                // ONCE I SET THAT WE WILL BE GOOD.
                temp.GetComponent<RectTransform>().eulerAngles = hitObject.transform.eulerAngles;
                temp.transform.tag = "DamageText";
                //temp.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 180f, 0);
                temp.GetComponent<Animation>().Play();
                //temp.GetComponent<Animator>().Play(0);
                flyingText.Add(temp);
                //StartCoroutine(Destroy());
            }
        }

    }
    public void DamageText(Vector3 pos, int damage, GameObject hitObject, Color color)
    {
        GameObject temp;
        if (text.gameObject)
        {
            temp = Instantiate(text.gameObject);
            if (temp)
            {
                temp.transform.SetParent(hitObject.transform.Find("Damage").transform);
                temp.GetComponent<Text>().text = damage.ToString();
                temp.GetComponent<Text>().color = color;
                temp.GetComponent<RectTransform>().position = pos + new Vector3(0, 185, 0);
                // I HAVE TO SET THE PARENT TO THE ACTUAL PARENT OF THE OBJECT
                // ONCE I SET THAT WE WILL BE GOOD.
                temp.GetComponent<RectTransform>().eulerAngles = hitObject.transform.eulerAngles;
                temp.transform.tag = "DamageText";
                //temp.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 180f, 0);
                temp.GetComponent<Animation>().Play();
                //temp.GetComponent<Animator>().Play(0);
                flyingText.Add(temp);
                //StartCoroutine(Destroy());
            }
        }

    }
    IEnumerator Destroy()
    {
        isWaiting = true;
        //Debug.Log(temporary.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length);
        if (flyingText[0])
        {
            yield return new WaitForSeconds(flyingText[0].GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length);
        }
        //Destroy(flyingText[0]);
        //flyingText.RemoveAt(0);
        isWaiting = false;
    }
   
}
