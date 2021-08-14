using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Controller : MonoBehaviour
{
    [SerializeField]
    private GameObject mainCamera;

    private bool isPaintingStage = false;
    private bool isDistanceCalculated = false;
    private bool isMoving;
    private float runSpeed = 0.1f;
    private float sideSpeed = 0.01f;
    private float fallLimit = -1f;
    private bool isGameOver = false;

    Vector3 dest = new Vector3(17.450f, 2f, 247.43f);
    Vector3 direction = new Vector3();
    Vector3 distance = new Vector3();

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
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }

    IEnumerator victory()
    {
        isMoving = false;
        isGameOver = true;
        yield return new WaitForSeconds(2);

        mainCamera.transform.SetParent(null);
        mainCamera.transform.localRotation = new Quaternion(0, 0, 0, 0);
        isPaintingStage = true;
        StartCoroutine(MoveCamera());
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().enablePainting();
    }

    IEnumerator MoveCamera()
    {
        float step = 0f;
        distance = dest - mainCamera.transform.position;
        direction = distance.normalized;
        float distanceScalar = Mathf.Sqrt(Mathf.Pow(distance.x, 2) + Mathf.Pow(distance.y, 2) + Mathf.Pow(distance.z, 2));

        while (step < distanceScalar)
        {
            mainCamera.transform.Translate(direction);
            step++;
            yield return new WaitForSeconds(0.01f);
        }

        int angle = 0;
        while (angle < 90)
        {
            mainCamera.transform.Rotate(new Vector3(0, 1f, 0));
            angle++;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
