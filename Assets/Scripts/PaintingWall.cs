using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaintingWall : MonoBehaviour
{
    [SerializeField]
    private GameObject stain;

    [SerializeField]
    private GameObject congrats;

    [SerializeField]
    private GameObject percentageText;

    [SerializeField]
    private List<GameObject> fractions;

    private bool isStarted = false;
    
    public void startPainting()
    {
        isStarted = true;
    }
    
    private void Update()
    {
        // Activate red blocks upon ray hit
        if (Input.GetMouseButton(0) && isStarted)
        {
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(Ray, out hit) && hit.collider.gameObject.CompareTag("Wall"))
            {
                hit.collider.gameObject.GetComponent<UnityEngine.UI.Image>().enabled = true;
            }

            CheckPercentage();
        }
    }

    // Check fill percentage and update text
    private void CheckPercentage()
    {
        int percentage = Mathf.RoundToInt(calculatePercentage());
        if(percentage == 100)
        {
            StartCoroutine(GameEnd());
        }
        percentageText.GetComponent<TMPro.TextMeshProUGUI>().text = "% " + percentage;
    }

    private float calculatePercentage()
    {
        int count = 0;
        foreach(GameObject go in fractions)
        {
            if (go.GetComponent<UnityEngine.UI.Image>().IsActive())
                count++;
        }

        return count * 100f / fractions.Count;
    }

    // Painting done, reload the scene
    IEnumerator GameEnd()
    {
        congrats.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

}
