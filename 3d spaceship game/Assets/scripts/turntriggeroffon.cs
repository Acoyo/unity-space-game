using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turntriggeroffon : MonoBehaviour {
    public int countdown=3;
	// Use this for initialization
	void Start () {
        GetComponent<Collider>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        countdown--;



        if (countdown <= 0)
        {
            //GetComponent<Collider>().enabled = true;

        }
    }
}
