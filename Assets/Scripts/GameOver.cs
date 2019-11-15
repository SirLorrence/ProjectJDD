using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameOver : MonoBehaviour
{
    public float restartDelay = 5f;
    public PlayerHealth playerHealth;
    Animator anim;
    float restartTimer;
    //public GameObject GameOverUI; work on bottons later


    private void Awake()
    {
        
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
        if (playerHealth.health <= 0)
        {
            anim.SetTrigger("GameOver");
            // GameOverUI.SetActive(true);
          
            // .. increment a timer to count up to restarting.
            restartTimer += Time.deltaTime;

            // .. if it reaches the restart delay...
            if (restartTimer >= restartDelay)
            {
                // .. then reload the currently loaded level.
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
  

    }

}
