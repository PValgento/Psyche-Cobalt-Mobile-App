using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class s_CleanGUI : MonoBehaviour
{
    private Button setButton;
    private GameObject playerObj;
    public string buttonType = "";
    
    void Awake()
    {
        playerObj = GameObject.Find("PlayerObj");
    }
    void Start()
    {//Start is called before the first frame update
        if(buttonType == "SELECTCRAFT")
        {
            setButton = GetComponent<Button>();
            setButton.onClick.AddListener(SelectCraft);
        }
        else if(buttonType == "CRAFT1")
        {
            setButton = GetComponent<Button>();
            setButton.onClick.AddListener(SelectCraft1);
        }
        else if(buttonType == "CRAFT2")
        {
            setButton = GetComponent<Button>();
            setButton.onClick.AddListener(SelectCraft2);
        }
        else if(buttonType == "CRAFT3")
        {
            setButton = GetComponent<Button>();
            setButton.onClick.AddListener(SelectCraft3);
        }
        else if(buttonType == "LAUNCHCRAFT")
        {
            setButton = GetComponent<Button>();
            setButton.onClick.AddListener(LaunchCraft);
        }
        else
        {//ERROR!
        }
    }
    public void SelectCraft()
    {
        this.gameObject.SetActive(false);
        GameObject canvasUI = GameObject.Find("Canvas");
        GameObject craftButtonList = canvasUI; //Get rid of uninit error.
        foreach(Transform child in canvasUI.transform)
        {
            if(child.name == "PremadeCrafts")
            {
                craftButtonList = child.gameObject;
            }
        }
        //craftButtonList = canvasUI.Transform.FindChildByRecursion("PremadeCrafts");
        if(craftButtonList != null && craftButtonList.name != "Canvas")
            craftButtonList.SetActive(true);
    }
    public void SelectCraft1()
    {
        PlayerPrefs.SetInt("Craft", 1);
        playerObj.GetComponent<s_CleanPlayer>().ctl_UpdatePlayerPrefab(1);
    }
    public void SelectCraft2()
    {
        PlayerPrefs.SetInt("Craft", 2);
        playerObj.GetComponent<s_CleanPlayer>().ctl_UpdatePlayerPrefab(2);
    }
    public void SelectCraft3()
    {
        PlayerPrefs.SetInt("Craft", 3);
        playerObj.GetComponent<s_CleanPlayer>().ctl_UpdatePlayerPrefab(3);
    }
    public void LaunchCraft()
    {
        /* if player has craft selected */
        SceneManager.LoadScene(3);
    }
}
