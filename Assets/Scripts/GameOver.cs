using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameOver : MonoBehaviour
{
    public PlayerHealth playerHealth;
    Animator anim;
    public GameObject GameOverUI;

    private void Awake()
    {
        
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
        if (playerHealth.health <= 0)
        {
            anim.SetTrigger("GameOver");
            GameOverUI.SetActive(true);
        }
  

    }

}
