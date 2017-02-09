using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    //Startar ett nytt spel genom att öppna main-scenen
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    //Byter scen och visar highscore-listan
    public void showHighscore()
    {
        SceneManager.LoadScene("Highscore");
    }

    //Byter tillbaka till menyn
    public void backToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}