using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Load next scene when user clicks anywhere, this script is for the starting screen
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadSceneAsync("CutsceneStart");
 
        }
    }

    // Failed attempt at trying to make a loading screen

    /*  public Sprite png;
        public Image Comp;


       void Start()
        {
            Comp = gameObject.GetComponent<Image>();
            Comp.sprite = png;
            Comp.enabled = false;

            StartCoroutine(LoadScene());
        }

        IEnumerator LoadScene()
    {
        if (Comp.enabled == true) {
            SceneManager.LoadSceneAsync("Level 1");
            yield return new WaitForSeconds(5f);
        }
        Comp.enabled = false;
    }*/

}
