using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class s_TutSpacePlayer : sb_PlayerConstruction
{
    GameObject model;
    GameObject arrow; GameObject target; GameObject missed;
    private float tickDelay = 0f; //Delay used to smooth issues of multiple scripts loading before ready.

    //Steering
    Vector2 direction;
    float rotation = 0f; //float localGravity = 0f; bool setSkybox = false;
    private bool ignoreThrottle = false; //Used to prevent craft from facing throttle when in use.

    //Fuel & Throttle:
    Slider throttleSlide;
    Slider fuelSlider;
    //Fuel System:
    protected float fuelCoefficient = 0.5f;//Less fuel used in tutorial than actual space scene.
    protected float currentFuel = 500;
    protected float MAX_FUEL = 500;
    //Throttle Decreasing System:
    private bool recentClick = false;
  	private int frameCount = 0;
  	private float clickValue = 0;

    //Information Arrows
    protected GameObject objectiveAnchor;
    protected GameObject velocityAnchor;

    void Awake()
    {//Start is called before the first frame update
        model = this.transform.GetChild(0).gameObject; //camera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        ctl_PlayerAwake();
        ctl_UpdatePlayerPrefab();
        playerRb = gameObject.GetComponent<Rigidbody2D>();

        throttleSlide = GameObject.Find("ThrottleSlider").GetComponent<Slider>();
        fuelSlider = GameObject.Find("FuelSlider").GetComponent<Slider>();
        fuelSlider.maxValue = MAX_FUEL;
        fuelSlider.value = MAX_FUEL;

        arrow = GameObject.Find("Arrow"); target = GameObject.Find("Goal1");//target = GameObject.Find("Target");
        arrow.transform.position = new Vector3(-7f, 2f, 0f); arrow.transform.parent = this.transform;
        missed = GameObject.Find("btn_Miss"); missed.SetActive(false);

        ctl_SetCameraPosition(new Vector3(0f, 0f, -40f));
        Physics2D.gravity = Vector2.zero;

        //Find Information Arrows, set them to be children, and reset positions..
        objectiveAnchor = GameObject.Find("ObjectiveAnchor");
        velocityAnchor = GameObject.Find("VelocityAnchor");
        objectiveAnchor.transform.parent = this.transform;
        velocityAnchor.transform.parent = this.transform;
        objectiveAnchor.transform.localPosition = Vector3.zero;
        velocityAnchor.transform.localPosition = Vector3.zero;
    }

    void Update()
    {
        if(tickDelay > 0.01f)
        {//Doing this delayed reset to fix collision pos/rot changing issue.
            this.transform.rotation = Quaternion.Euler(Vector3.zero); //Fix weird collision issue that occurs before probe is hidden and causes rotation of the player object.
            this.transform.position = Vector3.zero;
            tickDelay = -999f; //Only reset position once.
        }
        else if(tickDelay > -1f)
            tickDelay += Time.deltaTime;

        if((Input.touchCount > 0 || Input.GetMouseButtonDown(0)) && ignoreThrottle == false)
        {//Space steering
            Vector3 mousePos = Input.mousePosition;
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                mousePos = Camera.main.ScreenToWorldPoint(touch.position);
            }
            else if(Input.GetMouseButtonDown(0))
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else{}
            direction[0] = mousePos.x - transform.position.x;
            direction[1] = mousePos.y - transform.position.y;
            direction = direction.normalized;
            Vector3 rotVec = new Vector3(direction[0], 0, direction[1]);

            Vector3 dir = mousePos - this.transform.position;
            Quaternion rot = Quaternion.AngleAxis(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, Vector3.up);
            model.transform.rotation = Quaternion.Euler(new Vector3(rot.eulerAngles.x, rot.eulerAngles.z, rot.eulerAngles.y-90f));
        }
        if(recentClick)
        {//Allow the updates to run to lower throttle once released.
            ThrottleDrain();
        }
    }
    private Vector3 lastPosition = Vector3.zero;
    void FixedUpdate()
    {//Fixed Update is when physics are calculated so want to do physics stuff here...

        if(currentFuel > 0.01f && throttleSlide.value > 0.01f)
        {//Move & use fuel on throttle use.
            playerRb.AddForce(model.transform.up * (throttleSlide.value *movementSpeed));
            currentFuel = currentFuel - fuelCoefficient*(throttleSlide.value);
            fuelSlider.value = currentFuel;
        }


        Vector3 dir = target.transform.position - this.transform.position;
        Quaternion rot = Quaternion.AngleAxis(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, Vector3.up);
        arrow.transform.rotation = Quaternion.Euler(new Vector3(rot.eulerAngles.x, rot.eulerAngles.z, rot.eulerAngles.y-90f));

        objectiveAnchor.transform.rotation = Quaternion.Euler(new Vector3(rot.eulerAngles.x, rot.eulerAngles.z, rot.eulerAngles.y-90f));
        //Reuse dir & rot for velocityAnchor.
        dir = this.transform.position - lastPosition;
        rot = Quaternion.AngleAxis(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, Vector3.up);
        velocityAnchor.transform.rotation = Quaternion.Euler(new Vector3(rot.eulerAngles.x, rot.eulerAngles.z, rot.eulerAngles.y-90f));
        lastPosition = this.transform.position;
    }
    public void ctl_UpdatePlayerPrefab()
    {
        this.ctl_UsePlayerPrefs(new Vector3(0f, 0.0f, 0f));
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("You hit the target +Score!");
        if(col.name == "Target")
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+0);
            PlayerPrefs.SetInt("SCENE", 6);
            SceneManager.LoadScene(5); //6//Back to the tutorial choice.
        }
        else if(col.name == "Goal1")
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+0);
            //Play Sound?
            col.gameObject.SetActive(false);
            target = GameObject.Find("Goal2");
        }
        else if(col.name == "Goal2")
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+0);
            //Play Sound?
            col.gameObject.SetActive(false);
            target = GameObject.Find("Goal3");
        }
        else if(col.name == "Goal3")
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+0);
            //Play Sound?
            col.gameObject.SetActive(false);
            //target = GameObject.Find("Goal4");
            target = GameObject.Find("Target");
        }
        else if(col.name == "Obstacle")
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+0);
            Debug.Log("That hurt Charlie!");
            missed.SetActive(true);

            //Play Sound?
            /*if(this.GetComponent<Rigidbody2D>().velocity.magnitude > 5f)
            {
                //Player hit the ground, restart level.
                SceneManager.LoadScene(8);
            }*/
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(8);
    }

    public void ThrottleDrain()
    {
  			if (frameCount < 15) {
  				throttleSlide.value = System.Math.Max(throttleSlide.value - (float) (0.06667 * clickValue), 0);
  				frameCount++;
  			}
  			else {
  				recentClick = false;
          ignoreThrottle = false;
  			}
    }
    public void ThrottleToggle(bool value)
    {
        ignoreThrottle = true;
        if(throttleSlide == null)
        {//Prevents null exception when slider is clicked before starting tutorial.
            throttleSlide = GameObject.Find("ThrottleSlider").GetComponent<Slider>();
        }
        clickValue = throttleSlide.value;
        frameCount = 0;
        recentClick = value;
    }
}
