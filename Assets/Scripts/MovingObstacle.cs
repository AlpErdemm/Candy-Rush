using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField]
    private Vector3 leftLocation;

    [SerializeField]
    private Vector3 rightLocation;

    [SerializeField]
    private float speed;

    public bool isGoingLeft = false;

    private void Update()
    {
        if (isGoingLeft)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (transform.position.x >= rightLocation.x)
        {
            isGoingLeft = true;
        }

        if (transform.position.x <= leftLocation.x)
        {
            isGoingLeft = false;
        }
    }

}
