using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbulletdefender : MonoBehaviour
{
    public GameObject defbullet;
    public Transform orig;
    public Transform mousepos;
    public int countdown;
    public int coundownattackspeed = 100;
    public Transform target;

    public GameObject target2;
    public GameObject childObj;

    public float distance;
    public float mindist = 5f;
    public float maxdist = 20f;
    // Use this for initialization
    void Start()
    {
       // Renderer rend = GetComponent<Renderer>();
        // rend.material.shader = Shader.Find("Specular");
        // rend.material.SetColor("_SpecColor", Color.blue);
       // rend.material.SetTextureOffset("_MainTex", new Vector2(1.5f, 0));
        //target2 = GameObject.FindWithTag("enemy");
        //target = target2.transform;
        //orig = GetComponent<Transform>();
        coundownattackspeed = GetComponentInParent<shipstats>().attackspeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, FindClosestEnemy().transform.position);
        countdown--;
        if ((countdown <= 0) && (distance <= maxdist) && (distance >= mindist)&&(FindClosestEnemy().transform.position!=null))
        {
            firebullet();
            countdown = coundownattackspeed;
            coundownattackspeed = GetComponentInParent<shipstats>().attackspeed;
          //  Debug.Log("                          YYYYAAAAAAA");
        }

       
        //target2 = GameObject.FindWithTag("enemy");
        //target = target2.transform;
        //orig = gameObject.transform;
    }
    private void Update()
    {
     
    }

    void firebullet()
    {
        
        Instantiate(defbullet, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), transform.rotation);
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
}
