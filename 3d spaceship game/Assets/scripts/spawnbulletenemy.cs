using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbulletenemy : MonoBehaviour
{
    public GameObject enbullet;
    public GameObject enbullet2;
    public GameObject currentbullet;
    //public Transform orig;
    public Transform mousepos;
    public int countdown=200;
    public int coundownattackspeed=100;

    public Transform target;
    public int temp;
    public GameObject target2;
    public GameObject childObj;

    public float distance;
    public float mindist = 5f;
    public float maxdist = 20f;
    // Use this for initialization
    void Start()
    {
        temp = Random.Range(0, 2);
        coundownattackspeed = GetComponentInParent<shipstats>().attackspeed;
     
    }


    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, FindClosestEnemy().transform.position);
        countdown--;
        if ((countdown <= 0)&& (distance <= maxdist) && (distance >= mindist))
        {
            firebullet();
            countdown = coundownattackspeed;
            coundownattackspeed = GetComponentInParent<shipstats>().attackspeed;
        }
    }

    void firebullet()
    {
        if (temp == 0)
        {
            currentbullet = enbullet;
        }
        if (temp == 1)
        {
            currentbullet = enbullet2;
        }
        Instantiate(currentbullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;

    }
}
