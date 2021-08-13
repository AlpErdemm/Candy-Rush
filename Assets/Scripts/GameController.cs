using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject Character;

    [SerializeField]
    private List<GameObject> StartElements;

    [SerializeField]
    private List<GameObject> TouchAreas;

    public void startGame()
    {
        Character.GetComponent<Character_Controller>().startRunning();
        
        foreach(GameObject go in StartElements)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in TouchAreas)
        {
            go.SetActive(true);
        }


    }

    public void setGameOver()
    {
        Debug.Log("Game Over Bitch!");
    }
}
