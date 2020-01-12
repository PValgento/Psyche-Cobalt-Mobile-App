using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sb_PlayerConstruction : MonoBehaviour
{
    protected int bodyIndex = 0;
    protected int solarIndex = 0;
    protected int sensorIndex = 0;
    protected int engineIndex = 0;
    protected int prefabIndex = 0;

    [SerializeField]
    protected GameObject prefab1;
    [SerializeField]
    protected GameObject prefab2;
    [SerializeField]
    protected GameObject prefab3;
    [SerializeField]
    protected GameObject prefabRocket;
    [SerializeField]
    protected GameObject cFH;

    protected Transform player_Model;
    protected Transform modelChild;
    protected Rigidbody2D playerRb;
    protected Camera camera;
    protected float movementSpeed = 12.5f;

    void Awake()
    {//Start is called before the first frame update
        ctl_PlayerAwake();
        bodyIndex = PlayerPrefs.GetInt("Body");
        solarIndex = PlayerPrefs.GetInt("Solar");
        sensorIndex = PlayerPrefs.GetInt("Sensor");
        engineIndex = PlayerPrefs.GetInt("Engine");

        prefabIndex = PlayerPrefs.GetInt("Craft");
        ctl_UsePlayerPrefs(new Vector3(0f,0f,0f)); //Default
    }
    protected void ctl_PlayerAwake()
    {
        //Get the empty model object so all graphics elements of the ship can be packaged together.
        modelChild = this.transform.GetChild(0);
    }
    protected void ctl_UsePlayerPrefs(Vector3 modelPos)
    {
        prefabIndex = PlayerPrefs.GetInt("Craft");
        Debug.Log("Player PlayerPref Index:" + prefabIndex);

        foreach(Transform child in modelChild)
        {//Destroy all previously set children
            GameObject.Destroy(child.gameObject);
        }
        if(prefabIndex != -1)
        {//If building custom craft, don't use premade.
            GameObject selectedPrefab = prefab1; //default
            if(prefabIndex == 0)
                selectedPrefab = prefab1;
            else if(prefabIndex == 1)
                selectedPrefab = prefab2;
            else if(prefabIndex == 2)
                selectedPrefab = prefab3;
            else{}

            //GameObject prefabObj = Instantiate(selectedPrefab, this.transform.position, this.transform.rotation);
            //prefabObj.transform.parent = modelChild;//this.transform;
            //player_Model = prefabObj.transform;
            GameObject prefabObj = Instantiate(selectedPrefab, new Vector3(0f, 0f/*10.7f*/, 0f)/*this.transform.position*/, this.transform.rotation);
            prefabObj.transform.parent = modelChild;//this.transform;
            player_Model = prefabObj.transform;
            player_Model.transform.localPosition = modelPos;
        }
        else
        {//Building custom craft.
            bodyIndex = PlayerPrefs.GetInt("Body");
            solarIndex = PlayerPrefs.GetInt("Solar");
            sensorIndex = PlayerPrefs.GetInt("Sensor");
            engineIndex = PlayerPrefs.GetInt("Engine");

            //Temp: prefab1
            GameObject selectedPrefab = prefab1; //default
            GameObject prefabObj = Instantiate(selectedPrefab, this.transform.position, this.transform.rotation);
            prefabObj.transform.parent = modelChild;//this.transform;
            player_Model = prefabObj.transform;
        }
        GameObject cameraObj = GameObject.Find("PlayerCamera");
        cameraObj.transform.parent = this.transform;
        camera = cameraObj.GetComponent<Camera>();

        this.transform.position = new Vector3(0f, 3.1f, 0f);
    }
    protected void ctl_SetCameraPosition(Vector3 newPos)
    {//Call to set camera position.
      camera.transform.localPosition = newPos;
    }
}
