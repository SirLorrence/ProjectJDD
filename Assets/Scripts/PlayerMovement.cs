using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    float camRayLength = 100f;
    public bool useController;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;




    private void Awake()
    {
        //get the references
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turning();
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }
    void Turning()
    {
        //rotation with mouse
        if (!useController)
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit floorHit;

            if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
            {
                Vector3 playertoMouse = floorHit.point - transform.position;
                playertoMouse.y = 0f;

                // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
                Quaternion newRotation = Quaternion.LookRotation(playertoMouse);

                // Set the player's rotation to this new rotation.
                playerRigidbody.MoveRotation(newRotation);
            }
        }

        //rotation with controller
        if (useController)
        {

            //xbox right stick
            Vector3 PlayerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal") + Vector3.forward * -Input.GetAxisRaw("RVertical");
            if (PlayerDirection.sqrMagnitude> 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(PlayerDirection, Vector3.up);
            }
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }

}
