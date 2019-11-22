using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class s_Sidebar : MonoBehaviour
{
    public Button menu;
    public GameObject sidebar;

    protected Button sideHome;
    protected Button sideOption;
    protected Button sideLearn;
    protected Button sidePsyche;
    protected GameObject menu_Options;
    protected Text sideScore;
    void Awake()
    {//Get all the objects.
        menu = GameObject.Find("btn_Menu").GetComponent<Button>();
        sideScore = GameObject.Find("txt_Score").GetComponent<Text>();
        menu_Options = GameObject.Find("menu_Options"); 
        menu.onClick.AddListener(ToggleSideBar);
        
        sidebar = GameObject.Find("menu_Sidebar"); 
        sideHome = GameObject.Find("btn_Home").GetComponent<Button>();
        sideHome.onClick.AddListener(GoHome);
        sideOption = GameObject.Find("btn_Options").GetComponent<Button>();
        sideOption.onClick.AddListener(GameOptions);
        sideLearn = GameObject.Find("btn_Learn").GetComponent<Button>();
        sideLearn.onClick.AddListener(LearnMore);
        sidePsyche = GameObject.Find("btn_Psyche").GetComponent<Button>();
        sidePsyche.onClick.AddListener(NASA_Psyche);

        //This MUST be last, cuz Unity can't find hidden objects.
        menu_Options.SetActive(false); sidebar.SetActive(false);
        StartCoroutine("ScoreTable");
    }
    IEnumerator ScoreTable()
    {
        int score = 0;
        while(true)
        {//Update the score every 2 seconds.
            score = PlayerPrefs.GetInt("Score"); //SetInt is set to 0 in mainmenucamera to stop possible nulls.
            Debug.Log("Score: " + score);
            sideScore.text = "Score: " + score;
            yield return new WaitForSeconds(2);
        }
    }
    public void ToggleSideBar()
    {
        sidebar.SetActive(!sidebar.active);
    }
    public void GoHome()
    {//Go back to main menu.
        SceneManager.LoadScene(0);
    }
    protected void GameOptions()
    {//Display the game options.
        Debug.Log("Options!");
        menu_Options.SetActive(!menu_Options.active);
    }
    protected void LearnMore()
    {//Educational stuff.
        Application.OpenURL("https://www.nasa.gov/mission_pages/psyche/overview/index.html");
    }
    protected void NASA_Psyche()
    {//Learn more about Psyche.
        Application.OpenURL("https://www.nasa.gov/psyche");
    }
}