using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionbullets : MonoBehaviour {
    public GameObject owner;
	// Use this for initialization
	void Start () {
        owner = FindOwner();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            owner.GetComponent<lookatplayer>().canseeyou = true;
            owner.GetComponent<lookatplayer>().lastseenposition = gameObject.transform.position;
            owner.GetComponent<lookatplayer>().distancelastseenbool = true;
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("enbullet"))
        {
            return;
        }
        else if (other.gameObject.CompareTag("Untagged"))
        {
            return;
        }
        else if (other.gameObject.CompareTag("enemybase"))
        {
            return;
        }
        else if (other.gameObject.CompareTag("closequarters"))
        {
            return;
        }
        else if (other.gameObject.CompareTag("fakeplayer"))
        {
            return;
        }
        else if (other.gameObject.CompareTag("spinner"))
        {
            return;
        }
        else if (other.gameObject.CompareTag("enemybasehealing"))
        {
            return;
        }
        else if (other.gameObject.CompareTag("enemy"))
        {
            return;
        }
        else if (other.gameObject.CompareTag("detectionbullet"))
        {
            return;
        }
      
        else if ((other.gameObject.CompareTag("bulletknockback")) || (other.gameObject.CompareTag("bullet")))
        {
            return;
        }
        else
        { 
            owner.GetComponent<lookatplayer>().canseeyou = false;
           // owner.GetComponent<lookatplayer>().distancelastseenbool = false;
            Destroy(gameObject);
        }
    }
        public GameObject FindOwner()
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
            }
        }
        return closest;
    }
}

