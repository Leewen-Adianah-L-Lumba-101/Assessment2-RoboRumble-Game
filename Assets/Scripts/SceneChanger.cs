using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;


public class SceneChanger : MonoBehaviour
{
    // changeTime is the length of the cutscene to switch away from
    // sceneName is the scene the cutscene will go to after ending
    public float changeTime;
    public string sceneName;

    // Update is called once per frame
    private void Update()
    {
        changeTime -= Time.deltaTime;

        // By the the end of the cutscene the specified scene will show up
        // therefore it doesn't matter whether the user will skip or not,
        // the cutscene will start Level 1 once it ends.
        if(changeTime <= 0)
        {
            SceneManager.LoadScene(sceneName);
        }

        // If the user wants to skip, the S will load the subsequent scene also
        if (Input.GetKeyDown(KeyCode.S))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
