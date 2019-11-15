using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverBottons : MonoBehaviour
{
    public void Restart()
    {
        Debug.Log("Reload Test");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        Debug.Log("Menu Test");
        SceneManager.LoadScene("Menu");
    }
}
