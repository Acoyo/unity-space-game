 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerlookatmouse : MonoBehaviour {
    public float angle;
    public GameObject sphere;
    public Transform spheretran;
    // Use this for initialization
    void Start () {
        sphere = GameObject.FindWithTag("follow");
        spheretran = sphere.transform;
    }
    public void FixedUpdate()
    {
        transform.LookAt(spheretran);
    }
   
}
