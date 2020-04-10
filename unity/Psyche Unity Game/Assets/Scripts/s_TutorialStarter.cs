using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class s_TutorialStarter : MonoBehaviour
{//When the player clicks the start button hide all hints and enable the player.
    public GameObject tutorial_Player;
    public GameObject tutorial_Hide;
    public GameObject tutorial_Dist;
    public GameObject tutorial_Steer;
    public GameObject tutorial_Begin;
    public GameObject tutorial_Arrow;

    public GameObject tutorial_Welcome;
    public GameObject tutorial_Objective;

    public void StartLevel()
    {
        if(tutorial_Hide != null)
            tutorial_Hide.SetActive(true);
        if(tutorial_Dist != null)
            tutorial_Dist.SetActive(false);
        if(tutorial_Steer != null)
            tutorial_Steer.SetActive(false);
        if(tutorial_Arrow != null)
            tutorial_Arrow.SetActive(false);
        if(tutorial_Begin != null)
            tutorial_Begin.SetActive(false);

        if(tutorial_Welcome != null)
            tutorial_Welcome.SetActive(false);
        if(tutorial_Objective != null)
            tutorial_Objective.SetActive(false);

        if(tutorial_Player != null)
            tutorial_Player.SetActive(true);
        else
        {//Should not happen!
            SceneManager.LoadScene(6);
        }
    }
}
