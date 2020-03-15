using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSec = 1.5f;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("game");
        FindObjectOfType<Player>().ResetGame();
        //SceneManager.LoadScene(1);
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad()); 
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSec);
        SceneManager.LoadScene("Game over");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
