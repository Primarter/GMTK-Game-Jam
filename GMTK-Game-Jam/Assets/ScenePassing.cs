using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePassing : MonoBehaviour
{
    public bool canContinue = true;

    void Update()
    {
        if (canContinue && Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
