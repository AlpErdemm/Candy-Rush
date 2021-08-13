using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonut : MonoBehaviour
{
    [SerializeField]
    private Vector3 leftLocation;

    [SerializeField]
    private Vector3 rightLocation;

    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject stick;

    private bool isGoingLeft = false;

    private void Update()
    {
        if (isGoingLeft)
        {
            stick.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {
            stick.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (stick.transform.localPosition.x >= rightLocation.x)
        {
            isGoingLeft = true;
        }

        if (stick.transform.localPosition.x <= leftLocation.x)
        {
            isGoingLeft = false;
        }
    }
}
