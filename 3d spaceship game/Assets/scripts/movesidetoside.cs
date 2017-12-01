using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movesidetoside : MonoBehaviour
{
    public bool dirRight = true;
    public float speed = 2.0f;
    private float distL=-4f;
    private float distR=4f;
    public float thedist=4f;
    public float mousedistance;
    public GameObject sidetosideorig;
    public bool isfiring = false;


    private void Start()
    {
        //sidetosideorig = GameObject.Find("pbullet SPAWN");
        thedist = 0;
    }
    private void Update()
    {
        
            //if(mouseclick.bulletteleport==false)
           // gameObject.transform.position = sidetosideorig.position;
        
    }

    void FixedUpdate()
    {
       // transform.position = Vector3.MoveTowards(transform.position, sidetosideorig.transform.position, speed);
        if (Input.GetMouseButtonUp(0))
        {
            thedist = 0;
        }
        if (Input.GetMouseButton(0)==false)
        {
            transform.position = Vector3.MoveTowards(transform.position, sidetosideorig.transform.position, speed);
        }
            if (Input.GetMouseButton(0))
        {
            mousedistance = playerlookatmouse.mousedistancefromplayer;
            thedist = playerlookatmouse.mousedistancefromplayer / 20;
            distL = 0 + thedist;
            distR = 0 - thedist;
            if (dirRight)
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            else
                transform.Translate(-Vector2.right * speed * Time.deltaTime);
            //if (distL == 0)
            //{
            //    gameObject.transform.position = sidetosideorig.position;
            //}
            if (transform.localPosition.x >= distL)
            {
                dirRight = false;

            }

            if (transform.localPosition.x <= distR)
            {
                dirRight = true;
            }
        }
    }
}