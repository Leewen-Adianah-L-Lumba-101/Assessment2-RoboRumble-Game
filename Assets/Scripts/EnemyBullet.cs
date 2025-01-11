using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // To get the player reference and Rigidbody2D 
    // parameters of the bullet prefab.
    private GameObject player;
    private Rigidbody2D rb;
                           
    public float force;      // force is for how fast the bullet will go
    private float timer;    // timer for making sure bullets dissapear after specified time

    // Start is called before the first frame update
    void Start()
    {
        // At the start of the scene, values are assigned to the variables
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        // The direction of the player is referenced and will create the movement for the bullets
        // It will shoot after the player's last known position
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Make sure bullets are destroyed after some time
        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }

    // When bullets collide with the Player, it will be destroyed
    // and the health of the player is subtracted by 2
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Health>().health -= 2;
            SoundManager.instance.PlayHurtSfx();
/*            Debug.Log("Collision with player");*/
        }

        if(other.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }
}
