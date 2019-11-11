using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sb_PlayerConstruction : MonoBehaviour
{
    int bodyIndex = 0;
    int solarIndex = 0;
    int sensorIndex = 0;
    int engineIndex = 0;
    int prefabIndex = 0;
    
    [SerializeField]
    protected GameObject prefab1;
    [SerializeField]
    protected GameObject prefab2;
    [SerializeField]
    protected GameObject prefab3;
    [SerializeField]
    protected GameObject prefabRocket;

    protected Transform player_Model;
    protected Transform modelChild;
    protected Rigidbody2D playerRb;
    protected Camera camera;
    private float movementSpeed = 12.5f;

    void Awake()
    {//Start is called before the first frame update
        modelChild = this.transform.GetChild(0);
        bodyIndex = PlayerPrefs.GetInt("Body");
        solarIndex = PlayerPrefs.GetInt("Solar");
        sensorIndex = PlayerPrefs.GetInt("Sensor");
        engineIndex = PlayerPrefs.GetInt("Engine");

        prefabIndex = PlayerPrefs.GetInt("Craft");
        ctl_UsePlayerPrefs();
    }
    protected void ctl_UsePlayerPrefs()
    {
        prefabIndex = PlayerPrefs.GetInt("Craft");
        Debug.Log("Player PlayerPref Index:" + prefabIndex);
        
        foreach(Transform child in modelChild/*this.transform*/)
        {//Destroy all previously set children
            GameObject.Destroy(child.gameObject);
        }
        GameObject selectedPrefab = prefab1; //default
        if(prefabIndex == 0)
            selectedPrefab = prefab1;
        else if(prefabIndex == 1)
            selectedPrefab = prefab2;
        else if(prefabIndex == 2)
            selectedPrefab = prefab3;
        else{}

        GameObject prefabObj = Instantiate(selectedPrefab, this.transform.position, this.transform.rotation);
        prefabObj.transform.parent = modelChild;//this.transform;
        player_Model = prefabObj.transform;
        //GameObject rocketObj = Instantiate(prefabRocket, this.transform.position + new Vector3(0f, -3f, 0f), this.transform.rotation);
        //rocketObj.transform.parent = this.transform;
        GameObject cameraObj = GameObject.Find("PlayerCamera");
        cameraObj.transform.parent = this.transform;
        camera = cameraObj.GetComponent<Camera>();

        this.transform.position = new Vector3(0f, 3.1f, 0f);
    }
}
