using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sb_Loading : MonoBehaviour
{
    public Text txt_Hint;
    private List<string> loadingHints = new List<string>();
    private float minLoadingTime = 3f;
    private float currentDelay = 0f;
    private int nextScene = 0;

    void Awake()
    {
        loadingHints.Add("The buddy system is essential for your survival it gives the enemy someone else to shoot at.");
        loadingHints.Add("Cold?, Go to the corner it is 90 degrees!");
        loadingHints.Add("Josh is bad with jokes...");
        loadingHints.Add("1 by 4 by 9");
        if(txt_Hint != null)
        {
            txt_Hint.text = loadingHints[Random.Range(0, loadingHints.Count)];
        }
        nextScene = PlayerPrefs.GetInt("SCENE");
    }

    void Update()
    {// Update is called once per frame
        currentDelay += Time.deltaTime;
        if(currentDelay >= minLoadingTime)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
