using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float slerpSpeed;
    public Transform cameraTarget;
    public Transform myCamera;
    private float x = 0.0f;
    private float y = 0.0f;
    PlayerMovement playerMovement;
    private int mouseXSpeedMod = 5;
    private int mouseYSpeedMod = 3;
    float hAngle, vAngle;
    public float maxViewDistance = 25, minViewDistance = 1; // how far the camera will move out and in
    public int zoomRate = 30;  // how fast the camera will zoom
    public int lerpRate = 10;
    public float cameraTargetHeight = 1.0f;
    private float distance = 10, desiredDistance, correctedDistance; // starting distance away from player, used for calculations, used for calculations
    private float currentDistance;
    Vector3 cameraTargetPosition = new Vector3(0, 0, 0);
    [HideInInspector]
    public bool isDragged;
    bool isHolding = false;
    Vector3 orgPos;
    float lerpTime = 5;
    float currentLerpTime = 0;
    bool inFront;
    bool isRotate;
    bool islockScroll;



    void Start () {
        orgPos = transform.position;
        Vector3 angles = transform.eulerAngles; //
        x = angles.x;
        y = angles.y;
        
        currentDistance = distance;
        desiredDistance = distance;
        correctedDistance = distance;
        isDragged = false;
        islockScroll = false;

    }
	void Update()
    {
        
        // Make the player go the way it is looking
        // Camera goes behind the player when they start moving unless they are still holding the mouse button
        // If right mouse button the player rotates with it
        //myCamera.transform.rotation = cameraTarget.transform.rotation;
        
        myCamera.transform.eulerAngles = new Vector3(90, cameraTarget.eulerAngles.y, 0);
        //Debug.Log(myCamera.transform.rotation + " My Camera");
        //Debug.Log(cameraTarget.transform.rotation + " My Player");
        //Debug.Log(myCamera.transform.position);
       
        Vector3 relativePoint = cameraTarget.InverseTransformPoint(myCamera.position);
        if (relativePoint.z > 0.0)
        {
            //Behind Player
            //Set bool to false or true
            Debug.Log("Object is behind Player");
            inFront = false;
            currentLerpTime = 0;
        }
        else if (relativePoint.z < 0.0)
        {
            if(!isHolding)
            {
                currentLerpTime += Time.deltaTime;
                if(currentLerpTime>=lerpTime)
                {
                    currentLerpTime = lerpTime;
                }
                float Proc = currentLerpTime / lerpTime;
               // transform.position = Vector3.Lerp(transform.position, orgPos, Proc);
              //  Debug.Log(transform.position);
            }
            //In front of player
            //Make it so the camera goes to the back if this happends.
            Debug.Log("Object is in front Player");
            inFront = true;
        }
       
        hAngle = Input.GetAxis("Horizontal");
        vAngle = Input.GetAxis("Vertical");

       // myCamera.transform.position = distance * (new Vector3(Mathf.Cos(hAngle), Mathf.Sin(vAngle)));
       
    }
    // Update after update function is called once per frame. Since camera controlls arent as important as movement, we want movement to occur first.
    void LateUpdate () {
        Vector3 orgPos = transform.position;
        isHolding = false;
        if (Input.GetMouseButton(0) &&!isDragged)
        { 
            x+= Input.GetAxis("Mouse X") * mouseXSpeedMod;
            y-= Input.GetAxis("Mouse Y")* mouseYSpeedMod;// 0-left mouse button or 1- right mouse button
            isHolding = true;
            isRotate = false;
        }
        else if(Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal")!= 0)
        {// if either veritcal or horizontal buttons are pressed it wil activate
            float targetRotationAngle = cameraTarget.eulerAngles.y;
            float cameraRotationAngle = transform.eulerAngles.y;
            x = Mathf.LerpAngle(cameraRotationAngle, targetRotationAngle, lerpRate * Time.deltaTime);
        }
        
       

        //transform.LookAt(cameraTarget);

        y = ClampAngle(y, -40, 60);
        float distX = x;
        float distY = y;
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * mouseXSpeedMod;
            y -= Input.GetAxis("Mouse Y") * mouseYSpeedMod;

            if (distX  != x )
            {
                isRotate = true;
                Quaternion rot = rotation;
                rot.x = 0;
                rot.z = 0;
                //rot.Set(0, rot.eulerAngles.y + 180f, 0, 0);
                //rot.eulerAngles.y += 180f;
                // I should lerp it so it moves slowy towards
                //cameraTarget.rotation = Quaternion.Euler(new Vector3(0f, rot.eulerAngles.y + 180f));
                // Debug.Log(rot.eulerAngles.y);
                // Lerp it,l but it works for now
                float qRot = rot.eulerAngles.y;
                qRot = Mathf.Lerp(qRot, qRot + 180f, Time.deltaTime * 1);
                cameraTarget.rotation = Quaternion.Euler(new Vector3(0f, qRot + 180f));
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            //GetComponent<Camera>().fieldOfView--;
        }

       
            desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(desiredDistance); // calculate the distance the player wants their camera
            desiredDistance = Mathf.Clamp(desiredDistance, minViewDistance, maxViewDistance);
            correctedDistance = desiredDistance;
        
        

        Vector3 position = cameraTarget.position - (rotation * Vector3.forward * desiredDistance); // (x,y,x) * (0,1,0) * (angle in degrees)

        RaycastHit collisionHit;
        if (cameraTarget.transform.rotation.eulerAngles.y < 90 && !inFront)
        {

            myCamera.transform.position = new Vector3(0, 0, 10);
            cameraTargetPosition = new Vector3(cameraTarget.position.x, cameraTarget.position.y + cameraTargetHeight, cameraTarget.position.z);
        }
        if (cameraTarget.transform.rotation.eulerAngles.y > 90 && !inFront)
        {
            myCamera.transform.position = new Vector3(0, 0, -10);
            cameraTargetPosition = new Vector3(cameraTarget.position.x, cameraTarget.position.y + cameraTargetHeight, cameraTarget.position.z);
        }

        bool isCorrected = false;
        // Make a boolean function that checks whether the camera is raycasted to something, if it is
        // Set a boolean that sets its distance.
        // While the distance is set we will try to keep it there for a few
        // The other way is to make a invisible wall above the house, so it gets rid of that issue.
        islockScroll = false;
        bool isHit = false;
        Vector3 point = Vector3.forward;
        float dist = correctedDistance;
        //dist = desiredDistance;
        if(Physics.Linecast(cameraTargetPosition, position, out collisionHit))
        {
            if (collisionHit.transform.gameObject != cameraTarget)
            {
                position = collisionHit.point;
                point = collisionHit.point;
                isHit = true;
                correctedDistance = Vector3.Distance(cameraTargetPosition, position);
                dist = correctedDistance;
                //desiredDistance = dist;

                isCorrected = true;
                islockScroll = true;
            }
        }

        // ?: (Condition operators!) ? first_expression : second_expression;
        //(input > 0) ? isPostive : is Negative;
        if(isCorrected)
        {
            //desiredDistance = Mathf.Lerp(desiredDistance, dist, Time.deltaTime * 5);
        }
            currentDistance = !isCorrected || correctedDistance > currentDistance ? Mathf.Lerp(currentDistance, correctedDistance, Time.deltaTime * zoomRate/20) : correctedDistance;

            currentDistance = Mathf.Lerp(currentDistance, dist, Time.deltaTime * zoomRate / 10);


            position = cameraTarget.position - (rotation * Vector3.forward * (currentDistance) + new Vector3(0, -cameraTargetHeight * 2, 0));
            //position = new Vector3(position.x, point.y, position.z);
            transform.rotation = rotation; // when you call tranfrom within the script, it looks for the trasnform the script is attached to

        //transform.position = Vector3.Lerp(transform.position, position,Time.deltaTime*150);
        transform.position = position;       
    }


    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;


        return Mathf.Clamp(angle,min,max);
    }

    void CameraRotationBack()
    {
        //Something to freeze the camera location but, at the same time follow the player
        //Make the camera flip when the player turns
    }
}
