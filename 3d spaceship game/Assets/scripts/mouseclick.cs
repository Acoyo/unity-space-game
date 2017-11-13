using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseclick : MonoBehaviour {
    static public bool bulletoff = false;
    static public bool plantcursor = false;
    static public bool firstclick = true;
    static public bool bulletfollow = true;
    static public bool bulletteleport = false;
    static public Vector3 mousesave;
    public GameObject object2;
    public GameObject cursorback;
    public GameObject player;

    static public Transform mouseposobj;

   static  public Transform mousepos;
	// Use this for initialization
	void Start () {
        plantcursor = false;
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
    // Update is called once per frame
    void Update () {
		
	}
}
