using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour {
    //Metod som anropas när man trycker på quit-knappen. Stänger av spelet.
    public void Quit()
    {
        Application.Quit();
    }

}
