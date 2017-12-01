using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatearound : MonoBehaviour
{
    // public int randone = 21; //(Random.Range(15, 20));
    public GameObject target;
    public Transform targettemp;
    public float realspeed=10;
    private float speed=.11f;
    // Use this for initialization
    void Start()
    {
        if (gameObject.tag == "enemybase")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        //randone = (Random.Range(15, 20));
       // target = GameObject.FindWithTag("Player");
        //targettemp = target.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //randone = (Random.Range(15, 20));
        //target = GameObject.Find("middletemp(Clone)");
        //targettemp = target.transform;
        transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime / realspeed);
    }
}
