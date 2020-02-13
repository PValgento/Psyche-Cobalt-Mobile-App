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

    protected GameObject prefab1;
    protected GameObject prefab2;
    protected GameObject prefab3;
    protected GameObject prefabRocket;
    protected GameObject cFH;

    protected List<GameObject> bodyList = new List<GameObject>();
    protected List<GameObject> sideList = new List<GameObject>();
    protected List<GameObject> engineList = new List<GameObject>();

    protected Transform player_Model;
    protected Transform modelChild;
    protected Rigidbody2D playerRb;
    protected Camera camera;
    protected float movementSpeed = 12.5f;

    void Awake()
    {//Start is called before the first frame update
        ctl_PlayerAwake();
    }
    protected void ctl_PlayerAwake()
    {
      Debug.Log("Start of Player Awakening...");
      //Get the empty model object so all graphics elements of the ship can be packaged together.
      modelChild = this.transform.GetChild(0);

      //Copy from Awake so called by parents
      bodyIndex = PlayerPrefs.GetInt("Body");
      solarIndex = PlayerPrefs.GetInt("Solar");
      sensorIndex = PlayerPrefs.GetInt("Sensor");
      engineIndex = PlayerPrefs.GetInt("Engine");

      prefabIndex = PlayerPrefs.GetInt("Craft");

      //Load Prefabs into Object
      prefab1 = Resources.Load<GameObject>("Prefabs/Prefab1_Cube");// as GameObject;
      prefab2 = Resources.Load<GameObject>("Prefabs/Prefab2_Sphere");// as GameObject;
      prefab3 = Resources.Load<GameObject>("Prefabs/Prefab3_Capsule");// as GameObject;
      prefabRocket = Resources.Load<GameObject>("Prefabs/RocketObj");// as GameObject;
      cFH = Resources.Load<GameObject>("Prefabs/crappy_Falcon_Heavy Variant");// as GameObject;

      //Load Component Prefabs into List
      //bodyList.Add(Resources.Load<GameObject>("Body/BodyTemplate"));// as GameObject;
      bodyList.Add(Resources.Load<GameObject>("Body/Body-DarkPink"));
      bodyList.Add(Resources.Load<GameObject>("Body/Body-DarkPurple"));
      bodyList.Add(Resources.Load<GameObject>("Body/Body-Orange"));
      bodyList.Add(Resources.Load<GameObject>("Body/Body-Pink"));
      bodyList.Add(Resources.Load<GameObject>("Body/Body-Purple"));
      bodyList.Add(Resources.Load<GameObject>("Body/Body-White"));
      //bodyList.Add(Resources.Load<GameObject>("Body/Body2"));
      //bodyList.Add(Resources.Load<GameObject>("Body/Body3"));
      //sideList.Add(Resources.Load<GameObject>("SidePanels/SideTemplate"));// as GameObject;
      sideList.Add(Resources.Load<GameObject>("SidePanels/Side-DarkPink"));
      sideList.Add(Resources.Load<GameObject>("SidePanels/Side-DarkPurple"));
      sideList.Add(Resources.Load<GameObject>("SidePanels/Side-Orange"));
      sideList.Add(Resources.Load<GameObject>("SidePanels/Side-Pink"));
      sideList.Add(Resources.Load<GameObject>("SidePanels/Side-Purple"));
      sideList.Add(Resources.Load<GameObject>("SidePanels/Side-White"));
      sideList.Add(Resources.Load<GameObject>("SidePanels/Side2"));
      //sideList.Add(Resources.Load<GameObject>("SidePanels/Side3"));
      //engineList.Add(Resources.Load<GameObject>("Engine/EngineTemplate"));// as GameObject;
      engineList.Add(Resources.Load<GameObject>("Engine/Engine-DarkPink"));
      engineList.Add(Resources.Load<GameObject>("Engine/Engine-DarkPurple"));
      engineList.Add(Resources.Load<GameObject>("Engine/Engine-Orange"));
      engineList.Add(Resources.Load<GameObject>("Engine/Engine-Pink"));
      engineList.Add(Resources.Load<GameObject>("Engine/Engine-Purple"));
      engineList.Add(Resources.Load<GameObject>("Engine/Engine-White"));
      //engineList.Add(Resources.Load<GameObject>("Engine/Engine2"));
      //engineList.Add(Resources.Load<GameObject>("Engine/Engine3"));

      //Post Loading Prefabs
      Debug.Log("End of Player Awakening...");
      ctl_UsePlayerPrefs(new Vector3(0f,0f,0f)); //Default
    }
    protected void ctl_UsePlayerPrefs(Vector3 modelPos)
    {
        prefabIndex = PlayerPrefs.GetInt("Craft");
        Debug.Log("Player PlayerPref Index:" + prefabIndex);
        GameObject cameraObj = GameObject.Find("PlayerCamera");
        cameraObj.transform.parent = this.transform;
        camera = cameraObj.GetComponent<Camera>();

        foreach(Transform child in modelChild)
        {//Destroy all previously set children
            GameObject.Destroy(child.gameObject);
        }
        if(prefabIndex != -1)
        {//If building custom craft, don't use premade.
            Debug.Log("Using premade!");
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
            GameObject prefabObj = Instantiate(selectedPrefab, Vector3.zero, this.transform.rotation);//new Vector3(0f, 0f/*10.7f*/, 0f)/*this.transform.position*/
            //GameObject prefabObj = Instantiate(selectedPrefab, modelPos, this.transform.rotation);
            prefabObj.transform.parent = modelChild;//this.transform;
            prefabObj.transform.localPosition = modelPos;//Vector3.zero;
            //Solving Dsync issue
            //player_Model = prefabObj.transform;
            //player_Model.transform.localPosition = modelPos;
        }
        else
        {//Building custom craft.
            bodyIndex = PlayerPrefs.GetInt("Body");
            solarIndex = PlayerPrefs.GetInt("Solar");
            sensorIndex = PlayerPrefs.GetInt("Sensor");
            engineIndex = PlayerPrefs.GetInt("Engine");
            if(bodyIndex == -1) bodyIndex = 0;
            if(solarIndex == -1) solarIndex = 0;
            if(engineIndex == -1) engineIndex = 0;
            Debug.Log("Building custom craft!: (" + bodyIndex + "," + solarIndex + "," + engineIndex + ")");
            /*//Temp: prefab1
            GameObject selectedPrefab = prefab1; //default
            GameObject prefabObj = Instantiate(selectedPrefab, this.transform.position, this.transform.rotation);
            prefabObj.transform.parent = modelChild;//this.transform;
            player_Model = prefabObj.transform;
            */
            GameObject bodyObj = Instantiate(bodyList[bodyIndex], Vector3.zero, this.transform.rotation);
            GameObject solarObj = Instantiate(sideList[solarIndex], Vector3.zero, this.transform.rotation);
            GameObject solarObjMirrored = Instantiate(sideList[solarIndex], Vector3.zero, this.transform.rotation);
            GameObject engineObj = Instantiate(engineList[engineIndex], Vector3.zero, this.transform.rotation);
            solarObj.transform.parent = bodyObj.transform.Find("rightMount_SidePanel");
            solarObjMirrored.transform.parent = bodyObj.transform.Find("leftMount_SidePanel"); //Reverse scale
            solarObjMirrored.transform.localScale = new Vector3(-1,1,1);
            engineObj.transform.parent = bodyObj.transform.Find("mountEngine");
            //Set pos to zeros?
            solarObj.transform.localPosition = Vector3.zero;
            solarObjMirrored.transform.localPosition = Vector3.zero;
            engineObj.transform.localPosition = Vector3.zero;

            //Set construct to be child of the player model entity.
            bodyObj.transform.parent = modelChild;
            bodyObj.transform.localPosition = modelPos;//Vector3.zero;
        }


        //this.transform.position = modelPos;
        //GameObject cameraObj = GameObject.Find("PlayerCamera");
        //cameraObj.transform.parent = this.transform;
        //camera = cameraObj.GetComponent<Camera>();

        //this.transform.position = modelPos;//new Vector3(0f, 3.1f, 0f);
    }
    protected void ctl_CleanSwitchCraftSelection(int pn_Switch, string craftPart)
    {
        if(craftPart == "BODY")
        {
            bodyIndex = PlayerPrefs.GetInt("Body");
            if(pn_Switch == 0) bodyIndex--;
            else if(pn_Switch == 1) bodyIndex++;
            else{}

            if(bodyIndex < 0) PlayerPrefs.SetInt("Body", bodyList.Count - 1);
            else if(bodyIndex >= bodyList.Count) PlayerPrefs.SetInt("Body", 0);
            else{ PlayerPrefs.SetInt("Body", bodyIndex); }
            Debug.Log("Body Selected:" + PlayerPrefs.GetInt("Body"));
        }
        else if(craftPart == "SIDE")
        {
            solarIndex = PlayerPrefs.GetInt("Solar");
            if(pn_Switch == 0) solarIndex--;
            else if(pn_Switch == 1) solarIndex++;
            else{}

            if(solarIndex < 0) PlayerPrefs.SetInt("Solar", sideList.Count - 1);
            else if(solarIndex >= sideList.Count) PlayerPrefs.SetInt("Solar", 0);
            else{ PlayerPrefs.SetInt("Solar", solarIndex); }
            Debug.Log("Solar Selected:" + PlayerPrefs.GetInt("Solar"));
        }
        else if(craftPart == "ENGINE")
        {
            engineIndex = PlayerPrefs.GetInt("Engine");
            if(pn_Switch == 0) engineIndex--;
            else if(pn_Switch == 1) engineIndex++;
            else{}

            if(engineIndex < 0) PlayerPrefs.SetInt("Engine", engineList.Count - 1);
            else if(engineIndex >= engineList.Count) PlayerPrefs.SetInt("Engine", 0);
            else{ PlayerPrefs.SetInt("Engine", engineIndex); }
            Debug.Log("Engine Selected:" + PlayerPrefs.GetInt("Engine"));
        }
        else{
          //If no data do nothing.
        }
    }
    protected void ctl_SetCameraPosition(Vector3 newPos)
    {//Call to set camera position.
      camera.transform.localPosition = newPos;
    }
}
