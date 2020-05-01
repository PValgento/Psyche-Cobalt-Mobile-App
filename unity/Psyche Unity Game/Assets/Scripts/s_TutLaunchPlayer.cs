using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class s_TutLaunchPlayer : sb_PlayerConstruction
{
    GameObject model;
    GameObject arrow; GameObject target; GameObject missed;
    Slider steering; Text dist;
    Color sky; Color space; public Material skybox;
    float rotation = 0f; float localGravity = 0f; bool setSkybox = false;

    //Information Arrows
    protected GameObject objectiveAnchor;
    protected GameObject velocityAnchor;
    private Vector3 lastPosition = Vector3.zero;

    void Awake()
    {//Start is called before the first frame update
        model = this.transform.GetChild(0).gameObject; //camera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        ctl_PlayerAwake();
        ctl_UpdatePlayerPrefab();
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        steering = GameObject.Find("slider_Steer").GetComponent<Slider>();
        arrow = GameObject.Find("Arrow"); target = GameObject.Find("Goal1");//target = GameObject.Find("Target");
        arrow.transform.position = new Vector3(-7f, 2f, 0f); arrow.transform.parent = this.transform;
        dist = GameObject.Find("distance").GetComponent<Text>(); missed = GameObject.Find("btn_Miss"); missed.SetActive(false);
        sky = new Color(.85f,.85f,.85f,1f); space = new Color(0f,0f,0f,1f);
        ctl_SetCameraPosition(new Vector3(0f, 25f, -40f));
        localGravity = Physics2D.gravity.y;

        //Find Information Arrows, set them to be children, and reset positions..
        objectiveAnchor = GameObject.Find("ObjectiveAnchor");
        velocityAnchor = GameObject.Find("VelocityAnchor");
        objectiveAnchor.transform.parent = this.transform;
        velocityAnchor.transform.parent = this.transform;
        objectiveAnchor.transform.localPosition = Vector3.zero;
        velocityAnchor.transform.localPosition = Vector3.zero;
    }
    private float tickDelay = 0f;
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
    }
    void FixedUpdate()
    {//Fixed Update is when physics are calculated so want to do physics stuff here...
        rotation = steering.value * -1; //Invert value so slider left is steer left.
        model.transform.rotation = Quaternion.Euler(new Vector3(0f,0f,rotation));
        playerRb.AddForce(model.transform.up * movementSpeed);
        Vector3 dir = target.transform.position - this.transform.position;
        Quaternion rot = Quaternion.AngleAxis(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, Vector3.up);
        arrow.transform.rotation = Quaternion.Euler(new Vector3(rot.eulerAngles.x, rot.eulerAngles.z, rot.eulerAngles.y-90f));
        dist.text = "Distance: " + (int)Vector3.Distance(model.transform.position, target.transform.position);
        if(this.transform.position.y > target.transform.position.y + 30f)//was 20f
        {//You passed it, and rockets don't like to go down...
            Debug.Log("You Missed!");
            missed.SetActive(true);
        }

        if(setSkybox)
        {//Gradually fade in the skybox.
            RenderSettings.skybox.SetColor("_Tint", Color.Lerp(space, Color.white, model.transform.position.y/450f));
        }
        else if (model.transform.position.y > 240f)
        {//Keep from setting every update.
            RenderSettings.skybox = skybox;
            setSkybox = true;
            RenderSettings.skybox.SetColor("_Tint", Color.black);
        }
        else
        {//Use regular color skybox.
            camera.backgroundColor = Color.Lerp(sky, space, model.transform.position.y/240f);
        }

        dir = target.transform.position - this.transform.position;
        rot = Quaternion.AngleAxis(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, Vector3.up);

        objectiveAnchor.transform.rotation = Quaternion.Euler(new Vector3(rot.eulerAngles.x, rot.eulerAngles.z, rot.eulerAngles.y-90f));
        //Reuse dir & rot for velocityAnchor.
        dir = this.transform.position - lastPosition;
        rot = Quaternion.AngleAxis(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, Vector3.up);
        velocityAnchor.transform.rotation = Quaternion.Euler(new Vector3(rot.eulerAngles.x, rot.eulerAngles.z, rot.eulerAngles.y-90f));
        lastPosition = this.transform.position;
    }
    public void ctl_UpdatePlayerPrefab()
    {
        this.ctl_UsePlayerPrefs(new Vector3(0f, 10.7f, 0f));
        GameObject rocketObj = Instantiate(cFH, this.transform.position + new Vector3(0f, 2.07f, 0f), Quaternion.Euler(0f, 90f, 0f));
        rocketObj.transform.parent = modelChild;
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
            Physics2D.gravity = new Vector2(0, localGravity * 0.95f);
            target = GameObject.Find("Goal2");
        }
        else if(col.name == "Goal2")
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+0);
            //Play Sound?
            col.gameObject.SetActive(false);
            Physics2D.gravity = new Vector2(0, localGravity * 0.75f);
            target = GameObject.Find("Goal3");
        }
        else if(col.name == "Goal3")
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+0);
            //Play Sound?
            col.gameObject.SetActive(false);
            Physics2D.gravity = new Vector2(0, localGravity * 0.45f);
            target = GameObject.Find("Target");
        }
        else if(col.name == "Ground")
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+0);
            //Play Sound?
            if(this.GetComponent<Rigidbody2D>().velocity.magnitude > 5f)
            {
                //Player hit the ground, restart level.
                SceneManager.LoadScene(7);
            }
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(7);
    }
}
