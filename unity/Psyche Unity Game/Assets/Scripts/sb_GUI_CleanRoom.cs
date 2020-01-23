using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sb_GUI_CleanRoom : MonoBehaviour
{
    private List<Button> activeButtons = new List<Button>();
    private int topLocation = -200;//Was 450 want to be able to see craft though.
    private int bottomLocation = -1000;//200,20,30
    private int buttonSpacing = 90;
    private bool inDropDown = false;

    private Button premadeButton;
    private Button[] premadeOptions;
    private Button bodyButton;
    private Button[] bodyOptions;
    private Button solarButton;
    private Button[] solarOptions;
    private Button sensorButton;
    private Button[] sensorOptions;
    private Button engineButton;
    private Button[] engineOptions;
    private Button spacerButton;
    private Button launchButton;

    void Start()
    {//Start is called before the first frame update
        premadeButton = GameObject.Find("btn_Premade").GetComponent<Button>();
        premadeButton.onClick.AddListener(PremadeButton);
        bodyButton = GameObject.Find("btn_Body").GetComponent<Button>();
        bodyButton.onClick.AddListener(BodyButton);
        solarButton = GameObject.Find("btn_Solar").GetComponent<Button>();
        solarButton.onClick.AddListener(SolarButton);
        sensorButton = GameObject.Find("btn_Sensor").GetComponent<Button>();
        sensorButton.onClick.AddListener(SensorButton);
        engineButton = GameObject.Find("btn_Engine").GetComponent<Button>();
        engineButton.onClick.AddListener(EngineButton);
        
        launchButton = GameObject.Find("btn_Launch").GetComponent<Button>();
        launchButton.onClick.AddListener(LaunchButton);
        spacerButton = GameObject.Find("btn_Spacer").GetComponent<Button>();
        //PremadeOptions
        premadeOptions = new Button[3];
        premadeOptions[0] = GameObject.Find("premade_craftOne").GetComponent<Button>();
        premadeOptions[1] = GameObject.Find("premade_craftTwo").GetComponent<Button>();
        premadeOptions[2] = GameObject.Find("premade_craftThree").GetComponent<Button>();
        //BodyOptions
        bodyOptions = new Button[3];
        bodyOptions[0] = GameObject.Find("bodyOne").GetComponent<Button>();
        bodyOptions[1] = GameObject.Find("bodyTwo").GetComponent<Button>();
        bodyOptions[2] = GameObject.Find("bodyThree").GetComponent<Button>();
        //SolarOptions
        solarOptions = new Button[3];
        solarOptions[0] = GameObject.Find("solarOne").GetComponent<Button>();
        solarOptions[1] = GameObject.Find("solarTwo").GetComponent<Button>();
        solarOptions[2] = GameObject.Find("solarThree").GetComponent<Button>();
        //SensorOptions
        sensorOptions = new Button[3];
        sensorOptions[0] = GameObject.Find("sensorOne").GetComponent<Button>();
        sensorOptions[1] = GameObject.Find("sensorTwo").GetComponent<Button>();
        sensorOptions[2] = GameObject.Find("sensorThree").GetComponent<Button>();
        //EngineOptions
        engineOptions = new Button[3];
        engineOptions[0] = GameObject.Find("engineOne").GetComponent<Button>();
        engineOptions[1] = GameObject.Find("engineTwo").GetComponent<Button>();
        engineOptions[2] = GameObject.Find("engineThree").GetComponent<Button>();
        DefaultLayout();
    }
    void Update()
    {//Update is called once per frame
        
    }
    void DisableAll()
    {
        Vector3 ignorePos = new Vector3(193f, -300f, 0f);
        premadeButton.gameObject.SetActive(false);
        premadeButton.transform.position = ignorePos;
        for(int i = 0; i < premadeOptions.Length; i++)
        {
            premadeOptions[i].gameObject.SetActive(false);
            premadeOptions[i].transform.position = ignorePos;
        }
        bodyButton.gameObject.SetActive(false);
        bodyButton.transform.position = ignorePos;
        for(int i = 0; i < bodyOptions.Length; i++)
        {
            bodyOptions[i].gameObject.SetActive(false);
            bodyOptions[i].transform.position = ignorePos;
        }
        solarButton.gameObject.SetActive(false);
        solarButton.transform.position = ignorePos;
        for(int i = 0; i < solarOptions.Length; i++)
        {
            solarOptions[i].gameObject.SetActive(false);
            solarOptions[i].transform.position = ignorePos;
        }
        sensorButton.gameObject.SetActive(false);
        sensorButton.transform.position = ignorePos;
        for(int i = 0; i < sensorOptions.Length; i++)
        {
            sensorOptions[i].gameObject.SetActive(false);
            sensorOptions[i].transform.position = ignorePos;
        }
        engineButton.gameObject.SetActive(false);
        engineButton.transform.position = ignorePos;
        for(int i = 0; i < engineOptions.Length; i++)
        {
            engineOptions[i].gameObject.SetActive(false);
            engineOptions[i].transform.position = ignorePos;
        }
    }
    void CollaspeMenuLayout()
    {
        Debug.Log("CollaspeMenuLayout: " + activeButtons.Count);
        int currentLocation = topLocation;
        int i = 0;
        DisableAll();
        while(i < activeButtons.Count)// && currentLocation > bottomLocation)
        {
            if(currentLocation > bottomLocation)
            {
                Debug.Log("Messing buttons");
                activeButtons[i].gameObject.SetActive(true);
                activeButtons[i].transform.localPosition = new Vector3(0f, currentLocation, 0f);
                currentLocation -= buttonSpacing;
            }
            i++;
        }
    }
    void DefaultLayout()
    {
        Debug.Log("Set up default layout.");
        activeButtons.Clear();
        activeButtons.Add(premadeButton);
        activeButtons.Add(bodyButton);
        activeButtons.Add(solarButton);
        activeButtons.Add(sensorButton);
        activeButtons.Add(engineButton);
        CollaspeMenuLayout();
    }
    void PremadeButton()
    {
        Debug.Log("Premade Button Clicked!");
        if(inDropDown == false)
        {
            activeButtons.Clear();
            activeButtons.Add(premadeButton);
            activeButtons.Add(spacerButton);
            for(int i = 0; i < premadeOptions.Length; i++)
            {
                activeButtons.Add(premadeOptions[i]);
            }/*
            activeButtons.Add(spacerButton);
            activeButtons.Add(bodyButton);
            activeButtons.Add(solarButton);
            activeButtons.Add(sensorButton);
            activeButtons.Add(engineButton);*/
            CollaspeMenuLayout();
        }
        else
        {
            DefaultLayout();
        }
        inDropDown = !inDropDown;
    }
    void BodyButton()
    {
        Debug.Log("Body Button Clicked!");
        if(inDropDown == false)
        {
            activeButtons.Clear();
            activeButtons.Add(bodyButton);
            activeButtons.Add(spacerButton);
            for(int i = 0; i < bodyOptions.Length; i++)
            {
                activeButtons.Add(bodyOptions[i]);
            }
            CollaspeMenuLayout();
        }
        else
        {
            DefaultLayout();
        }
        inDropDown = !inDropDown;
    }
    void SolarButton()
    {
        Debug.Log("Solar Button Clicked!");
        if(inDropDown == false)
        {
            activeButtons.Clear();
            activeButtons.Add(solarButton);
            activeButtons.Add(spacerButton);
            for(int i = 0; i < solarOptions.Length; i++)
            {
                activeButtons.Add(solarOptions[i]);
            }
            CollaspeMenuLayout();
        }
        else
        {
            DefaultLayout();
        }
        inDropDown = !inDropDown;
    }
    void SensorButton()
    {
        Debug.Log("Sensor Button Clicked!");
        if(inDropDown == false)
        {
            activeButtons.Clear();
            activeButtons.Add(sensorButton);
            activeButtons.Add(spacerButton);
            for(int i = 0; i < sensorOptions.Length; i++)
            {
                activeButtons.Add(sensorOptions[i]);
            }
            CollaspeMenuLayout();
        }
        else
        {
            DefaultLayout();
        }
        inDropDown = !inDropDown;
    }
    void EngineButton()
    {
        Debug.Log("Engine Button Clicked!");
        if(inDropDown == false)
        {
            activeButtons.Clear();
            activeButtons.Add(engineButton);
            activeButtons.Add(spacerButton);
            for(int i = 0; i < engineOptions.Length; i++)
            {
                activeButtons.Add(engineOptions[i]);
            }
            CollaspeMenuLayout();
        }
        else
        {
            DefaultLayout();
        }
        inDropDown = !inDropDown;
    }
    void LaunchButton()
    {
        Debug.Log("Launch Button Clicked!");
        SceneManager.LoadScene(3);
    }
}
