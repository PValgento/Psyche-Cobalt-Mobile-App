using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseTrigger : MonoBehaviour
{
	public GameObject baseUI;
	public GameObject loseUI;
	public GameObject player;
	Slider slider;

	private void Start()
	{
		slider = this.GetComponent<Slider>();
	}

	// Update is called once per frame
	void Update()
    {
        if(slider.value <= 0)
		{
			baseUI.SetActive(false);
			loseUI.SetActive(true);

			var freeze = new Vector2(0, 0);
			player.GetComponent<Rigidbody2D>().velocity = freeze;
		}
    }
}
