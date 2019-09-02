using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // fix camera 
    public Transform cameraRotation;
    Rigidbody rb;
    public float moveSpeed;
    public float rotateSpeed;
    float z;
    float x;
    float y;
    CharacterController cc;

    void Start()
    {
        Vector3 rot = cameraRotation.eulerAngles;
        z = rot.z;
        rb = GetComponent<Rigidbody>();
      
    }
    // Update is called once per frame
    void Update () {
        // Looks like we found our movement
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");
      
       
          /*  if (Input.GetKey("w"))
            {
                moveSpeed = 10.0f;
            transform.Translate((Vector3.forward) * moveSpeed * Time.deltaTime);
           //rb.AddForce((Vector3.forward*moveSpeed)*Time.deltaTime);
            Debug.Log("More then 180 degrees");
            }
        
        if(Input.GetKey("s"))
            {
            
            transform.Translate((Vector3.back) * moveSpeed * Time.deltaTime);
            }
       if(Input.GetKey("d"))
        {
        
            transform.Rotate(Vector3.up * rotateSpeed);
           //transform.Translate((Vector3.right) * moveSpeed * Time.deltaTime);
        }


        if (Input.GetButtonDown("Testing"))
        {
            
           // Debug.Log(Input.GetAxis("Testing"));
         //   Debug.Log("Pressing the Test Key");
           
        }
        if(Input.GetKey("a"))
        {
            moveSpeed = 10.0f;
           
          //  transform.Translate((Vector3.left) * moveSpeed * Time.deltaTime);
            transform.Rotate(Vector3.down * rotateSpeed);
            cameraRotation.TransformDirection(Vector3.left);
             
        }*/
        if (Input.GetMouseButton(0))
        {
           // moveSpeed = 20.0f;
           // Debug.Log("Presing Left mouse button");
        }
        if (Input.GetKey("w") && Input.GetKey("left shift"))
        {
            moveSpeed = 20.0f;
        }
        if (Input.GetMouseButton(1))
        {
            //Debug.Log("Presing Right mouse button");
        }
    }
    void LateUpdate()
    {
        y = cameraRotation.eulerAngles.y;
        x = cameraRotation.eulerAngles.x;
        z = cameraRotation.eulerAngles.z;
        
        /*if(Input.GetAxis("Horizontal") != 0 && Input.GetKey("a"))
        {
            cameraRotation.transform.Translate(cameraRotation.transform.right * Input.GetAxis("Horizontal") * Time.deltaTime);

        }*/
      



    }


    void CameraRoationWhileMoving()
    {
        while(cameraRotation.rotation.z!= 180)
        {
            z++;

        }

    }
}
