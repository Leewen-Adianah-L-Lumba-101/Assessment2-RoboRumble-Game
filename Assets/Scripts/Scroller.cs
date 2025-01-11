using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    // Create references available only to the GameObject this script is attached to
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;

    // Update is called once per frame
    void Update()
    {
        // This is for the background image that loops continuously in the start menu of the game
        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
    }
}
