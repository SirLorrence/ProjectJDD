using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectController : MonoBehaviour
{
    public PlayerMovement thePlayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1)|| Input.GetMouseButton(2)) 
        {
            thePlayer.useController = false;
        }

        if (Input.GetAxisRaw("Mouse X") !=0.0f || Input.GetAxisRaw("Mouse Y") !=0.0f)
        {
            thePlayer.useController = false;
        }
        if (Input.GetAxisRaw("RHorizontal") != 0.0f || Input.GetAxisRaw("RVertical") != 0.0f)
        {
            thePlayer.useController = true;
        }
    }
}
