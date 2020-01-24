using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUI_Navigator : MonoBehaviour
{
		public void BackToMain()
	{//if player has craft selected
		SceneManager.LoadScene(1);
	}
}
