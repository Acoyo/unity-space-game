using UnityEngine;
using System.Collections;

public class movetowards : MonoBehaviour
{
    public Transform target;
    public float speed=1;
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}