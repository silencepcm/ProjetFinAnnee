using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Game;

public class Tronc : Damageable
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
        if (coll.CompareTag("Munition"))
        {
            anim.SetBool("start", true);
        }
    }
    public override void InflictDamage(float damage, bool isExplosionDamage, GameObject damageSource)
    {
        anim.SetBool("start", true);
    }
}
