using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    [SerializeField] Text countText;

    [SerializeField] AudioSource collectAudio;

    private int countBubble = 0;
    private int requiredBubbles = 5;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "collectable")
        {
            collectAudio.Play();
            countBubble++;
            countText.text = "Bubble: " + countBubble.ToString();
            Destroy(other.gameObject);

        }
    }


    public int GetBubbleCount()
    {
        return countBubble;
    }
}
