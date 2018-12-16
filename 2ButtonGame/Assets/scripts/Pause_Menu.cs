using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour {

	public Button alwaysThere;
	public GameObject Pause_panel;
	public GameObject Fade_level;
	public bool isOpened;
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Pause_panel.SetActive(true);
			alwaysThere.Select();
			isOpened = true;
			Time.timeScale = 0f;
		}
	}

	public void Resume()
	{
		Pause_panel.SetActive(false);
		Time.timeScale = 1f;
	}

	public void Retry()
	{
		Time.timeScale = 1f;
		Fade_level.SetActive(true);
	}

	public void exit ()
	{
		Application.Quit();
	}
}
