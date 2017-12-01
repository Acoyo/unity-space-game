using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]
public class mouseclick : MonoBehaviour {
    static public bool bulletoff = false;
    static public bool plantcursor = false;
    static public bool firstclick = true;
    static public bool bulletfollow = true;
    static public bool bulletteleport = false;
    static public int bulletminispin=0;
    static public bool minispinbool=false;
    static public int grouphealth;
    static public bool cursortouchwall = false;
    public bool cursortouchwallshow;
    public int grouphealthshow;
    static public int grouphealthplayer;
    public int grouphealthplayershow;
    public static bool isfalcon = false;

    public static int audiochain;
    public int audiochaincopy;
    static public Vector3 mousesave;
    public GameObject object2;
    public GameObject cursorback;
    public GameObject player;
    public float timeset=1f;
    public static int amountofenemies=0;
    public bool ispaused=false;
    static public Transform waypointposition;
    public Transform waypointpositionShow;
   // public GameObject player;
    

    static public Transform mouseposobj;

   static  public Transform mousepos;
	// Use this for initialization
	void Start () {
        timeset = 1f;
        audiochain = 0;
        audiochaincopy = 0;
        plantcursor = false;
       // AudioSource destroyed = GetComponent<AudioSource>();
        //AudioSource destroy = GetComponent<AudioSource>();
    }
    void OnMouseDown()
    {
        bulletteleport = false;
        bulletoff = true;
        plantcursor = true;
        player.gameObject.tag = "Player";                       //needed??????
       // camfollow.retargetplayer();
        //firstclick = false;
        // Vector3 mousePos = Input.mousePosition;
        // mousepos = followmouse.thispos;
        //mouseposobj.transform.position = mousepos;
        // Instantiate(object2, new Vector3(Input.mousePosition.x/100, Input.mousePosition.y-100, Input.mousePosition.z/100), Quaternion.identity);
        // Instantiate(cursorback, new Vector3(Input.mousePosition.x / 100, Input.mousePosition.y - 100, Input.mousePosition.z / 100), Quaternion.identity);

    }
    void reloadscene()
    {
        mouseclick.amountofenemies = 0;
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        waypointposition = GameObject.FindGameObjectWithTag("waypoint").transform;
        waypointpositionShow = waypointposition;
        Time.timeScale = timeset; ;
        //grouphealthshow = grouphealth;

        if (player.GetComponent<shipstats>().shiphealth <= 0)
        {
            reloadscene();
        }
        if (grouphealth < 0)
        {
            grouphealth = 0;
        }
        if (grouphealthplayer < 0)
        {
            grouphealthplayer = 0;
        }
        grouphealthplayershow = grouphealthplayer;
        grouphealthshow = grouphealth;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            //SceneManager.LoadScene("Scene_Name");
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {

            reloadscene();
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (ispaused == false)
            {
                timeset = 0;
                ispaused = true;
            }
            else if (ispaused == true)
            {
                timeset = 1;
                ispaused = false;
            }
        }
        cursortouchwallshow = cursortouchwall;
    }
    public void playaudio2()
    {
        AudioSource destroy = GetComponent<AudioSource>();
        destroy.Play();
    }

      public void playaudio()
    {
        playaudio2();
    }
    // Update is called once per frame
    
}
