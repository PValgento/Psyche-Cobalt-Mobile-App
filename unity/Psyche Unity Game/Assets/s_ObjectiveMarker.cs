using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_ObjectiveMarker : MonoBehaviour
{
	public GameObject ObjectiveMarker;
	public GameObject Objective;
	public GameObject Player;

	private Vector2 objPosition;
	private Vector2 playerPosition;
	private float rotAngle;

	void Awake()
	{
		objPosition = new Vector2(Objective.transform.position.x,Objective.transform.position.y);
	}

    // Update is called once per frame
    void Update()
    {
		objPosition = new Vector2(Objective.transform.position.x, Objective.transform.position.y); //if we ever want moving objective
		playerPosition = new Vector2(Player.transform.position.x, Player.transform.position.y);

		Vector2 direction = objPosition - playerPosition;
		
		direction = direction.normalized;
		
		Vector3 rotVec = new Vector3(direction[0], direction[1], 0);
		Quaternion vec = Quaternion.LookRotation(rotVec);
		Debug.Log("Rotation Vector: (" + vec[0] + ", " + vec[1] + ", " + vec[2] + ")");

		//ObjectiveMarker.GetComponent<RectTransform>().rotation = 
		//GetComponent<RectTransform>().localEulerAngles = new Vector3(0, 0, rotAngle);
	}
}
