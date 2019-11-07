using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
	public AudioMixer mixer;
	public void SetLevel (float sliderValue)
	{
		// Make volume change accurately
		float logarithmicValue = Mathf.Log10(sliderValue) * 20;

		mixer.SetFloat("GameVol", logarithmicValue);
	}

}
