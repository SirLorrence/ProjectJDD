using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int numOfhearts;

    public Image[] hearts;
    public Sprite heart;
    public Sprite noheart;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    // Reference to an image to flash on the screen on being hurt.
 

    Animator anim;
    PlayerMovement playerMovement;
    bool isDead;
    bool damaged;

     void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>(); // dont forget to add these's
    }

    void Update()
    {
        numOfhearts = health;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i > health)
            {
                hearts[i].sprite = heart;
            }

            if (i < numOfhearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void DamageTaken(int damage)
    {
        damaged = true;

        health -= damage;

        if (health <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {

        isDead = true;
        anim.SetTrigger("Die");
        playerMovement.enabled = false;

    }

}
