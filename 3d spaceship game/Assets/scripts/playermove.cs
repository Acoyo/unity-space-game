using UnityEngine;
using System.Collections;

public class playermove : MonoBehaviour
{
    public Transform target;
    public GameObject target2;
    public GameObject player;
    public float speed;
    static public int randcheck;
    private Rigidbody rb;
    public GameObject childObj;
    public GameObject childObj2;
    public GameObject aggrosphere;
    public int playerhealth;


    void Start()
    {
       // defenderhealth = GetComponent<lookatplayer>().shiphealthenemy;
       // GetComponent<lookatplayer>().shiphealthenemy = defenderhealth;
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("aaaaaa");                          /// find player by NAME
        Destroy(aggrosphere.gameObject);
        //gameObject.name = "currentship";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
    public void Jumpback()
    {
        childObj2 = GameObject.FindWithTag("HeroicUnitTemp");
        //Destroy(gameObject);
        GetComponent<playerlookatmouse>().enabled = false;
        GetComponent<playermove>().enabled = false;
        //GetComponent<deflookatenemy>().defenderhealth = defenderhealth;
        GetComponent<lookatplayer>().enabled = false;
        GetComponentInChildren<spawnbulletenemy>().enabled = false;
        GetComponentInChildren<spawnbullet>().enabled = false;
        // gameObject.tag = "defender";
        //  player.gameObject.tag = "Player";
        childObj.gameObject.tag = "Untagged";
        childObj2.gameObject.tag = "HeroicUnit";
        //other.gameObject.SetActive(false);
        //childObj.gameObject.SetActive(true);
        player.GetComponent<playerlookatmouse>().enabled = true;
        player.GetComponent<playermove>().enabled = true;
        //other.gameObject.SetActive(false);
        player.GetComponentInChildren<spawnbullet>().enabled = true;
        GetComponentInChildren<spawnbulletdefender>().enabled = true;
        GetComponentInChildren<spawnbulletdefender>().defbullet = GetComponentInChildren<spawnbullet>().currentbullet;
        GetComponent<deflookatenemy>().enabled = true;
        gameObject.name = "namelessone";
        //GetComponent<deflookatenemy>().speed = 0f;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && (gameObject.name != "aaaaaa"))
        {

            Jumpback();
        }
        if (Input.GetKeyDown(KeyCode.O) && (gameObject.name != "aaaaaa"))

        {
            GetComponent<deflookatenemy>().followenemy = false;
        }
        if (Input.GetKeyDown(KeyCode.P) && (gameObject.name != "aaaaaa"))

        {
            GetComponent<deflookatenemy>().followenemy = true;
        }
        if (Input.GetKeyDown(KeyCode.L) && (gameObject.name != "aaaaaa"))

        {
            GetComponent<deflookatenemy>().followplayer = true;
        }
        if (Input.GetKeyDown(KeyCode.K) && (gameObject.name != "aaaaaa"))

        {
            GetComponent<deflookatenemy>().followplayer = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (player == gameObject)                       // if (player named: aaaaaa == this gameobject)
        {

            if (other.gameObject.CompareTag("enbullet"))
            {
                playerhealth--;
                Destroy(other.gameObject);
            }
        }
    }
}