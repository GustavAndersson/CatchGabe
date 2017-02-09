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
    public GameObject nameInput;

    private float maxWidth;

    // Use this for initialization
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
        //När spelet är slut visas gameover-texten och restart-knappen
        yield return new WaitForSeconds(2.0f);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        restartButton.SetActive(true);
        quitGameButton.SetActive(true);
        nameInput.SetActive(true);
    }

    //Funktion som uppdaterar hur mycket tid som återstår 
    void UpdateText()
    {
        timerText.text = "Time Left:\n" + Mathf.RoundToInt(timeLeft);
    }
}
