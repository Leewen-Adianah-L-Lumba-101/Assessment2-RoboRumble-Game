using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    // This is the defeault damage done by the player or character to enemies
    private int damage = 3;

    // When gameObject that has the Health script component enters the attack area range
    // it will damage the gameObject's health
    private void OnTriggerEnter2D(Collider2D collider)
    {   
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
            SoundManager.instance.PlayObjectHitSfx(); // gives off impression any object that is hit will play a sound
        }
    }

}
