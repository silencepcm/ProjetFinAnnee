using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tronc : MonoBehaviour
{
    static Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerStay(Collider coll)
    {
        Debug.Log("bob");
        if (coll.gameObject.tag == "Munition")
        {
            
            anim.SetBool("start", true);
        }
    }
}
