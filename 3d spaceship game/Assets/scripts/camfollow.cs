using UnityEngine;
using System.Collections;

public class camfollow : MonoBehaviour
{

    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    static public GameObject target2;
    static public GameObject target3;
    // Update is called once per frame
    void FixedUpdate()
    {

        target2 = GameObject.FindWithTag("HeroicUnit");
        
        target = target2.transform;
        if (target)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
    static public void retargetplayer()
    {
        target3 = GameObject.FindWithTag("HeroicUnit");
        //target2 = target3;
    }
}