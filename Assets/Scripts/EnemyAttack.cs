using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{

    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 1;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyMovement enemymove;
    NavMeshAgent nav;

   
    bool playerInRange;
    float timer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        enemymove = GetComponent<EnemyMovement>();
        nav = GetComponent<NavMeshAgent>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;
            bool attack = true;
            anim.SetBool("isAttack", attack);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
            bool attack = false;
            anim.SetBool("isAttack", attack);
        }
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();
        }
        if (playerHealth.health <= 0)
        {
            //enemymove.enabled = false;
            nav.enabled = false;
            anim.SetTrigger("PlayerDead");
        }

    }
    void Attack()
    {
        timer = 0f;
        if (playerHealth.health > 0)
        {
            playerHealth.DamageTaken(attackDamage);
        }
    }

}
