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
    public GameObject bulletwhite;
    public GameObject bulletminispin;
    public GameObject bulletminispincopy;
    public GameObject ship;
    public GameObject currentbullet;
    public GameObject player;
    public Transform middle;
    public Transform middletemp;
    public GameObject heroic;

    public Transform bulletSPAWN;
    public Transform sidetosidetrans;
    public Transform sidetosidetransRev;
    public Transform STSlooks;
    public Transform STSRevlooks;
    public Transform bulletleftspawn;
    public Transform bulletrightspawn;
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
        //bulletSPAWN = GetComponent<Transform>();
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
        //transform.rotation = Quaternion.Euler(0, 90, 0);

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
                sidetosidebulletslooks();
                    sidetosidebullets();

            }
            if (Input.GetKey(KeyCode.LeftShift) && (ship.gameObject.tag == "Player") && (countdown == 0))

            {
                // duofire();
                fireminispin();
               // sidetosidebullets();
                Debug.Log("yo");
            }
            //if (Input.GetKeyDown(KeyCode.LeftShift) && (ship.gameObject.tag == "Player") && (countdown == 0))

            //{
            //    duofire();
            //    Debug.Log("yo");
            //}
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
    void boxoftricks()
    {
        Instantiate(bulletminispin, new Vector3(bulletSPAWN.position.x, bulletSPAWN.position.y, bulletSPAWN.position.z), bulletSPAWN.rotation);
        
    }
    void firebullet()
    {
        Instantiate(bullet2, new Vector3(centreofplayer.position.x, centreofplayer.position.y, centreofplayer.position.z), centreofplayer.rotation);
    }
    void firerightmouse()
    {
        Instantiate(bullet3, new Vector3(bulletSPAWN.position.x, bulletSPAWN.position.y, bulletSPAWN.position.z), bulletSPAWN.rotation);
    }
    void fireminispin()
    {
        Instantiate(bulletminispin, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
        Instantiate(bulletminispin, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
        Instantiate(bulletminispincopy, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
        Instantiate(bulletminispincopy, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
        Instantiate(bulletminispin, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
        Instantiate(bulletminispin, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
        Instantiate(bulletminispincopy, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
        Instantiate(bulletminispincopy, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), player.transform.rotation);
    }

    void sidetosidebullets()
    {
        Instantiate(currentbullet, new Vector3(sidetosidetrans.position.x, sidetosidetrans.position.y, sidetosidetrans.position.z), sidetosidetrans.rotation);
        Instantiate(currentbullet, new Vector3(sidetosidetransRev.position.x, sidetosidetransRev.position.y, sidetosidetransRev.position.z), sidetosidetransRev.rotation);

    }
    void sidetosidebulletslooks()
    {
        Instantiate(bulletwhite, new Vector3(STSlooks.position.x, STSlooks.position.y, STSlooks.position.z), STSlooks.rotation);
        Instantiate(bulletwhite, new Vector3(STSRevlooks.position.x, STSRevlooks.position.y, STSRevlooks.position.z), STSRevlooks.rotation);

    }
    void duofire()
    {
        Instantiate(currentbullet, new Vector3(bulletleftspawn.position.x, bulletleftspawn.position.y, bulletleftspawn.position.z), bulletleftspawn.rotation);
        Instantiate(currentbullet, new Vector3(bulletrightspawn.position.x, bulletrightspawn.position.y, bulletrightspawn.position.z), bulletrightspawn.rotation);

    }
    void firecurvebullets()
    {
        Instantiate(middle, new Vector3(middletemp.position.x, middletemp.position.y, middletemp.position.z), middletemp.rotation);
        Instantiate(bulletleft, new Vector3(bulletSPAWN.position.x, bulletSPAWN.position.y, bulletSPAWN.position.z+4), bulletSPAWN.rotation);
        Instantiate(bulletright, new Vector3(bulletSPAWN.position.x, bulletSPAWN.position.y, bulletSPAWN.position.z+4), bulletSPAWN.rotation);
        //middle.name = "middle";
        
        //middle.name = "middle";

    }
    void fireleftmouse()
    {
        if (gameObject.name == "pbullet spawn")
        {
            
            Instantiate(currentbullet, new Vector3(bulletSPAWN.position.x, bulletSPAWN.position.y, bulletSPAWN.position.z), bulletSPAWN.rotation);
            currentbullet.name = "playerbullet";
        }
        else if (gameObject.name != "pbullet spawn")
        {
            //currentbullet.name = "playerbullet";
            Instantiate(currentbullet, new Vector3(bulletSPAWN.position.x, bulletSPAWN.position.y, bulletSPAWN.position.z), bulletSPAWN.rotation);
            currentbullet.name = "averagebullet";
        }
    }
}
