using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour {
    public float timer=10;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, timer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
