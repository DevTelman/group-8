using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroLoader : MonoBehaviour
{
    public Image loaderCircle;
    public GameObject loaderImage;
    public GameObject startButton;
    public GameObject hubButton;

    public float firstPhaseTime = 2.5f;
    public float secondPhaseTime = 2.5f;

    void Start()
    {
        startButton.SetActive(false);
        hubButton.SetActive(false);

        loaderCircle.fillAmount = 0f;
        loaderImage.SetActive(true);

        StartCoroutine(LoadingSequence());
    }

    IEnumerator LoadingSequence()
    {
        yield return StartCoroutine(FillTo(0f, 0.5f, firstPhaseTime));

        yield return new WaitForSeconds(0.2f);

        yield return StartCoroutine(FillTo(0.5f, 1f, secondPhaseTime));

        loaderImage.SetActive(false);
        loaderCircle.gameObject.SetActive(false);

        startButton.SetActive(true);
        hubButton.SetActive(true);
    }

    IEnumerator FillTo(float from, float to, float duration)
    {
        float elapsed = 0f;
        loaderCircle.fillAmount = from;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            loaderCircle.fillAmount = Mathf.Lerp(from, to, elapsed / duration);
            yield return null;
        }

        loaderCircle.fillAmount = to;
    }
}
