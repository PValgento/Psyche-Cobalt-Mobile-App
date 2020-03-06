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
        loadingHints.Add("Loading hint #1.");
        loadingHints.Add("Loading hint #2.");
        loadingHints.Add("Loading hint #3.");
        loadingHints.Add("Loading hint #4.");
        loadingHints.Add("Loading hint #5.");
        loadingHints.Add("Loading hint #6.");
        loadingHints.Add("Loading hint #7.");
        loadingHints.Add("Loading hint #8.");
        loadingHints.Add("Loading hint #9.");
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
