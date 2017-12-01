using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nearestenemy : MonoBehaviour {
    public float thedistance;
    public MeshRenderer redpointer;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (thedistance > 50000)
        //{
        //    redpointer.enabled = true;
            transform.LookAt(closestenemy().transform.position);
        //}
        
        //if (thedistance < 50000)
        //{
        //    redpointer.enabled = false;
        //}
       Vector3 distance2 = gameObject.transform.position - closestenemy().transform.position;
        thedistance= distance2.sqrMagnitude;
    }
    public GameObject closestenemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        //int healthinf = 1000;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            //int health = go.GetComponent<shipstats>().shiphealth;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
                //thedistance = distance;
            }
        }
        return closest;
    }
}
