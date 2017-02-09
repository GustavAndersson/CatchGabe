using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinController : MonoBehaviour {
    public Camera cam;

    private float maxWidth;

	void Start () {
		if(cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float binWidth = GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - binWidth;
	}
	
    //Gör så att man inte kan dra objektet utanför spelplanen
	void Update () {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, 0.0f, 0.0f);
        float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);
        GetComponent<Rigidbody2D>().MovePosition(targetPosition);
	}
}
