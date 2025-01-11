using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Health : MonoBehaviour
{
    // Health variable for the player and enemies
    [SerializeField] public int health = 100;

    void Start()
    {
        // Any tag with the Enemy will be given only 12 hp
        if (CompareTag("Enemy"))
        {
            health = 12;
        }
    }

    // Damage system, subtracts from the GameObject's health
    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Negative damage is IMPOSSIBLE!");
        }

        this.health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }
    
    // Call in the Unity Console to signal GameObject has died
    private void Die()
    {
        Debug.Log("Item Died");
    }

    // To make a function that returns private variables in a script into public values, when called:
    /*
     * public int getVariable()
     * {
     *      return privatevariablename;
     * }
     */
}

