using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public int damagePerShot = 10;
    public float timeBetweenBullets = .15f;
    public float range = 100f;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    PauseMenu pauseMenu;
    // References

    LineRenderer gunLine;
    float effectsDisplayTime = 0.2f;

    // Start is called before the first frame update
    void Awake()
    {
        gunLine = GetComponent<LineRenderer>();
        shootableMask = LayerMask.GetMask("Shootable");
        pauseMenu = GetComponent<PauseMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1")  && timer >= timeBetweenBullets)
        {
            shoot();
        }
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            // ... disable the effects.
            DisableEffects();
        }

    }
    public void DisableEffects()
    {
        // Disable the line renderer and the light.
        gunLine.enabled = false;
    }
    void shoot()
    {
        timer = 0f;

        // Enable the line renderer and set it's first position to be the end of the gun.
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            EnemyHealth enemyHeath = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHeath != null)
            {
                enemyHeath.TakeDamage(damagePerShot);
            }

            // Set the second position of the line renderer to the point the raycast hit.
            gunLine.SetPosition(1, shootHit.point);
        }
        // If the raycast didn't hit anything on the shootable layer...
        else
        {
            // ... set the second position of the line renderer to the fullest extent of the gun's range.
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
