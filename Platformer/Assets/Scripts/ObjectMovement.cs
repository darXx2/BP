using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypoint = 0;

    [SerializeField] private float platformSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position) < 0.1f)
        {
            currentWaypoint++;
            if(currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * platformSpeed);
    }
}
