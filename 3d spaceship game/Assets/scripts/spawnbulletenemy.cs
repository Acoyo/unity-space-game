using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbulletenemy : MonoBehaviour
{
    public GameObject enbullet;
    public GameObject enbullet2;
    public GameObject detectionbullets;
    public GameObject currentbullet;
    public Transform bulletspawnback;
    //public Transform orig;
    public Transform mousepos;
    public GameObject theplayer;
    public int countdowndetection;
    public int countdown=200;
    public int coundownattackspeed=100;

    public Transform target;
    public int temp;
    public GameObject target2;
    public GameObject childObj;
    public Color red = new Color(.5f, 0f, 1f, 0.4f);
    public Color brown = new Color(0.2f, .1f, 1, 0.2f);
    public float distance;
    public float mindist = 5f;
    public float maxdist = 20f;
    // Use this for initialization
    private void OnEnable()
    {
        temp = Random.Range(0, 2);
    }
    void Start()
    {
        //temp = Random.Range(0, 2);
        coundownattackspeed = GetComponentInParent<shipstats>().attackspeed;
        GetComponentInParent<shipstats>().attackspeed = GetComponentInParent<shipstats>().attackspeed + Random.Range(10, 19);
        if (temp == 0)
        {
           // GetComponentInParent<Renderer>().material.color = Color.blue;
            //sphere.renderer.material.color = Color.red;
        }
        else if (temp == 1)
        {
           // GetComponentInParent<Renderer>().material.color = red;
        }
    }


    void FixedUpdate()
    {
        theplayer= GameObject.Find("aaaaaa");
        distance = Vector3.Distance(transform.position, FindClosestEnemy().transform.position);
        countdown--;
        countdowndetection--;
        if ((countdown <= 0)&& (distance <= maxdist) && (distance >= mindist)&&(GetComponentInParent<lookatplayer>().canseeyou==true))//&&(GetComponentInParent<lookatplayer>().grouphealth >= mouseclick.grouphealthplayer))
        {
            firebullet();
            countdown = coundownattackspeed;
            coundownattackspeed = GetComponentInParent<shipstats>().attackspeed;
        }
        if ((countdowndetection <= 0) && (distance <= maxdist*1.5f))
        {
            detectionbullet();
            countdowndetection = 5;
        }
        }
    void detectionbullet()
    {
        Instantiate(detectionbullets, new Vector3(bulletspawnback.position.x, bulletspawnback.position.y, bulletspawnback.position.z), bulletspawnback.rotation);
  
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
