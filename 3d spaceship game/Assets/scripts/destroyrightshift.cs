﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyrightshift : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		     if ((Input.GetKeyDown(KeyCode.LeftShift)) || (Input.GetMouseButtonDown(1)))

        {
            Destroy(gameObject);
        }
    }
}
