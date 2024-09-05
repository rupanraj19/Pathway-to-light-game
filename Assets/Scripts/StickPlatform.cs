using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player")
        {
            other.transform.SetParent(this.transform); // move our player object as a child object of moving platform
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            other.transform.SetParent(null);
        }
    }
}
