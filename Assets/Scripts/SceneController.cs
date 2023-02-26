using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    private void Start() {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName.Equals("Game Over")) {
            FindObjectOfType<GameState>().ResetGame();
        }
    }

    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

        if (SceneManager.GetActiveScene().name.Equals("Game Over")) {
            FindObjectOfType<GameState>().ResetGame();
        }
    }

    public void LoadStartScreen() {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
