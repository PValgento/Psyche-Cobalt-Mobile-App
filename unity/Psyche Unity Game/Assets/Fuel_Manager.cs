using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel_Manager : MonoBehaviour
{
	public Slider slider;
	public float MaxFuel;
	public float CurrentFuel;

	// Update is called once per frame
	void Update()
    {
		slider.maxValue = MaxFuel;
		slider.value = CurrentFuel;
    }

	public bool SetFuel(float fuel)
	{
		if (fuel > 0 && fuel <= MaxFuel)
		{
			CurrentFuel = fuel;
			return true;
		}
		else
			return false;
			
	}
	public bool SetFuelCap(float fuel)
	{
		if (fuel > 0)
		{
			MaxFuel = fuel;
			return true;
		}
		else
			return false;
	}
	public void AdjustFuel(float fuel)
	{
		float adjustedFuel = CurrentFuel + fuel;
		if (adjustedFuel < 0)
			CurrentFuel = 0;
		else if (adjustedFuel > MaxFuel)
			CurrentFuel = MaxFuel;
		else
			CurrentFuel = adjustedFuel;
	}
}
