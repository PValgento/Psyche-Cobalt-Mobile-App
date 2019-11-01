using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_LaunchPlayer : MonoBehaviour
{
    int prefabIndex = 1;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefabRocket;

    protected Transform player_Model;
    protected Rigidbody2D playerRb;
    protected Camera camera;
    private float movementSpeed = 12.5f;
    void Awake()
    {//Start is called before the first frame update
        prefabIndex = PlayerPrefs.GetInt("Craft");
        ctl_UsePlayerPrefs();
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {//Update is called once per frame
        
    }
    void FixedUpdate()
    {//Fixed Update is when physics are calculated so want to do physics stuff here...
        playerRb.AddForce(transform.up * movementSpeed);
    }
    public void ctl_UsePlayerPrefs()
    {
        Debug.Log("Player PlayerPref Index:" + prefabIndex);
        foreach(Transform child in this.transform)
        {//Destroy all previously set children
            GameObject.Destroy(child.gameObject);
        }
        GameObject selectedPrefab = prefab1; //default
        if(prefabIndex == 1)
            selectedPrefab = prefab1;
        else if(prefabIndex == 2)
            selectedPrefab = prefab2;
        else if(prefabIndex == 3)
            selectedPrefab = prefab3;
        else{}

        GameObject prefabObj = Instantiate(selectedPrefab, this.transform.position, this.transform.rotation);
        prefabObj.transform.parent = this.transform;
        player_Model = prefabObj.transform;
        GameObject rocketObj = Instantiate(prefabRocket, this.transform.position + new Vector3(0f, -3f, 0f), this.transform.rotation);
        rocketObj.transform.parent = this.transform;
        GameObject cameraObj = GameObject.Find("PlayerCamera");
        cameraObj.transform.parent = this.transform;
        camera = cameraObj.GetComponent<Camera>();

        this.transform.position = new Vector3(0f, 3.1f, 0f);
    }
}
