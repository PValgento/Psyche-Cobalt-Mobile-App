using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class s_TutorialGUI : MonoBehaviour
{
    void Awake()
    {
        //This causes a collision on begin in launch scene.
        PlayerPrefs.SetInt("Craft", -1);
        PlayerPrefs.SetInt("Body", 0);
        PlayerPrefs.SetInt("Sensor", 0);
        PlayerPrefs.SetInt("Solar", 0);
        PlayerPrefs.SetInt("Engine", 0);
    }
    public void LaunchTutorial()
    {
        PlayerPrefs.SetInt("SCENE", 7);
        SceneManager.LoadScene(5);//7
    }
    public void SpaceTutorial()
    {
        PlayerPrefs.SetInt("SCENE", 8);
        SceneManager.LoadScene(5);//8
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);//0
    }
}
