using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelTracker : MonoBehaviour
{
	public float currentFuel;
	public float capacity;

    // Start is called before the first frame update
    void Start()
    {
		currentFuel = 100;
		capacity = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	/**
	 * Tuned to be used per physics update. 
	*/
	public bool SpendFuel(float fuelAmount)
	{
		if (currentFuel >= fuelAmount)
		{
			currentFuel -= fuelAmount;
			return true;
		}
		else
			return false;
	}

	public void FillFuel(float fuelAmount)
	{
		//If current fuel would be more than capacity, set fuel to capacity
		currentFuel = Mathf.Min(currentFuel + fuelAmount, capacity);
	}
	public void AlterCap(float capChange)
	{
		capacity = Mathf.Min(capChange + capacity, 0);
	}
}
