﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Score : MonoBehaviour {
    public Text scoreText;
    public int gabeValue;

    private int score;
    private string playername;

	//Vid start har score värdet 0 från början
	void Start () {
        score = 0;
        UpdateScore();
    }

    //Varje gång trigger aktiveras får score ett nytt värde och sedan anropas UpdateScore-metoden
    void OnTriggerEnter2D()
    {
        score += gabeValue;
        UpdateScore();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DogEnemy")
        {
            score -= gabeValue * 2;
            UpdateScore();
        }
    }

    //Metod som uppdaterar poängen
    void UpdateScore()
    {
        scoreText.text = "Score\n" + score;
        AddScore(score, playername);
    }

    //Kollar igenom om poängen platsar i topplistan
    void AddScore(int score, string name)
    {
        int newScore;
        string newName;
        int oldScore;
        string oldName;
        newScore = score;
        newName = name;
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey(i + "HScore"))
            {
                if (PlayerPrefs.GetInt(i + "HScore") < newScore)
                {
                    // new score is higher than the stored score
                    oldScore = PlayerPrefs.GetInt(i + "HScore");
                    oldName = PlayerPrefs.GetString(i + "HScoreName");
                    PlayerPrefs.SetInt(i + "HScore", newScore);
                    PlayerPrefs.SetString(i + "HScoreName", newName);
                    newScore = oldScore;
                    newName = oldName;
                }
            }
            else
            {
                PlayerPrefs.SetInt(i + "HScore", newScore);
                PlayerPrefs.SetString(i + "HScoreName", newName);
                newScore = 0;
                newName = "";
            }
        }
    }  

    void getNameInput(string name)
    {
        playername = name;
        Debug.Log(playername);
        UpdateScore();
    }
}