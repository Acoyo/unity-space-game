using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnenemy : MonoBehaviour {
    public GameObject enemy;
    public GameObject target;
    public int countdown;
    public int respawnrate = 400;
    public int speed = 2;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        countdown--;
        if (countdown <= 0)
        {
            spawnenemyprefab();
            countdown = respawnrate;
        }
	}
    private void FixedUpdate()
    {
        transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime * speed);
    }
    void spawnenemyprefab()
    {
        if (mouseclick.amountofenemies <= 20)
        {
            Instantiate(enemy, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            mouseclick.amountofenemies += 1;
        }
    }
}
