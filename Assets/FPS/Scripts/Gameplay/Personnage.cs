using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personnage : MonoBehaviour
{
    public int Vie { get; set; }
    public int MaxVie { get; set; }
    public bool alive;


    void Update()
    {
        
    }


    public void Heal(int healAmount)
    {
        float healthBefore = Vie;
        Vie += healAmount;
        Vie = Mathf.Clamp(Vie, 0, MaxVie);
    }

    public void TakeDamage(int damage, GameObject damageSource)
    {
        float healthBefore = Vie;
        Vie -= damage;
        Vie = Mathf.Clamp(Vie, 0, Vie);

        if (Vie == 0f)
        {
            HandleDeath();
        }
    }

    public void Kill()
    {
        Vie = 0;

        HandleDeath();
    }

    void HandleDeath()
    {
        if (!alive)
            return;

        // call OnDie action
        if (Vie <= 0)
        {
            alive = false;
        }
    }
}
