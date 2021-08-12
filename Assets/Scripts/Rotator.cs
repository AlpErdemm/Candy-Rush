using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float spinSpeed;

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, spinSpeed, 0));
    }
}
