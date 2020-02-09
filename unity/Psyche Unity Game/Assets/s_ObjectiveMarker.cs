using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_ObjectiveMarker : MonoBehaviour
{
	public GameObject Objective;
	public float MaxDistance;
	public float markerDistFromSprite;

	// Update is called once per frame
	void Update()
    {

		// Get direction vector from player to the objective
		var direction = Objective.transform.position - transform.parent.position;
		direction.z = 0;

		bool active = direction.magnitude > MaxDistance;
		Debug.Log("Active: " + active);
		if (active)
		{
			//Set relative location of sprite to player
			transform.localPosition = markerDistFromSprite * direction.normalized;

			var angle = Mathf.Atan2(direction.x, -direction.y) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		}
		SetMarkersActive(active);
	}

	void SetMarkersActive(bool val)
	{
		foreach (Transform c in transform)
		{
			c.gameObject.SetActive(val);
		}	
	}
}
