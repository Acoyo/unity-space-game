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
    public static int audiochain;
    public int audiochaincopy;
    static public Vector3 mousesave;
    public GameObject object2;
    public GameObject cursorback;
    public GameObject player;
    

    static public Transform mouseposobj;

   static  public Transform mousepos;
	// Use this for initialization
	void Start () {
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            //SceneManager.LoadScene("Scene_Name");
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
          
            SceneManager.LoadScene(0);
        }
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
