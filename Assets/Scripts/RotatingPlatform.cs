using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float spinSpeed;
    [SerializeField]
    private float pushForce;

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, spinSpeed));
    }

    private void OnCollisionStay(Collision collision)
    {
        collision.gameObject.transform.Translate(new Vector3(pushForce, 0, 0));
    }


}
