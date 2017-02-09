using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour {
    public Text oneScore;
    public Text twoScore;
    public Text threeScore;
    public Text fourScore;
    public Text fiveScore;
    public Text sixScore;
    public Text sevenScore;
    public Text eightScore;
    public Text nineScore;
    public Text tenScore;

    public Text nameOne;
    public Text nameTwo;
    public Text nameThree;
    public Text nameFour;
    public Text nameFive;
    public Text nameSix;
    public Text nameSeven;
    public Text nameEight;
    public Text nameNine;
    public Text nameTen;

    //I denna klass skickas all lagrad data som finns i PlayerPrefs, till de utritade textfälten
    //som ska visa highscorelistan. 

    void Start()
    {
        UpdateHScore();
    }

    void UpdateHScore()
    {
        oneScore.text = PlayerPrefs.GetInt("0HScore").ToString();
        twoScore.text = PlayerPrefs.GetInt("1HScore").ToString();
        threeScore.text = PlayerPrefs.GetInt("2HScore").ToString();
        fourScore.text = PlayerPrefs.GetInt("3HScore").ToString();
        fiveScore.text = PlayerPrefs.GetInt("4HScore").ToString();
        sixScore.text = PlayerPrefs.GetInt("5HScore").ToString();
        sevenScore.text = PlayerPrefs.GetInt("6HScore").ToString();
        eightScore.text = PlayerPrefs.GetInt("7HScore").ToString();
        nineScore.text = PlayerPrefs.GetInt("8HScore").ToString();
        tenScore.text = PlayerPrefs.GetInt("9HScore").ToString();

        nameOne.text = PlayerPrefs.GetString("0HScoreName").ToString();
        nameTwo.text = PlayerPrefs.GetString("1HScoreName").ToString();
        nameThree.text = PlayerPrefs.GetString("2HScoreName").ToString();
        nameFour.text = PlayerPrefs.GetString("3HScoreName").ToString();
        nameFive.text = PlayerPrefs.GetString("4HScoreName").ToString();
        nameSix.text = PlayerPrefs.GetString("5HScoreName").ToString();
        nameSeven.text = PlayerPrefs.GetString("6HScoreName").ToString();
        nameEight.text = PlayerPrefs.GetString("7HScoreName").ToString();
        nameNine.text = PlayerPrefs.GetString("8HScoreName").ToString();
        nameTen.text = PlayerPrefs.GetString("9HScoreName").ToString();
    }
}
