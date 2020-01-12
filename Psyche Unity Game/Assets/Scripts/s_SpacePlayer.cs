using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_SpacePlayer : sb_PlayerConstruction
{
    void Awake()
    {//Start is called before the first frame update
        ctl_PlayerAwake();
        ctl_UpdatePlayerPrefab();
	}

	private void Start()
	{
		Vector3 startPos = new Vector3(-1000, 150, 0);
		transform.position = startPos;
	}

	void Update()
    {//Update is called once per frame

    }
    public void ctl_UpdatePlayerPrefab()
    {
        this.ctl_UsePlayerPrefs(new Vector3(0f,0f,0f));
    }
}
