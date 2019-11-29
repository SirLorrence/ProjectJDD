using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;            // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
 public int scoreValue = 10;                 // The amount added to the player's score when the enemy dies.


    Animator anim;                              // Reference to the animator.
    CapsuleCollider capsuleCollider;            // Reference to the capsule collider.
    bool isDead;                                // Whether the enemy is dead.
    EnemyMovement enemyMovement;
    EnemyAttack enemyAttack;
    ParticleSystem hitParticles;
    NavMeshAgent nav;


    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAttack = GetComponent<EnemyAttack>();
        currentHealth = startingHealth;
        hitParticles = GetComponent<ParticleSystem>();
        nav = GetComponent<NavMeshAgent>();
        

    }




    public void TakeDamage(int amount)
    {
        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;


        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;

        hitParticles.Play();


        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
            // ... the enemy is dead.
            Death();
        }
    }


    void Death()
    {
        // The enemy is dead.
        isDead = true;
        ScoreManager.score += scoreValue;
        Destroy(gameObject, 2.5f);
        // Turn the collider into a trigger so shots can pass through it.
        capsuleCollider.isTrigger = true;

        // Tell the animator that the enemy is dead.
        enemyMovement.enabled = false;
        enemyAttack.enabled = false;
        anim.SetTrigger("Dead");
   
    }
}
