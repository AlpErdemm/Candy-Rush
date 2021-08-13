using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{

    private float fallLimit = -0.3f;
    private bool isMoving = false;
    private float runSpeed = 0.1f;
    private float sideSpeed = 0.01f;



    /*private void Update()
    {
        if (transform.position.y <= fallLimit)
        {
            GetComponent<Animator>().SetBool("Fall", true);
        }
    }
    */
    void FixedUpdate()
    {
        if (isMoving)
        {
            transform.Translate(new Vector3(0, 0, runSpeed));
        }
    }
    public void moveLeft()
    {
        if (isMoving)
        {
            transform.Translate(new Vector3(-sideSpeed, 0, 0));
        }
    }

    public void moveRight()
    {
        if (isMoving)
        {
            transform.Translate(new Vector3(sideSpeed, 0, 0));
        }
    }

    public void startRunning()
    {
        isMoving = true;
        GetComponent<Animator>().SetBool("Running", true);
    }
}
