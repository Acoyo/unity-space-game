using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateminibullet : MonoBehaviour
{
    // public int randone = 21; //(Random.Range(15, 20));
    public GameObject target;
    public Transform targettemp;
    public GameObject bulletdiehere;
    public float speed;
    private int minispin;
    public bool minispinbool;
    public float distancefromdiehere;
    public Vector3 dieherepls;
    public float destroytime=1.7f;
    
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, destroytime);
        minispinbool = mouseclick.minispinbool;
        mouseclick.minispinbool= !mouseclick.minispinbool;
        minispin = mouseclick.bulletminispin;
        mouseclick.bulletminispin++;
        if (mouseclick.bulletminispin >= 8)
        {
            mouseclick.bulletminispin = 0;
        }
        //randone = (Random.Range(15, 20));
        if (minispin == 0)
        {
            target = GameObject.Find("aggrosphere-45");
        }
        if (minispin == 1)
        {
            target = GameObject.Find("aggrosphere+45");
        }
        if (minispin == 2)
        {
            target = GameObject.Find("aggrosphere+45");
        }
        if (minispin == 3)
        {
            target = GameObject.Find("aggrosphere+135");
        }
        if (minispin == 4)
        {
            target = GameObject.Find("aggrosphere+135");
        }
        if (minispin == 5)
        {
            target = GameObject.Find("aggrosphere-135");
        }
        if (minispin == 6)
        {
            target = GameObject.Find("aggrosphere-135");
        }
        if (minispin == 7)
        {
            target = GameObject.Find("aggrosphere-45");
        }
        targettemp = target.transform;
        dieherepls = targettemp.transform.position;
    }
    void Update()
    {
        distancefromdiehere = Vector3.Distance(gameObject.transform.position, bulletdiehere.transform.position);
        if (distancefromdiehere <= 20f)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (minispinbool == true)
        {
           // target = GameObject.Find("aggrosphere-45");
            transform.RotateAround(dieherepls, Vector3.up, 20 * Time.deltaTime * speed);
        }
        if (minispinbool == false)
        {
            //target = GameObject.Find("aggrosphere+45");
            transform.RotateAround(dieherepls, Vector3.down, 20 * Time.deltaTime * speed);
        }
        targettemp = target.transform;
       // bulletdiehere= GameObject.Find("aggrospheremiddle");
        // transform.RotateAround(targettemp.transform.position, Vector3.up, 20 * Time.deltaTime * speed);
    }
}
