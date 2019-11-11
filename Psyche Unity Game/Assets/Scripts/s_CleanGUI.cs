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
    public int partId = 0; private int type = 0;
    
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
        else if(buttonType == "CRAFT")
        {
            setButton = GetComponent<Button>();
            //setButton.onClick.AddListener(SelectCraft);
            setButton.onClick.AddListener(SelectPart); type = 5;
        }
        else if(buttonType == "LAUNCHCRAFT")
        {
            setButton = GetComponent<Button>();
            setButton.onClick.AddListener(LaunchCraft);
        }
        else if(buttonType == "BODY")
        {
            setButton = GetComponent<Button>();
            setButton.onClick.AddListener(SelectPart); type = 1;
        }
        else if(buttonType == "SOLAR")
        {
            setButton = GetComponent<Button>();
            setButton.onClick.AddListener(SelectPart); type = 2;
        }
        else if(buttonType == "SENSOR")
        {
            setButton = GetComponent<Button>();
            setButton.onClick.AddListener(SelectPart); type = 3;
        }
        else if(buttonType == "ENGINE")
        {
            setButton = GetComponent<Button>();
            setButton.onClick.AddListener(SelectPart); type = 4;
        }
        else
        {//ERROR!
        }
    }
    public void SelectPart()
    {
        switch(type)
        {
            case 1:
            {//Body
                PlayerPrefs.SetInt("Body", partId);
                break;
            }
            case 2:
            {//Solar
                PlayerPrefs.SetInt("Solar", partId);
                break;
            }
            case 3:
            {//Sensor
                PlayerPrefs.SetInt("Sensor", partId);
                break;
            }
            case 4:
            {//Engine
                PlayerPrefs.SetInt("Engine", partId);
                break;
            }
            case 5:
            {//Premade
                PlayerPrefs.SetInt("Craft", partId);
                playerObj.GetComponent<s_CleanPlayer>().ctl_UpdatePlayerPrefab();
                break;
            }
            default:
            {
                break;
            }
        }
    }/*
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
    }*/
    public void SelectCraft()
    {
        PlayerPrefs.SetInt("Craft", partId);
        playerObj.GetComponent<s_CleanPlayer>().ctl_UpdatePlayerPrefab();
    }
    public void LaunchCraft()
    {//if player has craft selected
        SceneManager.LoadScene(3);
    }
}
