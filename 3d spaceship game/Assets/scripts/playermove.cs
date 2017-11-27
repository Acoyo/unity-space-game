using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playermove : MonoBehaviour
{
    public Transform target;
    public GameObject target2;
    public GameObject player;
    public GameObject home;
    public GameObject destination;
    public Transform destinationtrans;
    public Transform cursor;
    public float speed;
    static public int randcheck;
    private Rigidbody rb;
    public GameObject childObj;
    public GameObject childObj2;
    public GameObject aggrosphere;
    public int playerhealth;
    public float distance;
    public bool isrevealed = false;
    public int cd=100;
    public bool scriptenabled;
    public int i;

    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public RawImage damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    //public AudioClip deathClip;                                 // The audio clip to play when the player dies.
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public Color healcolor = new Color(0, 1f, 0, 0.1f);
    public bool justbeenhit = false;

    void Start()
    {
        cursor = GameObject.FindWithTag("follow").transform;
        // defenderhealth = GetComponent<lookatplayer>().shiphealthenemy;
        // GetComponent<lookatplayer>().shiphealthenemy = defenderhealth;
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("aaaaaa");                          /// find player by NAME
       // Destroy(aggrosphere.gameObject);
        //gameObject.name = "currentship";
        distance = GetComponent<playerlookatmouse>().distance;
        isrevealed = false;
        scriptenabled = true;
        //mouseclick.grouphealthplayer += GetComponent<shipstats>().shiphealth;
    }
    private void OnEnable()
    {
        scriptenabled = true;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        mouseclick.grouphealthplayer -= GetComponent<shipstats>().shiphealth;
        if (mouseclick.grouphealthplayer < 0)
        {
            mouseclick.grouphealthplayer = 0;
        }
    }
    private void OnDisable()
    {
        scriptenabled = false;
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        if (isrevealed == true)
        {
            
            cd--;
            if (cd <= 0)
            {
                mouseclick.grouphealthplayer -= GetComponent<shipstats>().shiphealth;
                isrevealed = false;
                //cd = 100;
            }
        }
        if (justbeenhit == true)
        {
            damageImage.color = Color.Lerp(damageImage.color, new Color(0f, 1f, 0f, 0.0f), flashSpeed * Time.deltaTime);
           
            i--;
            if (i < 0)
            {
                //damageImage.color = Color.Lerp(damageImage.color, new Color(0f, 1f, 0f, 0.0f), flashSpeed * Time.deltaTime);
                healthSlider.value = GetComponent<shipstats>().shiphealth;
                justbeenhit = false;
            }
        }
     //if (isrevealed == false)
     //   {
     //       mouseclick.grouphealth = 0;
     //   }
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
        player.tag = "Player";
        gameObject.name = "namelessone";
        //GetComponent<deflookatenemy>().speed = 0f;
    }
    private void Update()
    {
        
        if (scriptenabled == true)
        {
             //cursor = GameObject.FindWithTag("follow)").transform.position;
            //mouseclick.grouphealthplayer = playerhealth;
            distance = GetComponent<playerlookatmouse>().distance;
            aggrosphere.transform.localScale = new Vector3(distance / 2, 0, distance / 2);

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
            if (Input.GetKeyDown(KeyCode.Space) && (gameObject.tag == "Player")&& (isrevealed == false))                                  ///teleport
            {
                transform.position = new Vector3(cursor.transform.position.x, cursor.transform.position.y - 3, cursor.transform.position.z);
            }

            if (Input.GetKeyDown(KeyCode.Home) && (gameObject.tag == "Player") && (isrevealed == false))

            {
               transform.position = new Vector3(home.transform.position.x, home.transform.position.y, home.transform.position.z + 5);
            }
            if (Input.GetKeyDown(KeyCode.Insert) && (gameObject.name == "aaaaaa"))

            {
                Instantiate(destination, new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 5), transform.rotation);
            }
            if (Input.GetKeyDown(KeyCode.End) && (gameObject.tag == "Player") && (isrevealed == false))

            {
                destinationtrans = GameObject.Find("Destination(Clone)").transform;
                transform.position = new Vector3(destinationtrans.transform.position.x, destinationtrans.transform.position.y-2, destinationtrans.transform.position.z - 5);

            }
            if (Input.GetKeyDown(KeyCode.PageDown) && (gameObject.tag == "Player") && (isrevealed == false))

            {
                //Vector3 cursor = GameObject.Find("Capsule)").transform.position;
                transform.position = new Vector3(cursor.transform.position.x, cursor.transform.position.y - 3, cursor.transform.position.z);

            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("enemybasehealing"))
        {

            //damageImage.color = healcolor;
            //justbeenhit = true;
            //GetComponent<shipstats>().shiphealth = 12;

        }
    }

        void OnTriggerEnter(Collider other)
    {
        if (player == gameObject)                       // if (player named: aaaaaa == this gameobject)
        {

            if (other.gameObject.CompareTag("enbullet"))
            {
                justbeenhit = true;
                damageImage.color = flashColour;
                i = 30;
                //playerhealth--;
                //Destroy(other.gameObject);
                AudioSource destroyed = GetComponent<AudioSource>();
                 GetComponent<shipstats>().shiphealth--;
                 mouseclick.grouphealthplayer--;
                damageImage.color = flashColour;
                destroyed.Play();
            }
            if (other.gameObject.CompareTag("enemybasehealing"))
            {
                
                damageImage.color = healcolor;
                i = 50;
                justbeenhit = true;
                GetComponent<shipstats>().shiphealth=12;
                //mouseclick.grouphealthplayer = 12;


            }
        }
        if ((other.gameObject.CompareTag("detectionbullet"))&&(gameObject.tag !="enemy"))
        {
            if (isrevealed == false)
            {
                mouseclick.grouphealthplayer += GetComponent<shipstats>().shiphealth;
            }
            isrevealed = true;
            cd = 100;
        }
        }
}