using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneChanger : MonoBehaviour
{
    public UnityEvent onScene1Change;
    public UnityEvent onScene2Change;

    public void ChangeToScene1()
    {
        onScene1Change.Invoke();
        SceneManager.LoadScene("Scene1");
    }

    public void ChangeToScene2()
    {
        onScene2Change.Invoke();
        SceneManager.LoadScene("Scene2");
    }
}