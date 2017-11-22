using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybase : MonoBehaviour {
    public int randnum;
    public int cd;
    public float enemybasehealth=100;
	// Use this for initialization
	void Start () {
       // randnum = 1;
	}
	void rand()
    {
        randnum = Random.Range(0, 4);
    }

	// Update is called once per frame
	void Update () {
        //cd--;
        transform.localScale = new Vector3(enemybasehealth / 5, enemybasehealth / 5, enemybasehealth / 5);
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("bullet")) || (other.gameObject.CompareTag("bulletknockback")))
        {
            enemybasehealth--;
            Destroy(other.gameObject);
            //if (enemybasehealth <= 50)
            {
                //gameObject.tag = "Player";
            }
        }
        if (other.gameObject.CompareTag("enbullet"))
        {
            enemybasehealth++;
            Destroy(other.gameObject);
            if (enemybasehealth >= 100)
            {
                gameObject.tag = "enemybase";
            }
        }
    }
}
