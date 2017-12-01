using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbulletdefender : MonoBehaviour
{
    public GameObject defbullet;
    public GameObject sidetosidebullets;
    public Transform bulletspawn;
    public Transform mousepos;
    public int countdown;
    public int coundownattackspeed = 100;
    public Transform target;

    public GameObject target2;
    public GameObject childObj;
    public GameObject sidetosidetrans;
    public GameObject sidetosidetransRev;
    public GameObject STSlooks;
    public GameObject STSRevlooks;
    public bool shipskinfalconbool;
    public float distance;
    public float mindist = 5f;
    public float maxdist = 20f;
    public int countdowndetection;
    public GameObject detectionbullets;
    public bool canseeyou = false;
    // Use this for initialization
    void Start()
    {
        shipskinfalconbool = GetComponent<spawnbullet>().shipskinfalconbool;
       // Renderer rend = GetComponent<Renderer>();
        // rend.material.shader = Shader.Find("Specular");
        // rend.material.SetColor("_SpecColor", Color.blue);
       // rend.material.SetTextureOffset("_MainTex", new Vector2(1.5f, 0));
        //target2 = GameObject.FindWithTag("enemy");
        //target = target2.transform;
        //orig = GetComponent<Transform>();
        coundownattackspeed = GetComponentInParent<shipstats>().attackspeed;
        countdown = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, FindClosestEnemy().transform.position);
        countdown--;
        countdowndetection--;
        if ((countdown <= 0) && (distance <= maxdist) && (distance >= mindist)&&(FindClosestEnemy().transform.position!=null) && (canseeyou == true))
        {
            if (shipskinfalconbool == false)
            {
                firebullet();
            }
            
            if (shipskinfalconbool == true)
            {
                firebullet();
                sidetosidebulletslooks();
                //GetComponentInParent<shipstats>().attackspeed = 20;
            }
            countdown = coundownattackspeed;
            coundownattackspeed = GetComponentInParent<shipstats>().attackspeed;
          //  Debug.Log("                          YYYYAAAAAAA");
        }
        if ((countdowndetection <= 0) && (distance < maxdist))
        {
            detectionbullet();
            countdowndetection = 5;
        }

        //target2 = GameObject.FindWithTag("enemy");
        //target = target2.transform;
        //orig = gameObject.transform;
    }
    public void detectionbullet()
    {
        Instantiate(detectionbullets, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);

    }
    private void Update()
    {
     
    }
    void sidetosidebulletslooks()
    {
        Instantiate(defbullet, new Vector3(STSlooks.transform.position.x, STSlooks.transform.position.y, STSlooks.transform.position.z), STSlooks.transform.rotation);
        Instantiate(defbullet, new Vector3(STSRevlooks.transform.position.x, STSRevlooks.transform.position.y, STSRevlooks.transform.position.z), STSRevlooks.transform.rotation);

    }
    void firebullet()
    {
        
        Instantiate(defbullet, new Vector3(bulletspawn.position.x, bulletspawn.position.y, bulletspawn.position.z), bulletspawn.rotation);
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
}
