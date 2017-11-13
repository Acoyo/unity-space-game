using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipstats : MonoBehaviour {
    public int shiphealth=4;
    public int shiphealthdisplay;
    public int shiphealthdisplay2;
    public int shiphealthdisplay3;
    public int attackspeed;

    public GameObject healthbar;
    public GameObject healthbar2;
    public GameObject healthbar3;

    // Use this for initialization
    void Start () {
        //healthbar.transform.localScale = new Vector3(4, 1, 1);
    }
	
	// Update is called once per frame
	void Update () {
        shiphealthdisplay = shiphealth;
        shiphealthdisplay2 = shiphealth;
        shiphealthdisplay3 = shiphealth;

        if (shiphealth <= 0)
        {
            shiphealthdisplay = 0;
        }
        if (shiphealth >= 5)
        {
            shiphealthdisplay = 4;
        }
        if (shiphealth <= 4)
        {
            shiphealthdisplay2 = 4;
        }
        if (shiphealth >= 9)
        {
            shiphealthdisplay2 = 8;
        }
        if (shiphealth <= 8)
        {
            shiphealthdisplay3 = 8;
        }
        if (shiphealth >= 13)
        {
            shiphealthdisplay3 = 12;
        }



        healthbar.transform.localScale = new Vector3(shiphealthdisplay, .3f, 1);
        healthbar2.transform.localScale = new Vector3(shiphealthdisplay2 - 4, .3f, .8f);
        healthbar3.transform.localScale = new Vector3(shiphealthdisplay3 - 8, .3f, .6f);

    }
}
