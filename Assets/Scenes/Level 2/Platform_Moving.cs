using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Moving : MonoBehaviour
{
 
    public Vector3[] points;
    public int point_number = 0;
    private Vector3 current_target;
 
    public float tolerance;
    public float speed;
    public float delay_time;
 
    private float delay_start;
 
    public bool automatic;
 
 
    // Start is called before the first frame update
    void Start()
    {
        if(points.Length > 0)
        {
            current_target = points[0];
        }
        tolerance = speed * Time.deltaTime;
    }
 
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != current_target)
        {
            MovePlatform();
        }
        else
        {
            UpdateTarget();
        }
 
    }
 
    void MovePlatform()
    {
        Vector3 heading = current_target - transform.position;
        transform.position += (heading / heading.magnitude) * speed * Time.deltaTime;
        if(heading.magnitude < tolerance)
        {
            transform.position = current_target;
            delay_start = Time.time;
        }
    }
    void UpdateTarget()
    {
        if (automatic)
        {
            if(Time.time - delay_start > delay_time)
            {
                NextPlatform();
            }
        }
    }
    public void NextPlatform()
    {
        point_number++;
        if(point_number >= points.Length)
        {
            point_number = 0;
        }
        current_target = points[point_number];
    }
 
    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
 