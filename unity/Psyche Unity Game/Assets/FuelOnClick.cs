using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// For player control, if only a click is registered, allow it to be set for a few frames and then drop to zero.
/// </summary>
public class FuelOnClick : MonoBehaviour
{
	Slider slider;

	private bool recentClick = false;
	private int frameCount = 0;
	private float clickValue = 0;

	// Start is called once when object created
	void Start()
	{
		GameObject temp = GameObject.Find("ThrottleSlider");
		if (temp != null)
		{
			// Get the Slider Component
			slider = temp.GetComponent<Slider>();

			// If a Slider Component was found on the GameObject.
			if (slider != null)
				slider.normalizedValue = PlayerPrefs.HasKey("VolumeLevel") ? PlayerPrefs.GetFloat("VolumeLevel") : 0;
			else
				Debug.LogError("[" + temp.name + "] - Does not contain a Slider Component!");
		}
	}
	
	// Update is called once per frame
    void Update()
    {
		if (recentClick)
		{
			if (frameCount < 15) {			
				slider.value = System.Math.Max(slider.value - (float) (0.06667 * clickValue), 0);
				frameCount++;
			}
			else {
				recentClick = false;
			}
		}    
    }

	//
	public void OnClick()
	{
		clickValue = slider.value;
		frameCount = 0;
		recentClick = true;
	}

	public void CancelChange()
	{
		recentClick = false;
	}
}
