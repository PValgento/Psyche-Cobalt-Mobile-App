using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
	public AudioMixer mixer;
	void Awake()
	{
			Slider temp = this.gameObject.GetComponent<Slider>();
			if(temp != null)
			{//If object has a slider, set the slider correctly.
					temp.value = PlayerPrefs.GetFloat("GameVolume");
			}
			//Call to set audio to saved values.
			SetAudioLevel();
	}
	public void SaveGameVolume(float sliderValue)
	{//Trying to fix issue of game not saving audio level and resetting it by separating saving & setting logic.
			//Save new audio value.
			PlayerPrefs.SetFloat("GameVolume", sliderValue);
			//Call to set audio to saved values.
			SetAudioLevel();
	}
	public void SetAudioLevel ()
	{
			// Make volume change accurately
			//float logarithmicValue = Mathf.Log10(sliderValue) * 20;
			float logarithmicValue = Mathf.Log10(PlayerPrefs.GetFloat("GameVolume")) * 20;

			mixer.SetFloat("GameVol", logarithmicValue);
			//PlayerPrefs.SetFloat("GameVolume", sliderValue);
	}
}
