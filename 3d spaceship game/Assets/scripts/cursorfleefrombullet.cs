using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorfleefrombullet : MonoBehaviour {
    public float moveSpeed = 1f;
    public float destroyTime = 10f;
    public Transform temppos;
    // Use this for initialization
    void Start () {
        FindClosestEnemy();
        Destroy(gameObject, destroyTime);
        temppos= FindClosestEnemy().transform;
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("follow");
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
  
        Vector3 dir = transform.position - FindClosestEnemy().transform.position;
        transform.Translate(dir * moveSpeed * Time.deltaTime);
   
    }
    private void FixedUpdate()
    {
        if (mouseclick.plantcursor == true)
        {
            Destroy(gameObject);
        }
    }
}
