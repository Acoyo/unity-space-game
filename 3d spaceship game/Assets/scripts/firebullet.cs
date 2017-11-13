using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firebullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform orig;
    public Transform mousepos;
    public int speed = 10;
    public int destroyTime=4;
    // Use this for initialization
    void Start()
    {
       // orig = GetComponent<Transform>();
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && (gameObject.name == "playerbullet(Clone)"))
        {
            Destroy(gameObject);
        }
        //transform.Translate(Vector3.forward * Time.deltaTime);

    }

    void shootbullet()
    {
       // Instantiate(bullet, new Vector3(orig.position.x, orig.position.y, orig.position.z), orig.rotation);
    }
    void OnTriggerEnter(Collider other)
    {

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
