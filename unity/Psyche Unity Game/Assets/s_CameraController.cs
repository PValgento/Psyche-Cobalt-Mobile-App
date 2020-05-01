﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_CameraController : MonoBehaviour
{
		public GameObject player;        //Public variable to store a reference to the player game object
		public float zoom;

		private Vector3 offset;            //Private variable to store the offset distance between the player and camera

		void Start()
		{//Calculate and store the offset value by getting the distance between the player's position and camera's position.
				offset = transform.position - player.transform.position;
				zoom = 12; //Changed from 5 --Josh
		}

		void Update()
		{
				if (Input.GetAxis("Mouse ScrollWheel") > 0)
				{
						if (zoom > 3)
								zoom -= 1;
				}
				if (Input.GetAxis("Mouse ScrollWheel") < 0)
				{
						if (zoom < 29)
							zoom += 1;
				}
				GetComponent<Camera>().orthographicSize = zoom;
		}

		void LateUpdate()
		{//LateUpdate is called after Update each frame
			//Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
			transform.position = player.transform.position + offset;
		}
}
