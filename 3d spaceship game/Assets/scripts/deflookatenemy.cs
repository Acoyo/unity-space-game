using System;
using UnityEngine;

public class deflookatenemy : MonoBehaviour
{
    public Transform target;
    public GameObject target2;
    public GameObject defaggrosphere;
    public GameObject player;
    public float speed = 1;
    public float distance;
    public float distancefromplayer;
    public float mindist = 5f;
    public float maxdist = 20f;
    public int countdown=20;
    public bool followplayer = false;
    public bool followenemy = true;
    public int defenderhealth;
    private void Start()
    {
        //if (GetComponent<lookatplayer>().enabled == true) {
        //    GetComponent<lookatplayer>().shiphealthenemy = GetComponent<playermove>().defenderhealth;
        //    defenderhealth= GetComponent<playermove>().defenderhealth;
        //}
        player = GameObject.Find("aaaaaa");
        //followplayer = false;
        //followenemy = true;
    }
    void FixedUpdate()
    {
        countdown--;
        if (countdown < 0)
        {
            FindClosestEnemy();
            countdown = 20;

        }
        distancefromplayer = Vector3.Distance(transform.position, player.transform.position);

        distance = Vector3.Distance(transform.position, FindClosestEnemy().transform.position);
        defaggrosphere.transform.localScale = new Vector3(maxdist * 2, 0, maxdist * 2);
        if (followplayer == true)
        {
            if ((distancefromplayer > maxdist / 2) && (gameObject.tag == "Player"))
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
            }
        }
    
        if ((distance < maxdist+2))
        {
            transform.LookAt(FindClosestEnemy().transform.position);
            defaggrosphere.gameObject.SetActive(true);
        }
        if ((distance > maxdist + 3))
        {
            defaggrosphere.gameObject.SetActive(false);
        }
        if ((FindClosestEnemy() != null) && ((distance > mindist)&&(followenemy==true) && (distance < maxdist)))
        {
            transform.position = Vector3.MoveTowards(transform.position, FindClosestEnemy().transform.position, speed);
        }
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("enemy");
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

        if (other.gameObject.CompareTag("enbullet")&&(gameObject.tag=="Player"))
        {
            Destroy(other.gameObject);
            GetComponent<shipstats>().shiphealth--;
            if (GetComponent<shipstats>().shiphealth <= 0)
            {
                if(gameObject.name== "tempplayer")
                {
                    GetComponent<playermove>().Jumpback();
                }
                Destroy(gameObject);
            }
        }
    }
}