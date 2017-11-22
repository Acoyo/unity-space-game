using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletspin2 : MonoBehaviour
{
    public GameObject capsule;
    // Use this for initialization
    void Start()
    {
        capsule = GameObject.Find("Capsule");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {


        if (other.gameObject==capsule)
        {
            Destroy(gameObject);
        }
    }
}