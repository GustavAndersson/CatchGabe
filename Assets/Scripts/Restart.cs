using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Restart : MonoBehaviour {
    //Metod som är kopplad till restart-knappen. Laddar om Main-scenen.
    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }
}