using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_CleanPlayer : sb_PlayerConstruction
{
    void Awake()
    {//Start is called before the first frame update
        ctl_PlayerAwake();
        ctl_UpdatePlayerPrefab();
        ctl_SetCameraPosition(new Vector3(0f, 7f, -10f));
    }

    void Update()
    {//Update is called once per frame

    }
    public void ctl_UpdatePlayerPrefab()
    {
        this.ctl_UsePlayerPrefs(new Vector3(0f,7.6f,0f));
    }
}
