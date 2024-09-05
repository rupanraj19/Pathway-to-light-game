using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    Animator animator;
    [SerializeField] AudioSource deathAudio;
    private void Start()
    {
        animator = GetComponent<Animator>();
        deathAudio = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "trap")
        {
            animator.SetTrigger("death");
            GetComponent<NewBehaviourScript>().enabled = false;
            deathAudio.Play();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
