using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Kinda-hard coded do to Unity's component system for other scripts to find this on a GameObject named "GameController"
public class s_GameController : MonoBehaviour
{//Controls the actions of the GUI etc
    [SerializeField]
    protected GameObject player;
    [SerializeField]
    protected Transform player_Start;
    [SerializeField]
    protected GameObject deathCam;

    public GameObject obj_Menu;
    public GameObject obj_Win;
    public GameObject obj_Lose;
    protected bool isShowingMenu = false;
    void Start()
    {//Start is called before the first frame update
        obj_Win.SetActive(false);
        obj_Lose.SetActive(false);
    }

    void Update()
    {//Update is called once per frame
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.F10))
        {//Will need to add Android/iOS options to access menus for build.
            isShowingMenu = !isShowingMenu;
            ctl_ShowMenu(isShowingMenu);
        }
    }
    public void ctl_RestartGame()
    {
        Debug.Log("Game Restarting!");
        deathCam.SetActive(false);
        player.transform.parent = player_Start.transform;
        //Player_Start will be where we want it to be.
		player.transform.localPosition = new Vector3(0f, 0f, 0f);
        player.transform.rotation = Quaternion.Euler(Vector3.zero);
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody2D>().angularVelocity = 0f;//Vector3.zero;
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        player.GetComponent<sb_Player>().ctl_PlayerReset();
        player.GetComponent<sb_Player>().ctl_PlayerActive(true);
        obj_Menu.SetActive(false);
        obj_Win.SetActive(false);
        obj_Lose.SetActive(false);
    }
    public void ctl_StartGame()
    {
        ctl_RestartGame();
    }
    public void ctl_ShowMenu(bool input)
    {
        obj_Menu.SetActive(input);
    }

    public void ctl_PlayerRapidUnscheduledDisassembly()
    {
        obj_Lose.SetActive(true);
        obj_Menu.SetActive(true);
        deathCam.SetActive(true);
    }
    public GameObject GetPlayerObj()
    {
        return player;
    }
}
