using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectUIScript : MonoBehaviour
{
    public Vector3 ActivatedPosition;
    Vector3 StartPos;
    bool activated;
    bool moving;
    Vector3 TargetPos;
    public float speed;
    void Start()
    {
        StartPos = transform.position;
        TargetPos = transform.position;
        activated = false;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.position = Vector3.Lerp(transform.position, TargetPos, speed * Time.fixedDeltaTime);
            if (Vector3.Distance(transform.position, TargetPos) < 0.1f)
            {
                moving = false;
            }
        }   
    }
    public void Activate(bool active)
    {
        if(active != activated)
        {
            moving = true;
            activated = active;
            if (active)
            {
                TargetPos = new Vector3(transform.position.x, -200f, transform.position.z);
            }
            else
            {
                TargetPos = StartPos;
            }
        }
    }
}
