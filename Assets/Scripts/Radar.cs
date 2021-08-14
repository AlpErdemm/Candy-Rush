using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{

    // Detect obstacles ahead
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<RotatingPlatform>() != null)   
        {
            transform.parent.GetComponent<OpponentController>().enterRotatingPlatform(other.gameObject);
        }
        else if (other.gameObject.GetComponent<MovingObstacle>() != null)
        {
            transform.parent.GetComponent<OpponentController>().enterMovingObstacle(other.gameObject);
        }
        else
        {
            if (other.CompareTag("Obstacle")){
                transform.parent.GetComponent<OpponentController>().enterStaticObstacle(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<RotatingPlatform>() != null)
        {
            transform.parent.GetComponent<OpponentController>().exitRotatingPlatform(other.gameObject);
        }
        else if (other.gameObject.GetComponent<MovingObstacle>() != null)
        {
            transform.parent.GetComponent<OpponentController>().exitMovingObstacle(other.gameObject);
        }
        else
        {
            if (other.CompareTag("Obstacle"))
            {
                transform.parent.GetComponent<OpponentController>().exitStaticObstacle(other.gameObject);
            }
        }
    }
}
