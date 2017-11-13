using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbullet : MonoBehaviour {
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public GameObject bullet5;
    public GameObject ship;
    public GameObject currentbullet;

    public Transform orig;
    public Transform centreofplayer;
    public Transform mousepos;
    public bool bulletswitch = false;
    public int countdown;
    public int coundownattackspeed;
    // Use this for initialization
    void Start () {
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
    {
        countdown--;
        if (countdown <= 0)
        {
            countdown = coundownattackspeed;
            coundownattackspeed = GetComponentInParent<shipstats>().attackspeed;
        }
    }
   
    void Update () {

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

        else if (Input.GetKeyDown("space") && (ship.gameObject.tag == "Player"))

        {

            mouseclick.firstclick = true;
            mouseclick.bulletoff = false;

            firebullet2();

        }
        if (Input.GetMouseButtonDown(1))
        {
            if(mouseclick.bulletteleport==false)
            firebullet();
        }
            

    }
    //void OnMouseDown()
    //{
    //    firebullet();
    //}
        void firebullet()
    {
        Instantiate(bullet5, new Vector3(centreofplayer.position.x, centreofplayer.position.y, centreofplayer.position.z), Quaternion.identity);
    }
    void firebullet3()
    {
        Instantiate(bullet, new Vector3(orig.position.x, orig.position.y, orig.position.z), orig.rotation);
    }
    void firebullet2()
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
