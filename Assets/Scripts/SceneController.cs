using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
   public void StartGameScene()
    {
        SceneManager.LoadScene("Game");
        SceneManager.UnloadSceneAsync("MainMenu");

        SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);

    }
}
