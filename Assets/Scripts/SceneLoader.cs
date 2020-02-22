using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
    [SerializeField]
    private int gameOverScene;

    public void LoadNextScene() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void LoadStartScene() {
        SceneManager.LoadScene(0);
    }

    public void LoadGameOverScene() {
        SceneManager.LoadScene(gameOverScene);
    }

    public void OnQuit() {
        Application.Quit();
    }
}
