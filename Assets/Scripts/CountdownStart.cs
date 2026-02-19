using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownStart : MonoBehaviour
{
    public TMP_Text countdownText;
    public AudioSource countdownAudio;

    void Start()
    {
        Time.timeScale = 0f;
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        if (countdownAudio != null)
            countdownAudio.Play();

        int count = 3;

        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return StartCoroutine(AnimateCountdown(countdownText));
            count--;
        }

        countdownText.text = "GO!";
        yield return StartCoroutine(AnimateCountdown(countdownText));

        countdownText.gameObject.SetActive(false);
        Time.timeScale = 1f;

        if (MusicManager.Instance != null && MusicManager.Instance.audioSource != null)
        {
            MusicManager.Instance.audioSource.Play();
        }
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
            float scale = Mathf.Lerp(0f, 2f, t / duration);
            scale += Mathf.Sin(t * Mathf.PI * 2) * 0.2f;
            text.transform.localScale = Vector3.one * scale;

            float alpha = Mathf.Lerp(0f, 1f, t / duration);
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            yield return null;
        }

        yield return new WaitForSecondsRealtime(0.5f);
    }
}
