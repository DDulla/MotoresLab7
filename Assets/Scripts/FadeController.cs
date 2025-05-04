using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeController : MonoBehaviour
{
    public static FadeController Instance;

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        fadeImage.color = new Color(0, 0, 0, 0); 
    }

    public void FadeIn()
    {
        fadeImage.gameObject.SetActive(true);
        StartCoroutine(Fade(1));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(0));
    }

    private IEnumerator Fade(float targetAlpha)
    {
        Color color = fadeImage.color;
        float startAlpha = color.a;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = targetAlpha;
        fadeImage.color = color;

        if (targetAlpha == 0)
        {
            fadeImage.gameObject.SetActive(false); 
        }
    }
}