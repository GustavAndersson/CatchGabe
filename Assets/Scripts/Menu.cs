using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    //Metod som är kopplad till restart-knappen. Laddar om Main-scenen.
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void showHighscore()
    {
        SceneManager.LoadScene("Highscore");
    }
}