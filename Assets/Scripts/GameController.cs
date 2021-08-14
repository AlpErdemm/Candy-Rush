using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject Character;

    public GameObject RankingText;

    [SerializeField]
    private GameObject PaintingWall;

    [SerializeField]
    private List<GameObject> StartElements;

    [SerializeField]
    private List<GameObject> TouchAreas;
    public void startGame()
    {
        // Find characters and start running
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
        
        // Update UI
        foreach(GameObject go in StartElements)
        {
            go.SetActive(false);
        }

        foreach (GameObject go in TouchAreas)
        {
            go.SetActive(true);
        }
        RankingText.SetActive(true);


    }

    private void Update()
    {
        checkRanking();
    }

    public void enablePainting()
    {
        GameObject[] Characters = GameObject.FindGameObjectsWithTag("Character");
        foreach (GameObject go in Characters)
        {
            if (go.GetComponent<Character_Controller>() == null)
                go.SetActive(false);
        }
        PaintingWall.GetComponent<PaintingWall>().startPainting();
    }

    // Calculate and update rank text 
    private void checkRanking()
    {
        GameObject[] Characters = GameObject.FindGameObjectsWithTag("Character");

        float playerLocation = Character.transform.position.z;
        int count = 1;

        foreach(GameObject go in Characters)
        {
            if (go.GetComponent<Character_Controller>() == null && go.transform.position.y > -4f && go.transform.position.z > playerLocation)
            {
                    count++;
            }
        }

        if (count == 1)
            RankingText.GetComponent<TMPro.TextMeshProUGUI>().text = "1st";
        else if (count == 2)
            RankingText.GetComponent<TMPro.TextMeshProUGUI>().text = "2nd";
        else if (count == 3)
            RankingText.GetComponent<TMPro.TextMeshProUGUI>().text = "3rd";
        else
            RankingText.GetComponent<TMPro.TextMeshProUGUI>().text = count + "th";
    }
}
