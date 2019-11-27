using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sb_NavigationController : MonoBehaviour
{
    public bool isScoreEnabled = true;
    void Awake()
    {
        GameObject navBar = Instantiate(Resources.Load("nav_Sidebar")) as GameObject;
        navBar.transform.parent = this.transform;
        navBar.GetComponent<s_Sidebar>().isScoreEnabled = isScoreEnabled;
    }
}
