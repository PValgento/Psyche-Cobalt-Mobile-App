using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameEndController : MonoBehaviour
{
	private Button setButton;
	public string buttonType;
	void Start()
	{//Start is called before the first frame update
		if (buttonType == "RESTART")
		{
			setButton = GetComponent<Button>();
			setButton.onClick.AddListener(RestartGame);
		}
		else if (buttonType == "MAIN")
		{
			setButton = GetComponent<Button>();
			setButton.onClick.AddListener(MainMenu);
		}
		else if (buttonType == "EXIT")
		{
			setButton = GetComponent<Button>();
			setButton.onClick.AddListener(ExitGame);
		}
		else
		{//ERROR!
		}
	}

	public void GameOptions()
	{
		//Debug.Log("Options are not implented!");
		//this.transform.parent.gameObject.SetActive(false); //Hide the menu.
	}
	
	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public void MainMenu()
	{
		SceneManager.LoadScene("scene_Menu");
	}
	public void ExitGame()
	{//Exit the "game"?!
		Application.Quit();
		Debug.Log("The editor doesn't allow you to quit the game :)");
	}
}
