using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject camera;

    private bool isMoving;
    private float runSpeed = 0.1f;
    private float sideSpeed = 0.01f;
    private float fallLimit = 0.01f;
    private bool isGameOver = false;
    void Start()
    {
        isMoving = false;
    }

    private void Update()
    {
        if(transform.position.y <= fallLimit && !isGameOver)
        {
            Debug.LogError(transform.position.y);
            GetComponent<Animator>().SetBool("Fall", true);
            StartCoroutine(gameOver());
        }
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
        if (collision.gameObject.CompareTag("Obstacle") && !isGameOver)
        {
            GetComponent<Animator>().SetBool("Crash", true);
            StartCoroutine(gameOver());
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("???");
            GetComponent<Animator>().SetBool("Victory", true);
            StartCoroutine(victory());
        }
    }

    public void startRunning()
    {
        isMoving = true;
        GetComponent<Animator>().SetBool("Running", true);
    }

    IEnumerator gameOver()
    {
        isGameOver = true;
        isMoving = false;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().setGameOver();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

    IEnumerator victory()
    {
        isMoving = false;
        isGameOver = true;
        yield return new WaitForSeconds(2);

        transform.Translate(new Vector3(5.5f - transform.position.x, 0.5f - transform.position.y, 246.6f - transform.position.z));
        transform.eulerAngles = new Vector3(10, 0, 0);
        camera.transform.localRotation = new Quaternion(0, 0, 0, 0);

        /*GetComponent<Animator>().SetBool("Victory", false);
        GetComponent<Animator>().SetBool("Paint", true);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().setGameOver();*/        
    }
}
