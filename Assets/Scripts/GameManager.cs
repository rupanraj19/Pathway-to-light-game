using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer
    public bool hasCutscene = true; // Boolean to check if there's a cutscene

    private void Start()
    {
        if (hasCutscene && videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd; // Add listener for when the video finishes
        }
        else
        {
            // If no cutscene, move to the next level directly
            PlayGame();
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        PlayGame(); // Call the PlayGame function when the video ends
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
