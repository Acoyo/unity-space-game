using System;
using UnityEngine;

public class enbullet : MonoBehaviour
{
    //public Transform target;
    //public Transform orig;
    public GameObject target2;
    public GameObject childObj;
    public GameObject playersbulletspawn;
    public float speed = 1;
    public float distance;
    public float mindist = 5f;
    public float maxdist = 20f;
    public int destroytime = 4;
    public int bulletlife = 2;

    private void Start()
    {

        target2 = GameObject.Find("aaaaaa");
        Destroy(gameObject, destroytime);
    }
    void FixedUpdate()
    {
        distance = Vector3.Distance(gameObject.transform.position, FindClosestEnemy().transform.position);
        if ((distance < maxdist + 2))
        {
            transform.LookAt(FindClosestEnemy().transform.position);
        }
        if ((distance > mindist) && (distance < maxdist))
        {
            transform.position = Vector3.MoveTowards(transform.position, FindClosestEnemy().transform.position, speed);

        }
        if (distance <= .1f)
        {
            //Destroy(gameObject);
        }
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
    public GameObject fakeplayer()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("fakeplayer");
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

    void OnTriggerEnter(Collider other)
    {

        if ((other.gameObject.CompareTag("bullet"))|| (other.gameObject.CompareTag("bulletknockback")))
        {
            bulletlife--;
            if (bulletlife <= 0)
            {
                  Destroy(gameObject);
            }
        }
    }
}