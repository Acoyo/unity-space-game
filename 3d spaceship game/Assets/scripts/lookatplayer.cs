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
    public GameObject healingfountain;


    public float mindist=5f;
    public float maxdist = 20f;
    public float maxdistcopy;
    public int shiphealthenemy;
    public int grouphealth;
    public int countdown;
    public int countdownstun;
    public int countdownstunduration;
    public int countdowndif=0;
    public int cdhealing;
    public int healingcooldown = 100;
    public GameObject cam;
    public GameObject mouseclick2;
    private Rigidbody thisbody;
    private bool closequarters=false;
    public bool ishealing = false;
    public Color red = new Color(.5f, 0f, 1f, 0.4f);
    public Color brown = new Color(0.2f, .1f, 1, 0.2f);
    public Vector3 lastseenposition;
    public float distancelastseenposition;
    public bool distancelastseenbool;
    public float distancefromplayer;
    Vector3 playerpos;

    public Material defendermat;
    public bool canmove;
    public bool canseeyousnap= true;
    public Renderer thisobject;

  
    private void Start()
    {
        Renderer rend = GetComponent<Renderer>();
       // rend.material.shader = Shader.Find("Specular");
        //rend.material.SetColor("_Color", Color.blue);

        //transform.position = new Vector3(transform.position.x+0, 0, transform.position.z+0);
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
        canseeyousnap = true;
        transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = enemybasetransform().transform.position;
        if (GetComponentInChildren<spawnbulletenemy>().temp == 1)
        {
            //transform.localScale += new Vector3(2, 0, 2);
           // transform.position += new Vector3(0, 0, 0);
        }
        if (GetComponentInChildren<spawnbulletenemy>().temp == 0)
        {
            //transform.localScale += new Vector3(1, 2, 1);
           // transform.position += new Vector3(0, 0, 0);
        }


    }
    void Update()
    {
        if ((canseeyou == true)&&(canseeyousnap==true))
        {
            mouseclick.grouphealth += GetComponent<shipstats>().shiphealth;
            canseeyousnap = false;
        }
        if ((canseeyou == false) && (canseeyousnap == false))
        {
            mouseclick.grouphealth -= GetComponent<shipstats>().shiphealth;
            canseeyousnap = true;
        }
        grouphealth = mouseclick.grouphealth;
        playerpos = transform.position;
        distancelastseenposition = Vector3.Distance( lastseenposition, playerpos);
        distancefromplayer= Vector3.Distance(target2.transform.position, playerpos);
        if (distancefromplayer > 275)
        {
            distancelastseenbool = false;
        }
        if (distancelastseenposition < 1f)
        {
            distancelastseenbool = false;
        }
    }
    public void speeddoubled()
    {
        speeddouble = speed * 1.2f;
    }
    void FixedUpdate()
    {
        if (((canseeyou == false) && (GetComponent<shipstats>().shiphealth >= 4)) || (((grouphealth >= mouseclick.grouphealthplayer)) && (GetComponent<shipstats>().shiphealth >= 4)))// &&(canmove==true))              ///  move towards enemy base if one exists
        {
            if (distancelastseenbool == false)
            {
                transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = enemybasetransform().transform.position;
                transform.LookAt(FindClosestEnemy().transform.position);
            }
            if ((distancelastseenbool == true)&& (grouphealth >= mouseclick.grouphealthplayer))
            {
                transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = lastseenposition;
                transform.LookAt(FindClosestEnemy().transform.position);
             
            }
            if ((distancelastseenbool == true) && (grouphealth <= mouseclick.grouphealthplayer))
            {
                transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = enemybasetransform().transform.position;
                transform.LookAt(FindClosestEnemy().transform.position);

            }
        }
        //if (((canseeyou == false) && (GetComponent<shipstats>().shiphealth >= 4)) && (((grouphealth <= mouseclick.grouphealthplayer)) && (GetComponent<shipstats>().shiphealth >= 4)))// &&(canmove==true))              ///  move towards enemy base if one exists
        //{
        //    if (distancelastseenbool == false)

        //    {
        //        transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = enemybasetransform().transform.position;
        //        transform.LookAt(FindClosestEnemy().transform.position);

        //    }

        //}
        //if ((distance > mindist) && (distance < maxdist) && (canseeyou == false) && (grouphealth >= mouseclick.grouphealthplayer)/*&&(distancelastseenposition<=maxdist)*/)// && (FindClosestEnemy().transform != null))
        //{
        //    transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = lastseenposition;
        //    transform.LookAt(FindClosestEnemy().transform.position);
        //    // fakeplayer()    

        //}
        //if (canseeyou == true)
        //{

        //}
        if (distance > maxdist)
        {
            canseeyou = false;
        }
         enemybasetransform();
        waitthenactivate();
        thisbody.velocity = Vector3.zero;
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
        enemybase = enemybasetransform();
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
        healingfountain=GameObject.Find("Healing fountain enemy");
        if (countdownstun == 0)
        {
            thisbody.velocity = Vector3.zero;
            canmove = true;
        }
        if  (GetComponent<shipstats>().shiphealth <= 3)            // RUN AWAY RUN AWAY!!
        {
            transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = healingfountain.transform.position;
            transform.LookAt(FindClosestEnemy().transform.position);
        }
        if ((canmove == true)&&(GetComponent<shipstats>().shiphealth >= 4))
        {
            distance = Vector3.Distance(gameObject.transform.position, FindClosestEnemy().transform.position);
            distancefrombase = Vector3.Distance(gameObject.transform.position, enemybasetransform().transform.position);

            if (closequarters == true)
            {
                if ((distance > mindist) && (distance < maxdist) && (canseeyou == true)&& (grouphealth >= mouseclick.grouphealthplayer))// && (FindClosestEnemy().transform != null))
                {
                    transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = FindClosestEnemy().transform.position;
                    transform.LookAt(FindClosestEnemy().transform.position);
                    // fakeplayer()    
                }
                if ((distance > mindist) && (distance < maxdist+100) && (canseeyou == true) && (grouphealth <= mouseclick.grouphealthplayer))// && (FindClosestEnemy().transform != null))
                {
                    transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = healingfountain.transform.position;
                    transform.LookAt(FindClosestEnemy().transform.position);
                    // fakeplayer()    
                }

            }
            if (closequarters == false)
            {
                if ((distance > mindist) && (distance < maxdist) && (canseeyou == true) && (grouphealth >= mouseclick.grouphealthplayer))// && (FindClosestEnemy().transform != null))
                {
                    //transform.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = FindClosestEnemy().transform.position;
                    transform.position = Vector3.MoveTowards(transform.position, fakeplayer().transform.position, speed);
                    transform.LookAt(FindClosestEnemy().transform.position);
                    // fakeplayer()    
                }
                if ((distance < mindist) && (canseeyou == true) && (grouphealth >= mouseclick.grouphealthplayer))// && (FindClosestEnemy().transform != null))
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
    //public GameObject enemybaselowesthealth()
    //{
    //    GameObject[] gos;
    //    gos = GameObject.FindGameObjectsWithTag("enemybase");
    //    GameObject lowest = null;
    //    float basehealth = Mathf.Infinity;
    //    Vector3 position = transform.position;
    //    foreach (GameObject go in gos)
    //    {
    //        Vector3 diff = go.transform.position - position;
    //        float lowesthealthbase = go.GetComponent<enemybase>().enemybasehealth;
    //        if (lowesthealthbase < basehealth)
    //        {
    //            lowest = go;
    //            basehealth = lowesthealthbase;
    //        }
    //    }
    //    return lowest;
    //}
    public void destroyunit()
    {
        Instantiate(destroyed, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        mouseclick.amountofenemies -= 1;
        Destroy(gameObject);
    }
    IEnumerator waitthenactivate()
    {
       
        yield return new WaitForSeconds(2);
       // enemybaselowesthealth();
        thisbody.velocity = Vector3.zero;
        canmove = false;
        canmove = true;

    }
    IEnumerator enemybasehealing()
    {

        GetComponent<shipstats>().shiphealth++;
        yield return new WaitForSeconds(1);

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
           // if (enemybaselowesthealth().GetComponent<enemybase>().enemybasehealth < 100f)
            {
             //   enemybaselowesthealth().GetComponent<enemybase>().enemybasehealth += .1f;
            }
        }
    }
        void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("enemybasehealing") && (gameObject.tag == "enemy"))
        {
            //ishealing = true;
            //enemybasetransform().GetComponent<enemybase>().enemybasehealth++;
            GetComponent<shipstats>().shiphealth = GetComponent<shipstats>().maxhealth;
        }
        if (other.gameObject.CompareTag("closequarters") && (gameObject.tag == "enemy"))
        {
            closequarters = true;
        }
            if (other.gameObject.CompareTag("bullet")&&(gameObject.tag== "enemy"))
        {
          
            countdownstun = countdownstunduration;
            if (gameObject.tag == "enemy")
            {
                                           //time enemy aggro duration
                GetComponent<shipstats>().shiphealth--;
                if (GetComponent<shipstats>().shiphealth >= 0)
                {
                    mouseclick.grouphealth--;
                }
                if (GetComponent<shipstats>().shiphealth <= 0)
                {
                    shiphealthenemy = 0;
                    //mouseclick.amountofenemies -= 1;
                    destroyunit();
                   
                }

            }
        }
        if (other.gameObject.CompareTag("bulletknockback") && (gameObject.tag == "enemy"))
        {
         
            Destroy(other.gameObject);
            countdownstun = countdownstunduration;
            if (gameObject.tag == "enemy")
            {
          
                GetComponent<shipstats>().shiphealth--;
                if (GetComponent<shipstats>().shiphealth >= 0)
                {
                    mouseclick.grouphealth--;
                }
                if (GetComponent<shipstats>().shiphealth <= 0)
                {
                    shiphealthenemy = 0;
                    //mouseclick.amountofenemies -= 1;
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

                GetComponent<shipstats>().shiphealth-=1;
                //mouseclick.grouphealth--;
                if (GetComponent<shipstats>().shiphealth <= 0)
                {
                    shiphealthenemy = 0;
                    //mouseclick.amountofenemies -= 1;
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
            mouseclick.grouphealth -= GetComponent<shipstats>().shiphealth;
            //mouseclick.grouphealthplayer += GetComponent<shipstats>().shiphealth;
            Renderer rend = GetComponent<Renderer>();
        
            rend.material.SetTextureOffset("_MainTex", new Vector2(1.5f, 0));
       
            playersbulletspawn = GameObject.FindWithTag("HeroicUnit");
            GetComponent<playerlookatmouse>().enabled = true;
            GetComponent<playermove>().enabled = true;
            playersbulletspawn.gameObject.tag = "HeroicUnitTemp";
            GetComponentInChildren<spawnbulletenemy>().enabled = false;
            GetComponentInChildren<spawnbullet>().enabled = true;
            gameObject.tag = "Player";                                          ///
            //target2.gameObject.tag = "Untagged";                                    ////justchanged
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
            mouseclick.amountofenemies -= 1;
            gameObject.name = ("tempplayer");                                          //justchanged
            //mouseclick.grouphealthplayer
            transform.position = new Vector3(transform.position.x, -2, transform.position.z);
        }
        waitthenactivate();
    }
}