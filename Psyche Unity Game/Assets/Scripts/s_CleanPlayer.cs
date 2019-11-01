using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_CleanPlayer : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    void Start()
    {//Start is called before the first frame update
        
    }

    void Update()
    {//Update is called once per frame
        
    }
    public void ctl_UpdatePlayerPrefab(int index)
    {
        Debug.Log("Player Prefab Index:" + index);
        foreach(Transform child in this.transform)
        {//Destroy all previously set children
            GameObject.Destroy(child.gameObject);
        }
        GameObject selectedPrefab = prefab1; //default
        if(index == 1)
            selectedPrefab = prefab1;
        else if(index == 2)
            selectedPrefab = prefab2;
        else if(index == 3)
            selectedPrefab = prefab3;
        else{}

        GameObject prefabObj = Instantiate(selectedPrefab, this.transform.position, this.transform.rotation);
        prefabObj.transform.parent = this.transform;
    }
}
