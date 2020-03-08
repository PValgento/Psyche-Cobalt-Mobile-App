using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
	public GameObject baseUI;
	public GameObject winUI;
	public GameObject player;
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		baseUI.SetActive(false);
		winUI.SetActive(true);

		var freeze = new Vector2(0, 0);
		player.GetComponent<Rigidbody2D>().velocity = freeze;

		//SpaceMovementController controller = player.GetComponent<SpaceMovementController>();

	}
}
