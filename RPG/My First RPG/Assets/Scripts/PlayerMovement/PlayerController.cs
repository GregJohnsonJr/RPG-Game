using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    float normalSpeed;
    public float rotateSpeed, forwardSpeed;
    private CharacterController playerController;
    private float runSpeed;

	// Use this for initialization
	void Start () {
        playerController = GetComponent<CharacterController>();
        normalSpeed = forwardSpeed;
        runSpeed = forwardSpeed * 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space") && playerController.isGrounded)
        {
            playerController.Move(Vector3.up);
        }
        if(Input.GetAxis("Run") != 1)
        {
            forwardSpeed = normalSpeed;
        }
        playerController.SimpleMove(Physics.gravity);
        transform.Rotate(0, Input.GetAxis("Horizontal1") * rotateSpeed, 0); // Vector 3b is a 3 cordinate system (0,0,0) (x,y,z)
        Vector3 forward = transform.TransformDirection(Vector3.back);
        float speed = forwardSpeed * Input.GetAxis("Vertical1");
        playerController.SimpleMove(speed * forward);
      
        //Debug.Log(Input.GetAxis("Run"));
        if (Input.GetAxis("Run") == 1 && playerController.isGrounded) {
             //normalSpeed = runSpeed;
            forwardSpeed = runSpeed;

        }

	}
}
