using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnenemy : MonoBehaviour {
    public GameObject enemy;
    public int countdown;
    public int respawnrate = 400;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        countdown--;
        if (countdown <= 0)
        {
            spawnenemyprefab();
            countdown = respawnrate;
        }
	}
    void spawnenemyprefab()
    {
       
        Instantiate(enemy, new Vector3(transform.position.x, transform.position.y+2, transform.position.z), transform.rotation);
    }
}
