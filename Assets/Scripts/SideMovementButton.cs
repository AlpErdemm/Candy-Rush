using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class SideMovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private bool isLeft;

    [SerializeField]
    private GameObject Character;

    private bool mouseDown = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        mouseDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        mouseDown = false;
    }

    void FixedUpdate()
    {
        checkTouch();
    }

    // Check touches/pointer and move character accordingly
    private void checkTouch()
    {
        if (mouseDown)
        {
            if (Input.GetMouseButton(0))
            {
                if (isLeft)
                    Character.GetComponent<Character_Controller>().moveLeft();
                else
                    Character.GetComponent<Character_Controller>().moveRight();
            }

        }
    }
}
