﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public string mainSceneName = "SprintOneTest";
    public AudioSource buttonPress;

	public float difficulty = 0.0f;
	public float speedDifficulty = 5.0f;

    public Slider scroll_difficulty;
    public Slider scroll_speed;

    void Start()
    {
        // Load saved states for scrollbars
        scroll_difficulty.value = PlayerPrefs.GetFloat("difficulty");
        scroll_speed.value = PlayerPrefs.GetFloat("SpeedDifficulty");
    }

    public void onClick_Start()
    {
		PlayerPrefs.SetFloat("difficulty", difficulty);
		PlayerPrefs.SetFloat("SpeedDifficulty", speedDifficulty);

		buttonPress.Play();
        Application.LoadLevel(mainSceneName);
    }

    public void onClick_Quit()
    {
        PlayerPrefs.SetFloat("difficulty", difficulty);
        PlayerPrefs.SetFloat("SpeedDifficulty", speedDifficulty);

        buttonPress.Play();
        Application.Quit();
    }

    public void onClick_Tutorial()
    {
        PlayerPrefs.SetFloat("difficulty", difficulty);
        PlayerPrefs.SetFloat("SpeedDifficulty", speedDifficulty);

        buttonPress.Play();
        Application.LoadLevel(2);
    }

	public void onSlide_Difficulty(float sliderDifficulty)
	{
		difficulty = sliderDifficulty;
	}

	public void onSlide_SpeedDifficulty(float sliderSpeedDifficulty)
	{
		speedDifficulty = sliderSpeedDifficulty;
	}
}
