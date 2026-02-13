using System.Collections;
using TMPro;
using UnityEngine;

public class CountdownStart : MonoBehaviour
{
    public TMP_Text countdownText;
    public AudioSource countdownAudio; // 3-2-1-GO ձայնը
    public AudioSource musicSource;    // Խաղի հիմնական երաժշտություն

    void Start()
    {
        Time.timeScale = 0f;
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        // Միանգամից նվագել 3-2-1-GO ձայնը
        if (countdownAudio != null)
            countdownAudio.Play();

        int count = 3;

        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return StartCoroutine(AnimateCountdown(countdownText));
            count--;
        }

        // GO!
        countdownText.text = "GO!";
        yield return StartCoroutine(AnimateCountdown(countdownText));

        // Թեքստը թաքցնել
        countdownText.gameObject.SetActive(false);

        // Խաղը վերսկսել և հիմնական երաժշտությունը միացնել
        Time.timeScale = 1f;
        if (musicSource != null)
            musicSource.Play();
    }

    IEnumerator AnimateCountdown(TMP_Text text)
    {
        text.transform.localScale = Vector3.zero;
        Color originalColor = text.color;
        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

        float duration = 0.5f;
        float t = 0f;

        while (t < duration)
        {
            t += Time.unscaledDeltaTime;

            // Scale animation + փոքր bounce
            float scale = Mathf.Lerp(0f, 2f, t / duration);
            scale += Mathf.Sin(t * Mathf.PI * 2) * 0.2f;
            text.transform.localScale = Vector3.one * scale;

            // Fade In
            float alpha = Mathf.Lerp(0f, 1f, t / duration);
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            yield return null;
        }

        yield return new WaitForSecondsRealtime(0.5f);
    }
}
