using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletspin : MonoBehaviour
{
    public GameObject leftorright;
    public GameObject target;
    public GameObject twin;
    public int countdown;
    public Vector3 distfromtwin;
    public float distancefromtwin2;
    // Use this for initialization
    void Start()
    {
        //countdown--;
        leftorright = GameObject.Find("follow");
        target = GameObject.Find("middletemp(Clone)");
       
        //twin = GameObject.FindWithTag("spinner");
        //twin != gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        countdown--;
        twin = FindClosestEnemy();
        target = GameObject.Find("middletemp(Clone)");
        //distfromtwin = twin.transform.position - transform.position;
        //float Distancefromtwin = distfromtwin.sqrMagnitude;
        //distancefromtwin2 = Distancefromtwin;
        if (countdown <= 0)
        {
            gameObject.tag = "spinner";

        }
        if (Input.GetKeyDown(KeyCode.LeftShift))

        {
            Destroy(target.gameObject);
            //Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("spinner");
        GameObject closest = null;
        float distance = 1;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance > distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    void OnTriggerEnter(Collider other)
    {

        // leftorright = GameObject.Find("spinner");
        // if (other.gameObject == leftorright)
        if (other.gameObject.CompareTag("spinner"))
        {
            Destroy(target.gameObject);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}