using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingWall : MonoBehaviour
{
    [SerializeField]
    private GameObject stain;

    private bool isStarted = true;
    
    public void startPainting()
    {
        isStarted = true;
    }
    
    private void Update()
    {
        if (Input.GetMouseButton(0) && isStarted)
        {
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(Ray, out hit) && hit.collider.gameObject.CompareTag("Wall"))
            {
                hit.collider.gameObject.GetComponent<UnityEngine.UI.Image>().enabled = true;
            }
        }
    }

}
