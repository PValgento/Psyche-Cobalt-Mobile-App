using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
public class sb_Player : MonoBehaviour
{
    [SerializeField]
    protected GameObject Player_Start_Obj; //Must not be null!
    [SerializeField]
    protected Transform player_Model;

    public GameObject playerCamera;
    private Camera camera;
    private bool FirstMove = true;
    private Vector3 mouseCoords = Vector3.zero;
    private float movementSpeed = 5.2f;
    private bool currentlyMoving = false;
    private bool isPlayerActive = false;

    private bool toggleSpeed = true; //For testing gravity.
    private Vector3 lookPosition = Vector3.zero;
    void Awake()
    {//What to do when the script wakes up.
        this.transform.parent = Player_Start_Obj.transform; //Set unit transform(position,etc) to the Player_Start object.
		Debug.Log("Player placed at starting location!");
        //Player_Start will be where we wanna be.
		this.transform.localPosition = new Vector3(0f, 0f, 0f);
        this.transform.rotation = Quaternion.Euler(Vector3.zero);

        this.GetComponent<Rigidbody2D>().isKinematic = true;
        camera = playerCamera.GetComponent<Camera>();
    }
    
    void Start()
    {//Start is called before the first frame update
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {//For testing gravity.
            toggleSpeed = !toggleSpeed;
            if(toggleSpeed == true)
                movementSpeed = 3.2f;
            else
                movementSpeed = 0.0f;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.GetComponent<Rigidbody2D>().angularVelocity = 0f;//Vector2.zero;
        }
        if(isPlayerActive)
        {//If player is active only to move.
            lookPosition = Input.mousePosition;
            if(Input.touchCount != 0)
                lookPosition = Input.GetTouch(0).position;
            
            Ray ray = camera.ScreenPointToRay(lookPosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                mouseCoords = new Vector3(hit.point.x, hit.point.y, 0f);//0f/*hit.point.y*/, hit.point.z);
            }
            if (Input.GetMouseButtonDown(0)) 
            {
                currentlyMoving = true;
                Debug.Log("Lets Move!");
                if(FirstMove)
                    Unfollow();
            }
            if(currentlyMoving)
            {
                float movementStep = movementSpeed * Time.deltaTime;
                if(!isVector3NaN(this.transform.position) && !isVector3NaN(mouseCoords))
                    this.transform.position = Vector3.MoveTowards(this.transform.position, mouseCoords, movementStep);
                player_Model.LookAt(mouseCoords);
            }
        }
    }
    private void Unfollow()
    {
        FirstMove = false;
        this.transform.parent = null;
        //Rigidbody:
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        this.GetComponent<Rigidbody2D>().angularVelocity = 0f;//Vector2.zero;
        this.GetComponent<Rigidbody2D>().isKinematic = false;
    }
    public void ctl_PlayerReset()
    {
        FirstMove = true;
        currentlyMoving = false;
        playerCamera.GetComponent<sb_Camera>().ctl_Reset();
    }
    public void ctl_PlayerActive(bool isActive)
    {
        isPlayerActive = isActive;
    }
    protected bool isVector3NaN(Vector3 subject)
    {//Trying to fix NaN/Infinity warnings/errors.
        if(!float.IsNaN(subject.x) && !float.IsNaN(subject.y) && !float.IsNaN(subject.z))
            return false;
        else
            return true;
    }
}
