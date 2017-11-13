using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawncursor : MonoBehaviour {
    public GameObject cursorback;
    public GameObject cursorparentloc;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((mouseclick.plantcursor == true)&&(mouseclick.bulletfollow==true))
            Instantiate(cursorback, new Vector3(cursorparentloc.transform.position.x, cursorparentloc.transform.position.y, cursorparentloc.transform.position.z), Quaternion.identity);
        mouseclick.plantcursor = false;
    }
}

