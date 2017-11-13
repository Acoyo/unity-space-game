using UnityEngine;
using System.Collections;

public class moverTeleport : MonoBehaviour
{
    public float speed;
    public Transform target;
    public GameObject targetobj;
    public GameObject player;
    public Transform playertrans;
    public GameObject playerbulletspawn;
    private bool switcher;

    public GameObject bullet;
    public Transform orig;
    public Renderer rend;

    private void Start()
    {
        mouseclick.bulletteleport = true;
        rend = player.GetComponent<Renderer>();
        switcher = true;
        Physics.gravity = new Vector3(0, +1.0F, 0);
        playerbulletspawn= GameObject.FindWithTag("HeroicUnit");
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1)&&(mouseclick.bulletteleport == false))
        {
            ////mouseclick.bulletteleport = true;
            //player = GameObject.Find("aaaaaa");
            //rend = player.GetComponent<Renderer>();
            //player.gameObject.tag = "Untagged";
            //playerbulletspawn.gameObject.tag = "Untagged";
            //rend.enabled = false;
            //targetobj = GameObject.FindWithTag("follow");
            //target = targetobj.transform;
            //Destroy(gameObject);
            //transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
            //mouseclick.bulletteleport = true;
        }
    }
    void FixedUpdate()
    {
     
        if (switcher == true)
        {
            player = GameObject.Find("aaaaaa");
            rend = player.GetComponent<Renderer>();
            player.gameObject.tag = "Untagged";
            playerbulletspawn.gameObject.tag = "Untagged";
            rend.enabled = false;
            targetobj = GameObject.FindWithTag("follow");
            target = targetobj.transform;

            transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        }
        if (switcher == false)
        {
            //transform.position = Vector3.MoveTowards(transform.position, mouseclick.mousesave, speed);
            //transform.Translate(Vector3.forward * Time.deltaTime*(speed*50)); 
            //GetComponent<Rigidbody>().velocity = transform.forward * 15;

        }

        //if (Input.GetKeyDown(KeyCode.LeftShift))
        if (mouseclick.bulletoff == true)
        {
            player = GameObject.Find("aaaaaa");
            orig = GetComponent<Transform>();
            //playertrans = orig;
            //firebullet();

            // GetComponent<playerlookatmouse>().enabled = false;
            player.gameObject.tag = "Player";
            player.transform.position = orig.transform.position;
           // orig.transform.position.y = 0;
            rend.enabled = true;
            mouseclick.bulletoff = false;
            switcher = false;
            playerbulletspawn.gameObject.tag = "HeroicUnit";
            mouseclick.bulletteleport = false;
            Destroy(gameObject);

        }
    }
    void firebullet()
    {
        Instantiate(bullet, new Vector3(orig.position.x, orig.position.y, orig.position.z), orig.rotation);
        //Instantiate(bullet, new Vector3(orig.position.x, orig.position.y, orig.position.z + 2), orig.rotation);
    }
    void OnMouseDown()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("follow"))
        {
           // Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("bullet"))
        {
            //Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("enbullet"))
        {
           // transform.localScale += new Vector3(0.5F, 0.5F, 0.5F);
           // Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("enemy"))
        {
            //Destroy(other.gameObject);
            //Destroy(gameObject);
        }
    }
}