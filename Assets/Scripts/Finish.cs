using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] AudioSource winAudio;
    [SerializeField] Text levelMessageText; // Reference to the message text
    private Collector collector; // Reference to the Collector script

    private void Start()
    {
        collector = GameObject.FindObjectOfType<Collector>();
        levelMessageText.text = "Collect all bubbles"; // Set initial message
    }

    private void Update()
    {
        if (collector.GetBubbleCount() >= 1)
        {
            levelMessageText.text = "Go to Flag"; // Change message when enough bubbles are collected
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (collector.GetBubbleCount() >= 1) // Check if the required bubbles are collected
            {
                winAudio.Play();
                levelMessageText.text = "Level Cleared"; // Set message to "Level Cleared"
                Debug.Log("Level Cleared"); // Debug log for checking if this line is executed
                Invoke("NextLevel", 1.25f);
            }
            else
            {
                Debug.Log("Not enough bubbles collected!"); // Debug log for checking if not enough bubbles
            }
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
