 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerlookatmouse : MonoBehaviour {
    public float angle;
    public GameObject sphere;
    public GameObject player;
    public Transform spheretran;
    public GameObject middletran;
    public float middle;
    public float distance;
    public float half = .5f;
    // Use this for initialization
    void Start () {
        sphere = GameObject.FindWithTag("follow");
        spheretran = sphere.transform;
    }
    public void FixedUpdate()
    {
        transform.LookAt(spheretran);
        distance = Vector3.Distance(gameObject.transform.position, sphere.transform.position);

        //middletran.transform.position= ((player.transform.position) - (sphere.transform.position/2));
    }
   
}
