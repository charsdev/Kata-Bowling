using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    private Image _fadeImage;
    private Color _initialColorImage;
    [SerializeField] private Color _fadeColor;

    public UnityEvent OnFadeInFinish;
    public UnityEvent OnFadeOutFinish;

    private void Start()
    {
        _fadeImage = GetComponent<Image>();
        _initialColorImage = _fadeImage.color;
        Color color = Color.white;
        color.a = 0;
        _initialColorImage = color;
    }

    public IEnumerator DelayFade(float delay, float fadeTime)
    {
        yield return new WaitForSeconds(delay);
        FadeOut(fadeTime);
    }

    public IEnumerator Fade(Image fadeImage, float totalDuration, Color a, Color b, UnityEvent OnFinish)
    {
        float elapsedTime = 0f;
        while (elapsedTime < totalDuration)
        {
            elapsedTime += Time.deltaTime;
            fadeImage.color = Color.Lerp(a, b, elapsedTime / totalDuration);
            yield return null;
        }
        OnFinish?.Invoke();
    }

    public void FadeInOut(float totalDuration)
    {
        var fadeIn = Fade(_fadeImage, totalDuration, _initialColorImage, _fadeColor, OnFadeInFinish);
        StartCoroutine(fadeIn);
        StartCoroutine(DelayFade(totalDuration, totalDuration));
    }


    public void FadeOut(float totalDuration)
    {
        var fadeOut = Fade(_fadeImage, totalDuration, _fadeColor, _initialColorImage, OnFadeOutFinish);
        StartCoroutine(fadeOut);
    }

    public void FadeIn(float totalDuration)
    {
        var fadeIn = Fade(_fadeImage, totalDuration, _initialColorImage, _fadeColor, OnFadeInFinish);
        StartCoroutine(fadeIn);
    }
}
