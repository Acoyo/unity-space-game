using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firebullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform orig;
    public Transform mousepos;
    public  float speed = 10f;
    public float speedslows = 20f;
    public bool lr;
    public float destroyTime=4;
    public Rigidbody thisbody;
    // Use this for initialization
    void Start()
    {
        //thisbody = GetComponent<Rigidbody>();
        //thisbody.AddForce(0, 5, 0);
        // orig = GetComponent<Transform>();
        GetComponent<Rigidbody>().velocity = transform.forward * speed;// transform.right* speedslows;
        //GetComponent<Rigidbody>().velocity = transform.right * speedslows;
        // transform.Translate(Vector3.forward * Time.deltaTime);
        //transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
        Destroy(gameObject, destroyTime);
    }
  
    // Update is called once per frame
 
    void Update()
    {
        //thisbody.AddForce(0, 0, 20, ForceMode.Impulse);
        if (Input.GetKeyDown("space") && (gameObject.name == "playerbullet(Clone)"))
        {
            //Destroy(gameObject);
        }
        //transform.Translate(Vector3.forward * Time.deltaTime);

    }

    void shootbullet()
    {
       // Instantiate(bullet, new Vector3(orig.position.x, orig.position.y, orig.position.z), orig.rotation);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enbullet"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("enemy"))
        {
            if (gameObject.tag == "bullethealing")
            {
                other.GetComponent<shipstats>().shiphealth++;
                Destroy(gameObject);
            }
            //Destroy(other.gameObject);
            //other.gameObject.name = "tempplayer";
        }
        if (other.gameObject.CompareTag("Player"))
        {
            if (gameObject.tag == "bullethealing")
            {
                other.GetComponent<shipstats>().shiphealth++;
                Destroy(gameObject);
            }
            //Destroy(other.gameObject);
            //other.gameObject.name = "tempplayer";
        }
    }
    }
