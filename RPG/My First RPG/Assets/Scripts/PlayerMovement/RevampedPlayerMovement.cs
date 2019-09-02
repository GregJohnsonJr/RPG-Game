using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevampedPlayerMovement : MonoBehaviour {
    Rigidbody rb;
    public float speed;
    public float rotateSpeed;
    public float jumpSpeed;
    bool canJump;
    bool isMoving;
    public GameObject rayCastMark;
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        canJump = true;
        isMoving = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // Need to rotate them with the camera then maybe??
        // They have there own rotation to rotate there character but what about when they need to look behind them?
        // Need References from wow.
        // Make the camera a manual type camera.
        // The player already has the ability to move it, but it maybe needs to move more with the players
       
        float horizontal = Input.GetAxis("Horizontal1");
        float vertical = Input.GetAxis("Vertical1");
      

        transform.Rotate(0, Input.GetAxis("Horizontal1") * rotateSpeed, 0); // Vector 3b is a 3 cordinate system (0,0,0) (x,y,z)
        Vector3 movement = Vector3.ProjectOnPlane((-1)*transform.right * speed * horizontal, Vector3.up);

        movement += Vector3.ProjectOnPlane((-1)*transform.forward * speed * vertical, Vector3.up);
        isMoving = false;
        if(movement.magnitude > 0.4f)
        {
            isMoving = true;
        }
        movement.y = rb.velocity.y;      
        rb.velocity = movement;
        if(Input.GetKey(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jumpSpeed);
            canJump = false;
        }
        //Debug.Log(canJump);
        //Debug.Log(rb.velocity);
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.name == "Terrain" || collision.transform.tag == "Props")
        {
            canJump = true;
        }
       // Debug.Log(rb.velocity.magnitude);
        // Check if the player is walking
        if(collision.transform.tag == "Props" && collision.transform.name != "Terrian" && rb.velocity.magnitude < 0.5f && isMoving )
        {
            RaycastHit hit;
            if(Physics.Raycast(rayCastMark.transform.position,transform.TransformDirection(Vector3.forward), out hit))
            {
                Debug.DrawRay(rayCastMark.transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                if (Vector3.Distance(rayCastMark.transform.position, hit.transform.position) < 2f)
                    transform.position += new Vector3(0, .1f);
            }
            //Debug.Log("Stuck");
        }
        
    }

}
