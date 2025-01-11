using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Creating private variables
    private GameObject attackArea = default;
    private bool attacking = false;
    private float timeToAttack = 0.5f;
    private float timer = 0f;

    // To call animation triggers for the player
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // Get the first index of the parent gameObject that the script is attached to
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // GetKeyDown() detects a single press of the Space key, when pressed the 'Attack()' function is called
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        timer += Time.deltaTime;

        // After two seconds, the icon sprite that showcases the state of the player is returned to normal
        if(timer > 2f)
        {
            HealthUpdater.instance2.ChangeSpriteNormal();
        }

        // If attacking is true, the timer will also increment
        if (attacking)
        {
            timer += Time.deltaTime;

            // However if the timer is greater or equal to the time of attacking it resets the timer.
            // This is basically to ensure that the player can only attack every .5 seconds.
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                // The attack area GameObject (attached to this GameObject) is activated
                attackArea.SetActive(attacking);

            }
        }
    }

    // Function for Attack. Runs the punching animation for character, also makes sure to play the sound effect.
    private void Attack()
    { 
        attacking = true;
        attackArea.SetActive(attacking);
        anim.SetTrigger("isPunching");
        HealthUpdater.instance2.ChangeSpriteConfident();
        SoundManager.instance.PlayPunchSfx();
    }
}
