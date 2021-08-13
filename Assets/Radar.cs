using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<RotatingPlatform>() != null)   
        {

        }
        else if (other.gameObject.GetComponent<MovingObstacle>() != null)
        {

        }
        else if (other.gameObject.GetComponent<MovingObstacle>() != null)
        {

        }
        else
        {
            if (other.CompareTag("Obstacle")){
                   // Static
            }
        }
    }
}
