﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;

public class ScorePoster : MonoBehaviour
{
    public string serverURI = "http://ddoodm.com/UnityProjects/SpinAndJumpSim/ScoreServ/postScore.php";
    public HighscoreGetter scoreGetter;
    public Text successText;
    public Text failText;
    public Button submitButton;
    public UserScoreGetter userScoreGetter;
    private GameController gameController;
    private string username = "";
    private bool scoreSubmitted = false;

    void Start()
    {
        gameController = GetComponent<GameController>();
    }

    public void setUsername(string value)
    {
        // Strip all but alphanumeric
        Regex rgx = new Regex("[^a-zA-Z0-9 -]");
        this.username = rgx.Replace(value, "");
    }

    public void postScore()
    {
        if (scoreSubmitted)
            return;

        int score = (int)gameController.score;
        int time = (int)gameController.gameDuration;

        if (username.Length == 0)
        {
            Debug.Log("Score Poster - No username");
            failText.gameObject.SetActive(true);
            return;
        }

        failText.gameObject.SetActive(false);

        StartCoroutine(postInBackground(score, username, time));

        // Update the user's name
        userScoreGetter.updatePlayerName(username);
    }

    private IEnumerator postInBackground(int score, string username, int time)
    {
        // Create HTTP form header
        WWWForm form = new WWWForm();
        form.AddField("score", (int)gameController.score);
        form.AddField("name", username);
        form.AddField("time", (int)gameController.gameDuration);

		//Totally not 1337 haxx0r's score <.< >.> go away!
		/*
		form.AddField("score", 11337);
		form.AddField("name", "1337 haxx0r");
		form.AddField("time", 1337);
		*/

        // Post to the PHP script on the server, which interfaces with SQL
        WWW www = new WWW(serverURI, form);
        yield return www;

        Debug.Log("Score Poster - Posted new score to the server.");
        successText.gameObject.SetActive(true);
        submitButton.enabled = false;
        scoreSubmitted = true;

        // Update highscore list
        StartCoroutine(scoreGetter.refreshScores());
    }
}
