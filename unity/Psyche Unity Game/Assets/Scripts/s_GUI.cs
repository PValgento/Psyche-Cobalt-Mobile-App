using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class s_GUI : MonoBehaviour
{
    private Button setButton;
    public string buttonType = "";
    void Start()
    {//Start is called before the first frame update
        if(buttonType == "QUIT")
        {
            setButton = GetComponent<Button>();
            setButton.onClick.AddListener(ExitGame);
        }
        else if(buttonType == "RESTART")
        {
            setButton = GetComponent<Button>();
            setButton.onClick.AddListener(RestartGame);
        }
        else if(buttonType == "START")
        {
            setButton = GetComponent<Button>();
            setButton.onClick.AddListener(StartGame);
        }
        else if(buttonType == "OPTION")
        {
            setButton = GetComponent<Button>();
            setButton.onClick.AddListener(GameOptions);
        }
        else if(buttonType == "CLEANROOM")
        {
            setButton = GetComponent<Button>();
            setButton.onClick.AddListener(GoCleanRoom);
        }
        else if(buttonType == "LAUNCH")
        {
            setButton = GetComponent<Button>();
            setButton.onClick.AddListener(GoLaunch);
        }
        else if(buttonType == "SPACE")
        {
            setButton = GetComponent<Button>();
            setButton.onClick.AddListener(GoSpace);
        }
        else
        {//ERROR!
        }
    }

    public void StartGame()
    {
        Debug.Log("Loading Scene 1");
        SceneManager.LoadScene(1);
    }
    public void GameOptions()
    {
        //Debug.Log("Options are not implented!");
        //this.transform.parent.gameObject.SetActive(false); //Hide the menu.
    }
    public void ExitGame()
    {//Exit the "game"?!
        Application.Quit();
        Debug.Log("The editor doesn't allow you to quit the game :)");
    }
    public void RestartGame()
    {
        GameObject gameController;
        gameController = GameObject.Find("GameController");
        gameController.GetComponent<s_GameController>().ctl_RestartGame();
    }
    public void GoCleanRoom()
    {
        SceneManager.LoadScene(2);
    }
    public void GoLaunch()
    {
        SceneManager.LoadScene(3);
    }
    public void GoSpace()
    {
        SceneManager.LoadScene(4);
    }
}
