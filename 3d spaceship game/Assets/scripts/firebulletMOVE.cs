using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firebulletMOVE : MonoBehaviour {
    public float speed = .5f;
    public GameObject bullet;
    public GameObject mousecursor;
    public Transform bulletpacerunner;
    public Transform cursor;
    private Transform cursorcopy;
    public float distance;
    public float distancefurther;
    public float destroyTime = 3f;
    private Rigidbody rb;
    public Vector3 mousewas;
    public Transform orig;
    //private bool onoff = false;
    // Use this for initialization

    void Start () {
        // if (onoff == false)
            mouseclick.bulletfollow = false;                                        
            Destroy(gameObject, destroyTime);
            mousecursor = GameObject.FindWithTag("cursor");
            cursor.transform.position = mousecursor.transform.position;
            distance = Vector3.Distance(transform.position, cursor.position);
            distancefurther = distance * 2;
            cursorcopy = cursor;
        
            gameObject.name = "playerbullet";
                                                     ////just changed 


        // rb = GetComponent<Rigidbody>();
        // Vector3 temp = Input.mousePosition;
        //mousewas = temp;
        //Vector3 temp = Input.mousePosition;
        // onoff = true;

        //GetComponent<Rigidbody>().velocity = transform.forward * speed;
        //transform.position = Vector3.MoveTowards(transform.position, cursor.transform.position, speed/1000);
        //GetComponent<Rigidbody>().velocity = transform.forward * speed;
        //transform.position = Vector3.MoveTowards(transform.position, mousecursor.transform.position, speed);
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("cursor");
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
    // Update is called once per frame
    void Update () {
        // distance = Vector3.Distance(transform.position, cursor.position);
       // cursorcopy.transform.position = cursorcopy.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, FindClosestEnemy().transform.position, speed / 1000);     // this one
                                                                                                                                   //Vector3 temp = Input.mousePosition;
                                                                                                                                   //Vector3 temp = Input.mousePosition;
        if (Input.GetKeyDown("space") && ((gameObject.name == "playerbullet(Clone)") || (gameObject.name == "playerbullet")))
        {
            Destroy(gameObject);
        }                                                                                                                         //  rb.AddForce(mousewas * speed/1000);
        if (mouseclick.bulletoff == true)
        {
            
            orig = GetComponent<Transform>();
            firebullet();
            //switcher = false;
            //GetComponent<playerlookatmouse>().enabled = false;
            mouseclick.bulletoff = false;
            Destroy(gameObject);

        }

    }
    void firebullet()
    {
        Instantiate(bullet, new Vector3(orig.position.x, orig.position.y, orig.position.z), Quaternion.identity);
        //Instantiate(bullet, new Vector3(orig.position.x, orig.position.y, orig.position.z + 2), orig.rotation);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("follow"))
        {
            //Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("enbullet"))
        {
            //Destroy(other.gameObject);
            //Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            //Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("cursor"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
