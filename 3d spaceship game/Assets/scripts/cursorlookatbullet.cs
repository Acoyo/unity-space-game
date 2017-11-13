using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorlookatbullet : MonoBehaviour {
    public GameObject nearestbullet;
    public Transform nearestbullettrans;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        nearestbullet = GameObject.FindWithTag("bullet2");
        nearestbullettrans = nearestbullet.transform;
        transform.LookAt(nearestbullettrans);
    }
}
