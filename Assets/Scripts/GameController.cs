using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject Character;

    [SerializeField]
    private GameObject PaintingWall;

    [SerializeField]
    private List<GameObject> StartElements;

    [SerializeField]
    private List<GameObject> TouchAreas;

    public void startGame()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Character");

        foreach (GameObject go in gos)
        {
            if(go.GetComponent<Character_Controller>() != null)
            {
                go.GetComponent<Character_Controller>().startRunning();
            }
            else if (go.GetComponent<OpponentController>() != null)
                go.GetComponent<OpponentController>().startRunning();
        }
        
        foreach(GameObject go in StartElements)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in TouchAreas)
        {
            go.SetActive(true);
        }


    }

    public void enablePainting()
    {
        PaintingWall.GetComponent<PaintingWall>().startPainting();
    }
}
