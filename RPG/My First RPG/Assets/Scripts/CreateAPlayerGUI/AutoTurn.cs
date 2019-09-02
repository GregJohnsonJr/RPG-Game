using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurn : MonoBehaviour {



    public float speed;
    Transform player;
    bool isRight;
    bool isLeft;
    float xpos = 1920f;
    float ypos = 1080f;
    public float posX;
    public float posY;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        
        
    }
    void OnGUI()
    {
        float resX = Screen.width/xpos;
        float resY = Screen.height/ypos;
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(resX, resY, 1));
        // float Offset = ypos / xpos;
        // GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(xpos, ypos, 1));
        if (GUI.Button(new Rect(xpos/2 + posX/2, ypos/2 + posY/2, 70, 70), ">>>"))
        {
            //turn transform tagged as player to the left
            // make it so you can press and hold to turn

          
            isLeft = false;
            isRight = true;
        }
        if (GUI.Button(new Rect(xpos/2 - (posX - 15)/2,ypos/2 + posY/2, 70, 70), "<<<"))
        {
            //turn transform tagged as player to the right
           
          
            isRight = false;
            isLeft = true;
        }
    }
    private void Update()
    {
        if(isRight)
        {
            player.Rotate(Vector3.down * speed);
        }
        else if(isLeft)
        {
            player.Rotate(Vector3.up * speed);
        }
    }
}
