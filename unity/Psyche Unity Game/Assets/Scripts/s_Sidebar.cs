using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class s_Sidebar : MonoBehaviour
{
    public Button menu;
    public GameObject sidebar;
    public bool isScoreEnabled = true;
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
        StartCoroutine("ScoreTable"); sideScore.text = "";
    }

    private bool isNotFirstFrame = false;
    void Update()
    {//This is code is to fix/call methods that don't seem to work Unity's Awake/Start methods, even with everything declared & existing no amount of calling the methods seems to do anything.
        if(isNotFirstFrame)
        {
            //Find a set player's game volume from PlayerPrefs
            this.gameObject.GetComponent<SetVolume>().SetAudioLevel();
            //Display the stored score value.
            sideScore.text = "Score: " + PlayerPrefs.GetInt("Score");
        }
        else
            isNotFirstFrame = true;
    }

    IEnumerator ScoreTable()
    {
        int score = 0;
        while(true)
        {//Update the score every 2 seconds.
            if(isScoreEnabled)
            {
                if(score != PlayerPrefs.GetInt("Score"))
                {//This is flickering when updating, only going to update when score has changed.
                  score = PlayerPrefs.GetInt("Score"); //SetInt is set to 0 in mainmenucamera to stop possible nulls.
                  Debug.Log("Score: " + score);
                  sideScore.text = "Score: " + score;
                }
            }
            else
            {
                Debug.Log("Score Disabled");
                sideScore.text = "";
            }
            yield return new WaitForSeconds(2);
        }
    }
    public void ToggleSideBar()
    {
        sidebar.SetActive(!sidebar.active);
        if(!sidebar.activeSelf)
        {
          menu_Options.SetActive(false);
        }
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
