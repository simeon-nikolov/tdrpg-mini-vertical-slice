using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanvasTintFader : MonoBehaviour
{
    public Image tintImage;
    public Text text;
    public float fadeDuration = 0f;

    void Start()
    {
        this.StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        yield return this.Fade(0.6f, 0.75f);
    }

    public IEnumerator FadeOut()
    {
        yield return this.Fade(0.75f, 0f);
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        Color imageColor = this.tintImage.color;
        Color textColor = this.text.color;
        float elapsed = 0f;

        while (elapsed < this.fadeDuration)
        {
            float t = elapsed / this.fadeDuration;
            imageColor.a = Mathf.Lerp(startAlpha, endAlpha, t);
            textColor.a = Mathf.Lerp(startAlpha, endAlpha, t);
            tintImage.color = imageColor;
            text.color = textColor;
            elapsed += Time.deltaTime;
            yield return null;
        }

        imageColor.a = endAlpha;
        textColor.a = endAlpha;
        tintImage.color = imageColor;
        text.color = textColor;
    }
}
