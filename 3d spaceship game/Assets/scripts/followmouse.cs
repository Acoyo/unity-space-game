using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followmouse : MonoBehaviour
{
    static public float depth = 20.3f;
    public float depthdis;
    static public bool r = true;
    public Transform thispos;
    public GameObject spheregrow;
    private int destroyer = 0;
    // Use this for initialization
    void Start()
    {

    }
  
    // Update is called once per frame
    void Update()
    {
        thispos = GetComponent<Transform>();

        
        {
            Vector3 temp = Input.mousePosition;
            temp.z = 90; // Set this to be the distance you want the object to be placed in front of the camera.
                         // temp.y = 4f;
            temp.z = depth;

            depthdis = depth;
            this.transform.position = Camera.main.ScreenToWorldPoint(temp);
            //Instantiate(spheregrow, thispos.position, thispos.rotation);


        }
    }
}