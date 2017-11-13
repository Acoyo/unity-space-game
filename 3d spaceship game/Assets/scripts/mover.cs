using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour
{
    public float speed;
    public Transform target;
    public GameObject targetobj;
    private bool switcher;

    public GameObject bullet;
    public Transform orig;

    private void Start()
    {
        mouseclick.bulletfollow = true;
        switcher = true;
        Physics.gravity = new Vector3(0, +1.0F, 0);

    }

    void FixedUpdate()
    {
        //mouseclick.bulletoff = true;
        if (switcher== true) {
        targetobj = GameObject.FindWithTag("follow");
        target = targetobj.transform;
    
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
    }
        if (switcher == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, mouseclick.mousesave, speed);
            //transform.Translate(Vector3.forward * Time.deltaTime*(speed*50)); 
            //GetComponent<Rigidbody>().velocity = transform.forward * 15;
           
        }
        if (Input.GetKeyDown("space") && (gameObject.name == "playerbullet(Clone)"))
        {
            Destroy(gameObject);
        }
               //if (Input.GetKeyDown(KeyCode.LeftShift))
          if (mouseclick.bulletoff==true)
        {
            
            orig = GetComponent<Transform>();
            firebullet();
            switcher = false;
            GetComponent<playerlookatmouse>().enabled = false;
            mouseclick.bulletoff = false;
            Destroy(gameObject);

        }
                                                                                     //Delete TEST
    }
    void firebullet()
    {
        Instantiate(bullet, new Vector3(orig.position.x, orig.position.y, orig.position.z), Quaternion.identity);
        //Instantiate(bullet, new Vector3(orig.position.x, orig.position.y, orig.position.z + 2), orig.rotation);
    }
    void OnMouseDown()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("follow"))
        {
            //Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("bullet"))
        {
            //Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("enbullet"))
        {
            transform.localScale += new Vector3(0.5F, 0.5F, 0.5F);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("enemy"))
        {
            //Destroy(other.gameObject);
            //Destroy(gameObject);
        }
    }
}