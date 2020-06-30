﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    private Player thePlayer;
    private CameraController theCamera;

	// Use this for initialization
	void Start ()
    {
        thePlayer = FindObjectOfType<Player>();
        thePlayer.transform.position = transform.position;
        //startDirection;
        theCamera = FindObjectOfType<CameraController>();
        theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
