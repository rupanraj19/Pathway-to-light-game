using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class vidplayer : MonoBehaviour
{

    [SerializeField] string VideoFileName;


    // Start is called before the first frame update
    void Start()
    {
        PlayVideo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayVideo()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer) 
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, VideoFileName);
            Debug.Log(videoPath);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
        }
    }
}