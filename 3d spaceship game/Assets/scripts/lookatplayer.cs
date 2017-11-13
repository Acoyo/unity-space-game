using System;
using UnityEngine;

public class lookatplayer : MonoBehaviour
{
    //public Transform target;
    //public Transform orig;
    public GameObject target2;
    public GameObject childObj;
    public GameObject playersbulletspawn;
    public GameObject aggrosphere;
    public GameObject enemybase;
    public float speed=1;
    public float speeddouble;
    public float distance;
    public float distancefrombase;
    public int aggrotime=200;

    public float mindist=5f;
    public float maxdist = 20f;
    public int shiphealthenemy;
    public int countdown;
    public int countdownstun;
    public int countdownstunduration;


    public Material defendermat;
    public bool canmove;

  
    private void Start()
    {
        canmove = true;
        //shiphealthenemy = GetComponent<shipstats>().shiphealth;
        target2 = GameObject.Find("aaaaaa");
        enemybase = GameObject.Find("enemy base");
        aggrosphere.gameObject.SetActive(false);
        countdown = 0;
        speeddouble = speed * 2;

     

    }
    public void speeddoubled()
    {
        speeddouble = speed * 1.2f;
    }
    void FixedUpdate()
    {
        if (FindClosestEnemy().transform.position == null)
        {
            FindClosestEnemy();
        }
        //FindClosestEnemy();
        countdownstun--;
        countdown--;
        if (countdownstun <= 0)
        {
            canmove = true;
        }

        if (canmove == true)
        {
            distance = Vector3.Distance(gameObject.transform.position, FindClosestEnemy().transform.position);

            aggrosphere.transform.localScale = new Vector3(maxdist * 2, 0, maxdist * 2);

            if (countdown == 1)
            {
                maxdist = maxdist / 2;
               // canmove = true;
            }
            {

            }
            if ((distance < maxdist + 10)&& (FindClosestEnemy().transform != null))
            {

                aggrosphere.gameObject.SetActive(true);
                transform.LookAt(FindClosestEnemy().transform.position);
            }
            if ((distance > maxdist + 10))
            {
                aggrosphere.gameObject.SetActive(false);
            }
            if ((distance > mindist) && (distance < maxdist) && (FindClosestEnemy().transform != null))
            {
                transform.position = Vector3.MoveTowards(transform.position, FindClosestEnemy().transform.position, speed);

            }
            if (distance > (maxdist) && (fakeplayer().transform != null))                ///  move towards enemy base if one exists
            {
                distancefrombase = Vector3.Distance(gameObject.transform.position, fakeplayer().transform.position);
                transform.position = Vector3.MoveTowards(transform.position, fakeplayer().transform.position, speed);
                if (distancefrombase < 30)
                {
                    transform.position = Vector3.MoveTowards(transform.position, fakeplayer().transform.position, speeddouble);
                    //transform.RotateAround(fakeplayer().transform.position, Vector3.up, 20 * Time.deltaTime * speed);
                }
                transform.LookAt(fakeplayer().transform.position);
            }
        }
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        //int healthinf = 1000;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            //int health = go.GetComponent<shipstats>().shiphealth;
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
        gos = GameObject.FindGameObjectsWithTag("enemybase");
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

        if (other.gameObject.CompareTag("bullet")&&(gameObject.tag== "enemy"))
        {
           // canmove = false;
            Destroy(other.gameObject);
            //countdownstun = countdownstunduration;
            if (gameObject.tag == "enemy")
            {
                maxdist = maxdist * 2;
                if (maxdist > 75)
                {
                    maxdist = 75;
                }
                countdown = aggrotime;                                     //time enemy aggro duration
                GetComponent<shipstats>().shiphealth--;
               // shiphealthenemy--;
                if (GetComponent<shipstats>().shiphealth <= 0)
                {
                    Destroy(gameObject);
                }


            }
            
        }
        if (other.gameObject.CompareTag("bulletknockback") && (gameObject.tag == "enemy"))
        {
            canmove = false;
            Destroy(other.gameObject);
            countdownstun = countdownstunduration;
            if (gameObject.tag == "enemy")
            {
            
                //countdown = 500;                                     //time enemy aggro duration
                GetComponent<shipstats>().shiphealth--;
                
                if (GetComponent<shipstats>().shiphealth <= 0)
                {
                    Destroy(gameObject);
                }


            }

        }
        if (other.gameObject.CompareTag("bulletmindcontrol"))
        {
            Renderer rend = GetComponent<Renderer>();
        
            rend.material.SetTextureOffset("_MainTex", new Vector2(1.5f, 0));
       
            playersbulletspawn = GameObject.FindWithTag("HeroicUnit");
            GetComponent<playerlookatmouse>().enabled = true;
            GetComponent<playermove>().enabled = true;
        
            GetComponentInChildren<spawnbulletenemy>().enabled = false;
            GetComponentInChildren<spawnbullet>().enabled = true;
            gameObject.tag = "Player";                                          ///
           // target2.gameObject.tag = "Untagged";                                    ////
            childObj.gameObject.tag = "HeroicUnit";
            playersbulletspawn.gameObject.tag = "HeroicUnitTemp";
            //other.gameObject.SetActive(false);
            childObj.gameObject.SetActive(true);
            target2.GetComponent<playerlookatmouse>().enabled = false;
            target2.GetComponent<playermove>().enabled = false;
            other.gameObject.SetActive(false);
            target2.GetComponentInChildren<spawnbullet>().enabled = false;
            GetComponent<deflookatenemy>().enabled = false;
            GetComponentInChildren<spawnbulletdefender>().enabled = false;
            GetComponent<lookatplayer>().enabled = false;
    

        }
    }
}