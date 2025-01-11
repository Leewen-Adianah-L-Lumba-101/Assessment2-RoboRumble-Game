using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    // Variables to know what to spawn, where to spawn it from, what animations will play and
    // whether or not enemy GameObject has died
    public GameObject bullet;
    public Transform firepoint;
    public Animator anim;
    public bool isDead = false;

    // Variables to keep track of time, player position and enemy's health
    private float timer;
    private GameObject player;
    private int enemyhealth;

    // Scripts to reference for their classes and functions
    public GameManager gamemanager;
    public Health healthscript;

    // Start is called before the first frame update

    void Awake()
    {
        anim.ResetTrigger("isBroken");
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gamemanager.OpponentHasAppeared();
    }

    // Update is called once per frame
    void Update()
    {
        enemyhealth = healthscript.health;

        //  When enemy health is zero it will stop shooting and play the broken animation
        if (enemyhealth <= 0 && !isDead)
        {
            isDead = true;
            anim.SetTrigger("isBroken");
            gamemanager.OpponentHasDied();
        }

        timer += Time.deltaTime;

        // Every 3 seconds, while the enemy shooter is not dead, a bullet will come out
        // of it's firepoint and an animation will play. The timer is also reset to make sure
        // the bullet spawning is every 3 seconds.
        if (timer > 2 && isDead == false)
        {
            timer = 0;
            anim.SetTrigger("isShooting");
            Shoot();
        }
    }

    // When the function is run, creates a new bullet prefab
    void Shoot()
    {
        // This will create a bullet (GameObject) that will fire from the firepoint 
        Instantiate(bullet, firepoint.position, Quaternion.identity);
        SoundManager.instance.PlayShootSfx();
    }

    // Failed attempts to create supplementary mechanics
/*    void OnTriggerEnter2D(Collider2D other)
    {
        if ((enemyhealth == 0) && !isDead)
        {
            isDead = true;
            // Let the gamemanager know an opponent has died

        }
    }*/

/*    // When player enters the range of the enemy shooter
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(other.GetComponent<Health>() != null)
            {

            }
        }
    }*/
}
