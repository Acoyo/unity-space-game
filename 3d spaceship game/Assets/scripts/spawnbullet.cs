using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbullet : MonoBehaviour {
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public GameObject bullet5;
    public GameObject bulletleft;
    public GameObject bulletright;
    public GameObject ship;
    public GameObject currentbullet;
    public Transform middle;
    public Transform middletemp;
    public GameObject heroic;

    public Transform orig;
    public Transform centreofplayer;
    public Transform mousepos;
    public bool bulletswitch = false;
    public int countdown;
    public int coundownattackspeed;
    // Use this for initialization
    private void OnEnable()
    {
       // heroic= GameObject.FindWithTag("HeroicUnit");
    }
    void Start () {
        heroic = GameObject.FindWithTag("HeroicUnit");
        orig = GetComponent<Transform>();
        currentbullet = bullet;
        coundownattackspeed = GetComponentInParent<shipstats>().attackspeed;
        if (gameObject.name != "aaaaaa")
        {
            if (GetComponent<spawnbulletenemy>().temp == 0)
            {
                currentbullet = bullet2;
            }
            if (GetComponent<spawnbulletenemy>().temp == 1)
            {
                currentbullet = bullet;
            }
        }

    }
    void FixedUpdate()
    {//if (heroic.tag== "HeroicUnit")
        {
            countdown--;
            if (countdown < 0)
            {
                coundownattackspeed = GetComponentInParent<shipstats>().attackspeed;
                countdown = coundownattackspeed;

            }
            if (Input.GetMouseButton(0) && (ship.gameObject.tag == "Player") && (countdown == 0))

            {

                mouseclick.firstclick = true;
                mouseclick.bulletoff = false;

                fireleftmouse();

            }
        }
    }

    void Update()
    {
        //if (heroic.tag == "HeroicUnit")
        {
            //countdown--;
            //if (countdown < 0)
            //{
            //    coundownattackspeed = GetComponentInParent<shipstats>().attackspeed;
            //    countdown = coundownattackspeed;

            //}

            if (Input.GetKeyDown(KeyCode.Alpha1))

            {
                currentbullet = bullet;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))

            {
                currentbullet = bullet2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))

            {
                currentbullet = bullet3;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))

            {
                currentbullet = bullet4;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))

            {
                currentbullet = bullet5;
            }
            else if (Input.GetKeyDown(KeyCode.Space))

            {
                firebullet();
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))

            {
                firecurvebullets();
                Debug.Log("yo");
            }


            if (Input.GetMouseButtonDown(1) && (ship.gameObject.tag == "Player"))// && (countdown == 0))
            {
                //if(mouseclick.bulletteleport==false)
                firecurvebullets();
            }


        }
    }
    //void OnMouseDown()
    //{
    //    firebullet();
    //}
        void firebullet()
    {
        Instantiate(bullet2, new Vector3(centreofplayer.position.x, centreofplayer.position.y, centreofplayer.position.z), centreofplayer.rotation);
    }
    void firerightmouse()
    {
        Instantiate(bullet3, new Vector3(orig.position.x, orig.position.y, orig.position.z), orig.rotation);
    }
    void firecurvebullets()
    {
        Instantiate(middle, new Vector3(middletemp.position.x, middletemp.position.y, middletemp.position.z), middletemp.rotation);
        Instantiate(bulletleft, new Vector3(orig.position.x, orig.position.y, orig.position.z+4), orig.rotation);
        Instantiate(bulletright, new Vector3(orig.position.x, orig.position.y, orig.position.z+4), orig.rotation);
        //middle.name = "middle";
        
        //middle.name = "middle";

    }
    void fireleftmouse()
    {
        if (gameObject.name == "pbullet spawn")
        {
            
            Instantiate(currentbullet, new Vector3(orig.position.x, orig.position.y, orig.position.z), orig.rotation);
            currentbullet.name = "playerbullet";
        }
        else if (gameObject.name != "pbullet spawn")
        {
            //currentbullet.name = "playerbullet";
            Instantiate(currentbullet, new Vector3(orig.position.x, orig.position.y, orig.position.z), orig.rotation);
            currentbullet.name = "averagebullet";
        }
    }
}
