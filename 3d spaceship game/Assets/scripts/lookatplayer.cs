using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
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
    public GameObject destroyed;
    public bool aggrotrue=false;
    public bool canseeyou = false;


    public float mindist=5f;
    public float maxdist = 20f;
    public float maxdistcopy;
    public int shiphealthenemy;
    public int countdown;
    public int countdownstun;
    public int countdownstunduration;
    public int countdowndif=0;
    public int cdhealing;
    public int healingcooldown = 100;
    public GameObject cam;
    public GameObject mouseclick;
    private Rigidbody thisbody;
    private bool closequarters=false;
    public bool ishealing = false;


    public Material defendermat;
    public bool canmove;

  
    private void Start()
    {
        thisbody = GetComponent<Rigidbody>();
        canmove = true;
        //shiphealthenemy = GetComponent<shipstats>().shiphealth;
        target2 = GameObject.Find("aaaaaa");
        enemybase = GameObject.Find("enemy base");
        //aggrosphere.gameObject.SetActive(false);
        countdown = 0;
        speeddouble = speed * 2;
        cam = GameObject.Find("Main Camera");
        AudioSource destroyed = GetComponent<AudioSource>();
        maxdistcopy = maxdist;
        distance = 100;
        canseeyou = false;
        transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = enemybaselowesthealth().transform.position;


    }
   
    public void speeddoubled()
    {
        speeddouble = speed * 1.2f;
    }
    void FixedUpdate()
    {
        if (canseeyou == false)               ///  move towards enemy base if one exists
        {
            //if(enemybasetransform().tag=="enemybase")
            transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = enemybasetransform().transform.position;
            transform.LookAt(FindClosestEnemy().transform.position);

        }
        if (distance > maxdist)
        {
            canseeyou = false;
        }
        // enemybasetransform();
        //waitthenactivate();
        //thisbody.velocity = Vector3.zero;
        countdowndif--;
        if (countdowndif <= 0)
        {
            canmove = false;
            thisbody.velocity = Vector3.zero;
            countdowndif = 500;
            canmove = true;
        }
        if (ishealing == true)    // Enemy base healing function
        {
            cdhealing--;
            if ((cdhealing <= 0)&& (GetComponent<shipstats>().shiphealth< GetComponent<shipstats>().maxhealth) && (gameObject.tag == "enemy"))
            {
                GetComponent<shipstats>().shiphealth++;
                cdhealing = healingcooldown;
            }
        }
        enemybase = enemybaselowesthealth();
        {
            if (countdown <= 0)
            {
                aggrotrue = false;
            }
            if (aggrotrue == false)
            {
                maxdist = maxdistcopy;
            }
        }
        {
          
        }
        //FindClosestEnemy();
        countdownstun--;
        countdown--;
        if (countdownstun == 0)
        {
            thisbody.velocity = Vector3.zero;
            canmove = true;
        }

        if (canmove == true)
        {
            distance = Vector3.Distance(gameObject.transform.position, FindClosestEnemy().transform.position);
            distancefrombase = Vector3.Distance(gameObject.transform.position, enemybaselowesthealth().transform.position);

            if (closequarters == true)
            {
                if ((distance > mindist) && (distance < maxdist) && (canseeyou == true))// && (FindClosestEnemy().transform != null))
                {
                    transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = FindClosestEnemy().transform.position;
                    transform.LookAt(FindClosestEnemy().transform.position);
                    // fakeplayer()    
                }
            }
            if (closequarters == false)
            {
                if ((distance > mindist) && (distance < maxdist) && (canseeyou == true))// && (FindClosestEnemy().transform != null))
                {
                    //transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = FindClosestEnemy().transform.position;
                    transform.position = Vector3.MoveTowards(transform.position, fakeplayer().transform.position, speed);
                    transform.LookAt(FindClosestEnemy().transform.position);
                    // fakeplayer()    
                }
                if ((distance < mindist) && (canseeyou == true))// && (FindClosestEnemy().transform != null))
                {
                    //transform.RotateAround(fakeplayer().transform.position, Vector3.up, 20 * Time.deltaTime*speed);
                    transform.LookAt(FindClosestEnemy().transform.position);
                    //thisbody.velocity = Vector3.zero;
                }
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
            if ((curDistance < distance) && (go.GetComponent<playermove>().isrevealed == true))
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
    public GameObject enemybasetransform()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("enemybase");
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
    public GameObject enemybaselowesthealth()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("enemybase");
        GameObject lowest = null;
        float basehealth = Mathf.Infinity;
        //Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            //Vector3 diff = go.transform.position - position;
            float lowesthealthbase = go.GetComponent<enemybase>().enemybasehealth;
            if (lowesthealthbase < basehealth)
            {
                lowest = go;
                basehealth = lowesthealthbase;
            }
        }
        return lowest;
    }
    public void destroyunit()
    {
        Instantiate(destroyed, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Destroy(gameObject);
    }
    IEnumerator waitthenactivate()
    {
       
        yield return new WaitForSeconds(2);
        enemybaselowesthealth();
        thisbody.velocity = Vector3.zero;
      //  canmove = false;
       // canmove = true;

    }
    IEnumerator enemybasehealing()
    {

        GetComponent<shipstats>().shiphealth++;
        yield return new WaitForSeconds(1);

    }
    private void Update()
    {
        //if ((ishealing == true)&& (gameObject.tag == "enemy")&&(GetComponent<shipstats>().shiphealth<= GetComponent<shipstats>().maxhealth))
        {
            //GetComponent<shipstats>().shiphealth++;
           // enemybasehealing();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("closequarters") && (gameObject.tag == "enemy"))
        {
            closequarters = false;
        }
        if (other.gameObject.CompareTag("enemybasehealing") && (gameObject.tag == "enemy"))
        {
            ishealing = false;
        }
    }
   private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("enemybasehealing") && (gameObject.tag == "enemy"))
        {
            //ishealing = true;
            if (enemybaselowesthealth().GetComponent<enemybase>().enemybasehealth < 100f)
            {
                enemybaselowesthealth().GetComponent<enemybase>().enemybasehealth += .1f;
            }
        }
    }
        void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("enemybasehealing") && (gameObject.tag == "enemy"))
        {
            ishealing = true;
            //enemybasetransform().GetComponent<enemybase>().enemybasehealth++;
        }
        if (other.gameObject.CompareTag("closequarters") && (gameObject.tag == "enemy"))
        {
            closequarters = true;
        }
            if (other.gameObject.CompareTag("bullet")&&(gameObject.tag== "enemy"))
        {
            canmove = false;
            //Destroy(other.gameObject);
            countdownstun = countdownstunduration;
            if (gameObject.tag == "enemy")
            {
                //AudioSource destroyed = GetComponent<AudioSource>();

                //destroyed.Play();
                //countdown = 500;                                     //time enemy aggro duration
                GetComponent<shipstats>().shiphealth--;

                if (GetComponent<shipstats>().shiphealth <= 0)
                {
                    destroyunit();

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
                //AudioSource destroyed = GetComponent<AudioSource>();

                //destroyed.Play();
                //countdown = 500;                                     //time enemy aggro duration
                GetComponent<shipstats>().shiphealth--;
                
                if (GetComponent<shipstats>().shiphealth <= 0)
                {
                    destroyunit();

                }


            }

        }
        if (other.gameObject.CompareTag("spinner") && (gameObject.tag == "enemy"))
        {
            canmove = false;
           // Destroy(other.gameObject);
            countdownstun = countdownstunduration;
            if (gameObject.tag == "enemy")
            {

                //countdown = 500;                                     //time enemy aggro duration
                GetComponent<shipstats>().shiphealth-=1;

                if (GetComponent<shipstats>().shiphealth <= 0)
                {
                    destroyunit();
                }


            }

        }
        if (other.gameObject.CompareTag("enemy") && (gameObject.tag == "enemy"))
        {
            thisbody.velocity = Vector3.zero;
        }
            if (other.gameObject.CompareTag("bulletmindcontrol"))
        {
            Renderer rend = GetComponent<Renderer>();
        
            rend.material.SetTextureOffset("_MainTex", new Vector2(1.5f, 0));
       
            playersbulletspawn = GameObject.FindWithTag("HeroicUnit");
            GetComponent<playerlookatmouse>().enabled = true;
            GetComponent<playermove>().enabled = true;
            playersbulletspawn.gameObject.tag = "HeroicUnitTemp";
            GetComponentInChildren<spawnbulletenemy>().enabled = false;
            GetComponentInChildren<spawnbullet>().enabled = true;
            gameObject.tag = "Player";                                          ///
            target2.gameObject.tag = "Untagged";                                    ////
            childObj.gameObject.tag = "HeroicUnit";
            
            //other.gameObject.SetActive(false);
            childObj.gameObject.SetActive(true);
            target2.GetComponent<playerlookatmouse>().enabled = false;
            target2.GetComponent<playermove>().enabled = false;
            other.gameObject.SetActive(false);
            target2.GetComponentInChildren<spawnbullet>().enabled = false;
            GetComponent<deflookatenemy>().enabled = false;
            GetComponentInChildren<spawnbulletdefender>().enabled = false;
            GetComponent<lookatplayer>().enabled = false;
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled=false;

        }
        waitthenactivate();
    }
}