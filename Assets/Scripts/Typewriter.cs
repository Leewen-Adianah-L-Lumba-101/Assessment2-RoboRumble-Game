using System.Collections;
using UnityEngine;
using TMPro;

public class Typwriter : MonoBehaviour
{
    // Variables for creating references
    public AudioSource audioSource;     // The sound manager object
    public TMP_Text textMeshPro;        // For the text that's to be animated
    public float typingSpeed = 0.1f;    // The speed in which the text is animated
    public AudioClip type;              // The sound that will play when the text is animated

    private string fullText;            // For iteration

    private void Start()
    {
        fullText = textMeshPro.text;     // Store the contents of text by making a copy
        textMeshPro.text = string.Empty; // Clear the text in Unity to start animation
        StartCoroutine(TypeText());     
    }

    // Function that will run when program starts, the text is given the 
    IEnumerator TypeText()
    {
        foreach (char letter in fullText)
        {
            textMeshPro.text += letter;                    // Append each letter to the text in Unity
            yield return new WaitForSeconds(typingSpeed); // Wait for the specified time
            PlayTypeSfx();
        }
    }

    // For sound effect to play
    public void PlayTypeSfx()
    {
        audioSource.PlayOneShot(type);
    }
}