using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybase : MonoBehaviour {
    public int randnum= Random.Range (0,4);
    public int cd;
	// Use this for initialization
	void Start () {
       // randnum = 1;
	}
	void rand()
    {
        randnum = Random.Range(0, 4);
    }

	// Update is called once per frame
	void Update () {
        cd--;
        if (cd <= 0)
        {
            rand();
            cd = 300;
        }
        if ((randnum == 1)|| (randnum == 2))
        {
            gameObject.tag = "enemybase";
        }
        if (randnum != 1)
        {
            gameObject.tag = "Untagged";
        }
    }
}
