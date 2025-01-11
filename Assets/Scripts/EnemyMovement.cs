using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // SerializeField makes the variables accessible in the unity to change variables.
    // However they are still considered private, and are only accessible to the attached GameObject
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float speed = 1.5f;
    [SerializeField]
    private EnemyData data;

    // Private Variables for finding and comparing player and enemy data
    // enemydead is to check whether or not certain code can be ran
    private GameObject player;
    private int enemyhealth;
    private bool enemydead = false;

    // Public variables to reference other scripts with important classes
    public GameManager gamemanager;
    public Health healthscript;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // Everytime the game is start, the player GameObject is referenced
        // And each enemy this script is attached to will be counted in a variable called
        // 'opponentsLeft' in the GameManager script.
        player = GameObject.FindGameObjectWithTag("Player");
        gamemanager.OpponentHasAppeared();
    }

    // Update is called once per frame
    void Update()
    {
        enemyhealth = healthscript.health;

        // If enemy is dead, update how many are left and play death animations etc..
        if (enemyhealth <= 0 && !enemydead)
        {
            enemydead = true;
            anim.SetTrigger("enemyDead");
            gamemanager.OpponentHasDied();
            Destroy(gameObject, .5f);
        }

        // If enemy is not dead, continue following player.
        if (enemydead == false)
        {
            Swarm();
        }
    }

    // Updates the transform properties of the enemy GameObject by following the transform properties of the player GameObject
    // At a set speed, this makes it seem like the enemy is swarming/following the player.
    private void Swarm()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    // When enemy collides with a GameObject with the Player tag, it will start damaging it
    // Plays subsequent sound effects and calls the damage function
    private void OnTriggerEnter2D(Collider2D collider)
    {
       if (collider.CompareTag("Player"))
        {
            anim.SetTrigger("isAttacking");
            if (collider.GetComponent<Health>() != null)
            {
                collider.GetComponent<Health>().Damage(damage);
                SoundManager.instance.PlayHurtSfx();
            }
        }
    }
}
