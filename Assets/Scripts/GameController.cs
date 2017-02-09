using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject[] dogs;
    public float timeLeft;
    public Text timerText;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject quitGameButton;
    public GameObject highscoreButton;
    public GameObject nameInput;

    private float maxWidth;
    
    //Vid start räknas spelytan ut så att de fallande objekten ramlar innanför spelplanen.
    //Spawn metoden kallas så att fallande objekt börjar spawna
    //UpdateText() kallas för att visa starttiden
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float gabeWidth = dogs[0].GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - gabeWidth;
        StartCoroutine(Spawn());
        UpdateText();
    }

    //Gör så att tiden tickar nedåt. När tiden = 0 stannar den där. 
    //Medan den tickar uppdateras texten som visar återstående tid.
    //Kallar på increaseGravity() 
    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            timeLeft = 0;
        }
        UpdateText();
        increaseGravity();
    }

    //Funktion som ökar objektens gravitation efter 20 sekunder - försvårar för spelaren
    void increaseGravity()
    {
        if (timeLeft > 30)
        {
            dogs[0].GetComponent<Rigidbody2D>().gravityScale = 2;
        }
        else
        {
            dogs[0].GetComponent<Rigidbody2D>().gravityScale = 4;
        }
    }

    //Funktion som spawnar nya objekt
    IEnumerator Spawn ()
    {
        yield return new WaitForSeconds(2.0f); //En liten delay innan objekten börjar falla
        while (timeLeft > 0) //Så länge det är tid kvar spawnas nya objekt
        {
            GameObject dog = dogs[Random.Range(0, dogs.Length)];
            Vector3 spawnPosition = new Vector3( //En vector3 som slumpar vart objektet ska spawnas
                Random.Range(-maxWidth, maxWidth),
                transform.position.y,
                0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(dog, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1.0f, 1.0f));
        }
        //När spelet är slut visas gameover-text, restart-knapp, highscore-knapp och quit-knapp.
        //Anropar AddScore-metoden från klassen Score för att kunna lägga in resultatet i highscorelistan. 
        yield return new WaitForSeconds(2.0f);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        restartButton.SetActive(true);
        highscoreButton.SetActive(true);
        quitGameButton.SetActive(true);
        Score s = new Score();
        Debug.Log(Score.score);
        Debug.Log(Score.playername);
        string ingameName = Score.playername;
        Debug.Log("HÄR ÄR NAMNET:" + ingameName);
        s.AddScore(Score.score, ingameName);
        
    }

    //Funktion som uppdaterar hur mycket tid som återstår 
    void UpdateText()
    {
        timerText.text = "Time Left:\n" + Mathf.RoundToInt(timeLeft);
    }
}
