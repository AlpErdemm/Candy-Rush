using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    private bool isMoving;
    private float runSpeed = 0.1f;
    private float sideSpeed = 0.01f;
    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isMoving = false;
            GetComponent<Animator>().SetBool("Crash", true);
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            isMoving = false;
            GetComponent<Animator>().SetBool("Victory", true);
        }
    }

    public void startRunning()
    {
        isMoving = true;
        GetComponent<Animator>().SetBool("Running", true);
    }
}
