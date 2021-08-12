using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    private bool isGameStarted = false;
    private bool isMoving;
    private float runSpeed = 0.1f;
    private float sideSpeed = 0.01f;
    void Start()
    {
        isMoving = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            transform.Translate(new Vector3(0, 0, runSpeed));
        }
    }

    public bool getGameStarted()
    {
        return isGameStarted;
    }
    public void setGameStarted(bool _isGameStarted)
    {
        isGameStarted = _isGameStarted;
    }

    public void moveLeft()
    {
        transform.Translate(new Vector3(-sideSpeed, 0, 0));
    }

    public void moveRight()
    {
        transform.Translate(new Vector3(sideSpeed, 0, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isMoving = false;
            GetComponent<Animator>().SetBool("Crash", true);
        }
    }
}
