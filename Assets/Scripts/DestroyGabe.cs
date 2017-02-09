using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGabe : MonoBehaviour {
    
    //Funktion som förstör objektet när den kolliderar med triggern
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
