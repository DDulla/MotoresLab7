using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneChanger : MonoBehaviour
{
    public UnityEvent onSceneChange;

    public void ChangeScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        string nextScene = currentScene == "Scene1" ? "Scene2" : "Scene1";

        onSceneChange.Invoke();
        SceneManager.LoadScene(nextScene);
    }
}