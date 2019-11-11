using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_LaunchPlayer : sb_PlayerConstruction
{
    void Awake()
    {//Start is called before the first frame update
        ctl_PlayerAwake();
        ctl_UpdatePlayerPrefab();
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {//Update is called once per frame
        
    }
    void FixedUpdate()
    {//Fixed Update is when physics are calculated so want to do physics stuff here...
        playerRb.AddForce(transform.up * movementSpeed);
    }
    public void ctl_UpdatePlayerPrefab()
    {
        this.ctl_UsePlayerPrefs();
        GameObject rocketObj = Instantiate(prefabRocket, this.transform.position + new Vector3(0f, -3f, 0f), this.transform.rotation);
        rocketObj.transform.parent = modelChild;
    }
}
