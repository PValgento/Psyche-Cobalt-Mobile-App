using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_SpacePlayer : MonoBehaviour
{
    int prefabIndex = 1;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    void Awake()
    {//Start is called before the first frame update
        prefabIndex = PlayerPrefs.GetInt("Craft");
        ctl_UsePlayerPrefs();
    }

    
    void Update()
    {//Update is called once per frame
        
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
    }
}
