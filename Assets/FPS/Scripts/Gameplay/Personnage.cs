using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personnage : MonoBehaviour
{
    public float Vie { get; set; }
    public float MaxVie { get; set; }
    public bool alive;


    void Update()
    {
        
    }


    public void Heal(float healAmount)
    {
        float healthBefore = Vie;
        Vie += healAmount;
        Vie = Mathf.Clamp(Vie, 0f, Vie);
    }

    public void TakeDamage(float damage, GameObject damageSource)
    {
        float healthBefore = Vie;
        Vie -= damage;
        Vie = Mathf.Clamp(Vie, 0f, Vie);

        if (Vie == 0f)
        {
            HandleDeath();
        }
    }

    public void Kill()
    {
        Vie = 0f;

        HandleDeath();
    }

    void HandleDeath()
    {
        if (!alive)
            return;

        // call OnDie action
        if (Vie <= 0f)
        {
            alive = false;
        }
    }
}
