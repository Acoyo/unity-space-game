using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyenbullet : MonoBehaviour {
    public int destroyTime = 5;
    // Use this for initialization
    void Start() {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update() {

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}


