using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpaceMovementController : MonoBehaviour
{
	public GameObject Model;
	Slider ThrottleSlider;
	float currentThrottle = 0;
	float speed = 0;
	Vector2 direction;
	Vector2 playerPos;
	Rigidbody2D rb;
	

	// Start is called before the first frame update
    void Start()
    {
		rb = this.GetComponent<Rigidbody2D>();
		direction[0] = 1;
		direction[1] = 0;

		GameObject temp = GameObject.Find("Slider_Throttle");
		if (temp != null)
		{
			// Get the Slider Component
			ThrottleSlider = temp.GetComponent<Slider>();

			// If a Slider Component was found on the GameObject.
			if (ThrottleSlider != null)

			{
				// This is a Conditional Statement. 
				// Basically if volumeLevel isn't null, 
				// then it uses it's value, 
				// otherwise it uses the DefaultVolumeLevel that we've set above.
				ThrottleSlider.normalizedValue = PlayerPrefs.HasKey("VolumeLevel") ? PlayerPrefs.GetFloat("VolumeLevel") : 0;
			}
			else
			{
				Debug.LogError("[" + temp.name + "] - Does not contain a Slider Component!");
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
		currentThrottle = ThrottleSlider.value;
		setDirection();
    }

	void FixedUpdate()
	{
		moveShip(direction, currentThrottle);
	}

	void moveShip(Vector2 direction, float force)
	{
		rb.AddForce(direction * force);
	}

	public void setDirection()
	{
		
		//If we're NOT over UI we can consider it wanting to change the direction.
		if ( !EventSystem.current.IsPointerOverGameObject())
		{
			Debug.Log("Input not over UI");
			if (Input.touchCount > 0 || Input.GetMouseButton(0))
			{
				Debug.Log("Test setting direction detected");
				Vector3 mousePos = Input.mousePosition;
				mousePos = Camera.main.ScreenToWorldPoint(mousePos);

				direction[0] = mousePos.x - transform.position.x;
				direction[1] = mousePos.y - transform.position.y;


				//float theta = Mathf.Atan2(direction[1], direction[0] * (180 / Mathf.PI));
				//Debug.Log("Theta: " + theta);

				//TODO: Rotate the object
				Vector3 rotVec = new Vector3(direction[0], direction[1], 0);
				Model.transform.rotation = Quaternion.LookRotation(rotVec);

			}
		}
	}
}

