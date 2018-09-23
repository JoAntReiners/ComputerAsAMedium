using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public float speed = 5f;
    public Transform pointA;
    public Transform pointB;
    private Transform temp;

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
        if (transform.position == pointB.position)
        {
            temp = pointB;
            pointB = pointA;
            pointA = temp;
        }
    }
}
