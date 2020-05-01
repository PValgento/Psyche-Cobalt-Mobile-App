using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_SpacePlayer : sb_PlayerConstruction
{
    //Information Arrows
    protected GameObject objectiveAnchor;
    protected GameObject velocityAnchor;
    GameObject target;
    private Vector3 lastPosition = Vector3.zero;

    void Awake()
    {
        ctl_PlayerAwake();
        ctl_UpdatePlayerPrefab();

        //Find Information Arrows, set them to be children, and reset positions..
        target = GameObject.Find("Objective");
        objectiveAnchor = GameObject.Find("ObjectiveAnchor");
        velocityAnchor = GameObject.Find("VelocityAnchor");
        objectiveAnchor.transform.parent = this.transform;
        velocityAnchor.transform.parent = this.transform;
        objectiveAnchor.transform.localPosition = Vector3.zero;
        velocityAnchor.transform.localPosition = Vector3.zero;
  	}

  	private void Start()
  	{
  		Vector3 startPos = new Vector3(-1000, 150, 0);
  		transform.position = startPos;
  	}

    void FixedUpdate()
    {//Update the location arrows.
        Vector3 dir = target.transform.position - this.transform.position;
        Quaternion rot = Quaternion.AngleAxis(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, Vector3.up);

        objectiveAnchor.transform.rotation = Quaternion.Euler(new Vector3(rot.eulerAngles.x, rot.eulerAngles.z, rot.eulerAngles.y-90f));
        //Reuse dir & rot for velocityAnchor.
        dir = this.transform.position - lastPosition;
        rot = Quaternion.AngleAxis(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, Vector3.up);
        velocityAnchor.transform.rotation = Quaternion.Euler(new Vector3(rot.eulerAngles.x, rot.eulerAngles.z, rot.eulerAngles.y-90f));
        lastPosition = this.transform.position;
    }
    public void ctl_UpdatePlayerPrefab()
    {
        this.ctl_UsePlayerPrefs(new Vector3(0f,0f,0f));
    }
}
