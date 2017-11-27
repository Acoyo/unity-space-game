using System;
using UnityEngine;

public class defmover : MonoBehaviour
{
    public Transform target;
    public GameObject target2;
    public float speed = 1;
    public float distance;
    public float mindist = 5f;
    public float maxdist = 20f;
    public float destroyTime = 1f;

    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
    void Update()
    {

        //if (target == null)
        //{
        //    Destroy(gameObject);
        //}
        distance = Vector3.Distance(transform.position, FindClosestEnemy().transform.position);
        target2 = GameObject.FindWithTag("enemy");
        target = target2.transform;
        //if (target != null)
        {
            transform.LookAt(FindClosestEnemy().transform.position);
        }
        transform.position = Vector3.MoveTowards(transform.position, FindClosestEnemy().transform.position, speed);
        if (distance > maxdist + 10)
        {
            Destroy(gameObject);
        }
     
      
    }
    private void FixedUpdate()
    {
   
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("enemy");
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
    void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.CompareTag("enemy"))
        {
           // Destroy(other.gameObject);
           // Destroy(gameObject);
            


        }
    }
}