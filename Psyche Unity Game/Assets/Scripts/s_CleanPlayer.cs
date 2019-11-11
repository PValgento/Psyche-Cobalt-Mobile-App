using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_CleanPlayer : sb_PlayerConstruction
{
    void Awake()
    {//Start is called before the first frame update
        ctl_PlayerAwake();
        ctl_UpdatePlayerPrefab();
    }

    void Update()
    {//Update is called once per frame
        
    }
    public void ctl_UpdatePlayerPrefab()
    {
        this.ctl_UsePlayerPrefs();
    }
}
