using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{

    private float fallLimit = -1.5f;
    private bool isMoving = false;
    private float runSpeed = 0.1f;
    private float sideSpeed;
    private bool isGameOver = false;

    private float destinationX;
    private Vector3 startPosition;

    public bool isFinished = false;
    private void Start()
    {
        startPosition = transform.position;
        sideSpeed = 0f;
        destinationX = 0.0f;
    }

    // If position-y is too low, drop the character
    private void Update()
    {
        if (transform.position.y <= fallLimit && !isGameOver)
        {
            GetComponent<Animator>().SetBool("Fall", true);
            StartCoroutine(restart());
        }
    }
    
    void FixedUpdate()
    {
        if (isMoving)
        {
            if (destinationX > transform.position.x + 0.2f)
                sideSpeed = 0.02f;
            else if (destinationX + 0.2f < transform.position.x)
                sideSpeed = -0.02f;
            else
                sideSpeed = 0f;
            transform.Translate(new Vector3(sideSpeed , 0, runSpeed));
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

    // Moving Obstacle detected ahead
    public void enterMovingObstacle(GameObject obstacle)
    {
        if (obstacle.transform.localPosition.x < -15f)
        {
            destinationX = Random.Range(3f, 10f);
        }
        else if (-15f < obstacle.transform.localPosition.x &&  obstacle.transform.localPosition.x < -11f)
        {
            if(obstacle.GetComponent<MovingObstacle>().isGoingLeft)
                destinationX = Random.Range(0f, 10f);
            else
                destinationX = Random.Range(-10f, -3f);
        }
        else if (-11f < obstacle.transform.localPosition.x && obstacle.transform.localPosition.x < -6f)
        {
            if (obstacle.GetComponent<MovingObstacle>().isGoingLeft)
                destinationX = Random.Range(3f, 10f);
            else
                destinationX = Random.Range(-10f, -3f);
        }
        else
        {
            destinationX = Random.Range(-10f, -3f);
        }
    }

    // Static Obstacle detected ahead
    public void enterStaticObstacle(GameObject obstacle)
    {
        if(obstacle.transform.position.x < 0)
        {
            destinationX = Random.Range(3f, 10f);
        }
        else
        {
            destinationX = Random.Range(-10f, -3f);
        }       
    }

    // Rotating Platform Detected ahead
    public void enterRotatingPlatform(GameObject obstacle)
    {
        if(obstacle.GetComponent<RotatingPlatform>().spinSpeed > 0)
            destinationX = 2.0f;
        else
            destinationX = -2.0f;
    }   

    public void exitMovingObstacle(GameObject obstacle)
    {
        //destinationX = 0.0f;
    }

    public void exitStaticObstacle(GameObject obstacle)
    {
        //destinationX = 0.0f;
    }
    public void exitRotatingPlatform(GameObject obstacle)
    {
        //destinationX = 0.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Obstacle hit, start again
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GetComponent<Animator>().SetBool("Crash", true);
            isMoving = false;
            StartCoroutine(restart());
        }

        // Finish line passed
        if (collision.gameObject.CompareTag("Finish"))
        {
            isMoving = false;
            GetComponent<Animator>().SetBool("Victory", true);
            isFinished = true;
        }
    }

    IEnumerator restart()
    {
        isMoving = false;
        isGameOver = true;
        yield return new WaitForSeconds(2);
        GetComponent<Animator>().SetBool("Crash", false);
        GetComponent<Animator>().SetBool("Running", true);
        GetComponent<Animator>().SetBool("Fall", false);
        GetComponent<Animator>().SetBool("Restart", true);
        isMoving = true;
        transform.position = startPosition;
        isGameOver = false;
        yield return new WaitForSeconds(2);
        GetComponent<Animator>().SetBool("Restart", false);
    }
}
