using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sb_Loading : MonoBehaviour
{
    public Text txt_Hint;
    private List<string> loadingHints = new List<string>();
    private float minLoadingTime = 24f;
    private float currentDelay = 0f;
    private int nextScene = 0;

    void Awake()
    {
        loadingHints.Add("The Psyche mission was chosen by NASA on January 4, 2017.");
        loadingHints.Add("Psyche is the name of an asteroid orbiting the Sun between Mars and Jupiter and the name of a NASA space mission to visit that asteroid, led by ASU. Psyche is the first mission to a world likely made largely of metal rather than rock or ice.");
        loadingHints.Add("Psyche is the 14th mission selected for NASA’s Discovery Program, a series of relatively low-cost missions to solar system targets.");
        loadingHints.Add("The asteroid Psyche may be able to tell us how Earth’s core and the cores of the other terrestrial (rocky) planets came to be.");
        loadingHints.Add("Because we cannot see or measure Earth’s core directly, the Psyche asteroid may offer a unique window into the violent history of collisions and accretion that created the terrestrial planets.");
        loadingHints.Add("Psyche Timeline:\n\n2022: Launch of Psyche spacecraft from Cape Canaveral, FL\n2023: Psyche spacecraft flyby of Mars\n2026: Psyche spacecraft arrives in asteroid’s orbit\n2026-2027: Psyche spacecraft orbits the Psyche asteroid for 21 months");
        loadingHints.Add("Once the mission is complete, the spacecraft will stay in orbit around (16) Psyche, like a moon.");
        loadingHints.Add("The Psyche mission science goals are to:\n\nUnderstand a previously unexplored building block of planet formation: iron cores.\nLook inside terrestrial planets, including Earth, by directly examining the interior of a differentiated body, which otherwise could not be seen.\nExplore a new type of world. For the first time, examine a world made not of rock and ice, but metal.");
        loadingHints.Add("The Psyche mission science objectives are to:\n\nDetermine whether Psyche is a core, or if it is unmelted material.\nDetermine the relative ages of regions of Psyche’s surface.\nDetermine whether small metal bodies incorporate the same light elements as are expected in the Earth’s high-pressure core.\nDetermine whether Psyche was formed under conditions more oxidizing or more reducing than Earth’s core.\nCharacterize Psyche’s morphology.");
        loadingHints.Add("The mission is led by Arizona State University. NASA’s Jet Propulsion Laboratory is responsible for mission management, operations and navigation. The spacecraft’s solar-electric propulsion chassis will be built by Maxar (formerly SSL) with a payload that includes an imager, magnetometer, and a gamma ray and neutron spectrometer.");
        loadingHints.Add("Why can't we visit Earth's Core?\n\nThe core of the Earth lies at a depth of 3,000 kilometers (more than 1,800 miles). We have only drilled to 12 kilometers (about 7.5 miles) — that’s the most our technology allows today. Additionally, Earth’s core lies at about 3 million times the pressure of the atmosphere. The temperature of Earth’s core is about 5,000 Celsius (~9,000 Fahrenheit).");
        /*
        loadingHints.Add("Loading hint #1.");
        loadingHints.Add("Loading hint #2.");
        loadingHints.Add("Loading hint #3.");
        loadingHints.Add("Loading hint #4.");
        loadingHints.Add("Loading hint #5.");
        loadingHints.Add("Loading hint #6.");
        loadingHints.Add("Loading hint #7.");
        loadingHints.Add("Loading hint #8.");
        loadingHints.Add("Loading hint #9.");*/
        if(txt_Hint != null)
        {
            txt_Hint.text = loadingHints[Random.Range(0, loadingHints.Count)];
        }
        nextScene = PlayerPrefs.GetInt("SCENE");
    }

    void Update()
    {// Update is called once per frame
        currentDelay += Time.deltaTime;
        if(currentDelay >= minLoadingTime || Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {//Wait for min time or user tap.
            SceneManager.LoadScene(nextScene);
        }
    }
}
