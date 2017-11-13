using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
   // public int randone = 21; //(Random.Range(15, 20));
    public Transform player;
    public float speed;
    // Use this for initialization
    void Start () {
        //randone = (Random.Range(15, 20));
        
    }
	
	// Update is called once per frame
	void Update () {
        //randone = (Random.Range(15, 20));
        transform.RotateAround(player.transform.position, Vector3.up, 20 * Time.deltaTime * speed);
    }
}
