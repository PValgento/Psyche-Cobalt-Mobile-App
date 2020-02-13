using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sb_GUI_CleanRoom_Arrows : MonoBehaviour
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

    //Arrows:
    private Button customButton;
    private Text text_Body;
    private Button btnPrevBody;
    private Button btnNextBody;
    private Text text_Solar;
    private Button btnPrevSolar;
    private Button btnNextSolar;
    private Text text_Engine;
    private Button btnPrevEngine;
    private Button btnNextEngine;
    private bool isCustomArrows = false;
    void Start()
    {//Start is called before the first frame update
        premadeButton = GameObject.Find("btn_Premade").GetComponent<Button>();
        premadeButton.onClick.AddListener(PremadeButton);
        customButton = GameObject.Find("btn_Custom").GetComponent<Button>();
        customButton.onClick.AddListener(CustomButton);
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

        //Arrows:
        text_Body = GameObject.Find("txt_Body").GetComponent<Text>();
        btnPrevBody = GameObject.Find("btn_Body_Prev").GetComponent<Button>();
        btnNextBody = GameObject.Find("btn_Body_Next").GetComponent<Button>();
        text_Solar = GameObject.Find("txt_Solar").GetComponent<Text>();
        btnPrevSolar = GameObject.Find("btn_Side_Prev").GetComponent<Button>();
        btnNextSolar = GameObject.Find("btn_Side_Next").GetComponent<Button>();
        text_Engine = GameObject.Find("txt_Engine").GetComponent<Text>();
        btnPrevEngine = GameObject.Find("btn_Engine_Prev").GetComponent<Button>();
        btnNextEngine = GameObject.Find("btn_Engine_Next").GetComponent<Button>();
        /*Arrows-Disable
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
        */
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
        //Arrows
        customButton.gameObject.SetActive(false);
        customButton.transform.position = ignorePos;
        text_Body.gameObject.SetActive(false);
        text_Body.transform.position = ignorePos;
        btnPrevBody.gameObject.SetActive(false);
        btnPrevBody.transform.position = ignorePos;
        btnNextBody.gameObject.SetActive(false);
        btnNextBody.transform.position = ignorePos;
        text_Solar.gameObject.SetActive(false);
        text_Solar.transform.position = ignorePos;
        btnPrevSolar.gameObject.SetActive(false);
        btnPrevSolar.transform.position = ignorePos;
        btnNextSolar.gameObject.SetActive(false);
        btnNextSolar.transform.position = ignorePos;
        text_Engine.gameObject.SetActive(false);
        text_Engine.transform.position = ignorePos;
        btnPrevEngine.gameObject.SetActive(false);
        btnPrevEngine.transform.position = ignorePos;
        btnNextEngine.gameObject.SetActive(false);
        btnNextEngine.transform.position = ignorePos;

        bodyButton.gameObject.SetActive(false);
        bodyButton.transform.position = ignorePos;
        /*Arrows-Disable
        for(int i = 0; i < bodyOptions.Length; i++)
        {
            bodyOptions[i].gameObject.SetActive(false);
            bodyOptions[i].transform.position = ignorePos;
        }*/
        solarButton.gameObject.SetActive(false);
        solarButton.transform.position = ignorePos;
        /*Arrows-Disable
        for(int i = 0; i < solarOptions.Length; i++)
        {
            solarOptions[i].gameObject.SetActive(false);
            solarOptions[i].transform.position = ignorePos;
        }*/
        sensorButton.gameObject.SetActive(false);
        sensorButton.transform.position = ignorePos;
        /*Arrows-Disable
        for(int i = 0; i < sensorOptions.Length; i++)
        {
            sensorOptions[i].gameObject.SetActive(false);
            sensorOptions[i].transform.position = ignorePos;
        }*/
        engineButton.gameObject.SetActive(false);
        engineButton.transform.position = ignorePos;
        /*Arrows-Disable
        for(int i = 0; i < engineOptions.Length; i++)
        {
            engineOptions[i].gameObject.SetActive(false);
            engineOptions[i].transform.position = ignorePos;
        }*/
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
        if(isCustomArrows)
        {
          text_Body.gameObject.SetActive(true); text_Body.transform.localPosition = new Vector3(0f, currentLocation, 0f);
          btnPrevBody.gameObject.SetActive(true); btnPrevBody.transform.localPosition = new Vector3(-300f, currentLocation, 0f);
          btnNextBody.gameObject.SetActive(true); btnNextBody.transform.localPosition = new Vector3(300f, currentLocation, 0f);
          currentLocation -= buttonSpacing;
          text_Solar.gameObject.SetActive(true); text_Solar.transform.localPosition = new Vector3(0f, currentLocation, 0f);
          btnPrevSolar.gameObject.SetActive(true); btnPrevSolar.transform.localPosition = new Vector3(-300f, currentLocation, 0f);
          btnNextSolar.gameObject.SetActive(true); btnNextSolar.transform.localPosition = new Vector3(300f, currentLocation, 0f);
          currentLocation -= buttonSpacing;
          text_Engine.gameObject.SetActive(true); text_Engine.transform.localPosition = new Vector3(0f, currentLocation, 0f);
          btnPrevEngine.gameObject.SetActive(true); btnPrevEngine.transform.localPosition = new Vector3(-300f, currentLocation, 0f);
          btnNextEngine.gameObject.SetActive(true); btnNextEngine.transform.localPosition = new Vector3(300f, currentLocation, 0f);
        }
    }
    void DefaultLayout()
    {
        Debug.Log("Set up default layout.");
        activeButtons.Clear();
        activeButtons.Add(premadeButton);
        activeButtons.Add(customButton);
        /*Arrows-Disable
        activeButtons.Add(bodyButton);
        activeButtons.Add(solarButton);
        activeButtons.Add(sensorButton);
        activeButtons.Add(engineButton);
        */
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
    void CustomButton()
    {
        Debug.Log("Custom Button Clicked!");
        if(inDropDown == false)
        {
            activeButtons.Clear();
            activeButtons.Add(customButton);
            activeButtons.Add(spacerButton);
            isCustomArrows = true;
            /*
            activeButtons.Add(spacerButton);
            activeButtons.Add(bodyButton);
            activeButtons.Add(solarButton);
            activeButtons.Add(sensorButton);
            activeButtons.Add(engineButton);*/
            CollaspeMenuLayout();
        }
        else
        {
            isCustomArrows = false;
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
            /*Arrows-Disable
            for(int i = 0; i < bodyOptions.Length; i++)
            {
                activeButtons.Add(bodyOptions[i]);
            }*/
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
            /*Arrows-Disable
            for(int i = 0; i < solarOptions.Length; i++)
            {
                activeButtons.Add(solarOptions[i]);
            }*/
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
            /*Arrows-Disable
            for(int i = 0; i < sensorOptions.Length; i++)
            {
                activeButtons.Add(sensorOptions[i]);
            }*/
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
            /*Arrows-Disable
            for(int i = 0; i < engineOptions.Length; i++)
            {
                activeButtons.Add(engineOptions[i]);
            }*/
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
