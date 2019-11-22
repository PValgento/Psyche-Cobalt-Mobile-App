using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sb_NavigationController : MonoBehaviour
{
    void Awake()
    {
        GameObject navBar = Instantiate(Resources.Load("nav_Sidebar")) as GameObject;
        navBar.transform.parent = this.transform;
    }
}
