using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthUpdater : MonoBehaviour
{

    // Displays
    public GameObject[] healthicons;    // List to keep track of all hearts
    public GameObject evesprite;        // Purely visual stuff
    public Sprite confidentstate;
    public Sprite hurtstate;
    public Sprite normalstate;

    // Variables for comparing
    private GameObject player;
    private int currenthealth;

    // For referencing HealthUpdater in other C# scripts
    public static HealthUpdater instance2;

    public void Awake()
    {
        // Check if the class instance is empty, to prevent adding to cache
        if (instance2 == null)
        {
            instance2 = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    { 
        // Health reference, makes sure always check whether or not heart display is accurate
        // to the player's current health
        int referencehealth = 0;
        currenthealth = player.GetComponent<Health>().health;

        RestartLevel();

        // For loop to iterate inside hearts stored within the assigned GameObject
        foreach (GameObject icon in healthicons)
        {
            referencehealth = referencehealth + 25;

            // if the currenthealth of the player is greater than the value of the icon's health
            // turn respective icon on
            if (currenthealth >= referencehealth)
            {
                icon.SetActive(true);
            }

            // if less than the value, the respective icon is off
            else
            {
                icon.SetActive(false);
            }
        }
        
        // Warning state that showcases the health of the player
        if (currenthealth <= 25)
        {
            ChangeSpriteHurt();
        }
    }

    // Level restarts when the player health is equal to or less than 0
    public void RestartLevel()
    {
        if(currenthealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Functions to change the states of the player, a separate UI display for added visuals only
    public void ChangeSpriteHurt()
    {
        // getting Image component of the icon/Eve sprite then changing the sprite 
        evesprite.GetComponent<Image>().sprite = hurtstate;
    }

    public void ChangeSpriteConfident()
    {
        evesprite.GetComponent<Image>().sprite = confidentstate;
    }

    public void ChangeSpriteNormal()
    {
        evesprite.GetComponent<Image>().sprite = normalstate;
    }
}
