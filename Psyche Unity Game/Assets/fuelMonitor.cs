using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuelMonitor : MonoBehaviour
{
	Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


		GameObject temp = GameObject.Find("Slider_Fuel");
		if (temp != null)
		{
			// Get the Slider Component
			slider = temp.GetComponent<Slider>();

			// If a Slider Component was found on the GameObject.
			if (slider != null) {
				temp = GameObject.Find("PlayerObj");
				FuelTracker ft = temp.GetComponent<FuelTracker>();
				if (ft != null)
				{
					slider.value = ft.currentFuel/ft.capacity;
				}
				else
				{
					Debug.LogError("[" + temp.name + "] - Does not contain a FuelTracker Component!");
				}
			}
			else
			{

				Debug.LogError("[" + temp.name + "] - Does not contain a Slider Component!");
			}
		}
	}
}
