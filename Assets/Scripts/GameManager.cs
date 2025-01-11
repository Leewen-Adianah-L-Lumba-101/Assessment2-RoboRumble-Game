using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables to check how many opponents are in the scene
    // Index variable to make sure the scene loaded is the next one
    public int opponentsLeft = 0;
    private int index;

    public void Awake()
    {
        // Any scene that is active, the index will be stored in the variable as an integer
        index = SceneManager.GetActiveScene().buildIndex;
    }

    // If opponent has died, subtract from the total number in opponentsLeft
    public void OpponentHasDied()
    {
        opponentsLeft--;
        
        // If the variable is zero, the next scene will load, by incrementing the index by one
        if (opponentsLeft == 0)
        {
            index++;
            SceneManager.LoadScene(index);
        }
    }

    // Add to variable if opponent has appeared
    public void OpponentHasAppeared()
    {
        opponentsLeft++;
    }
}