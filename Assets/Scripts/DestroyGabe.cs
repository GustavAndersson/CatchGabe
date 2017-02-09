using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGabe : MonoBehaviour {
    
    //Metod som förstör fallande objekt när dem kolliderar med triggern
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
