using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroLoader : MonoBehaviour
{
    public Image loaderCircle;
    public GameObject loaderImage;
    public GameObject startButton;
    public GameObject hubButton;

    public float firstPhaseTime = 2.5f;
    public float secondPhaseTime = 2.5f;

    // Այս փոփոխականը պահում է, աշխատե՞լ է Loader-ը արդեն
    private static bool loaderPlayed = false;

    void Start()
    {
        // Loader-ը աշխատում է միայն առաջին սցենար + առաջին անգամ բացվելիս
        if (SceneManager.GetActiveScene().buildIndex == 0 && !loaderPlayed)
        {
            loaderPlayed = true; // նշում ենք, որ Loader-ը սկսեց աշխատել

            startButton.SetActive(false);
            hubButton.SetActive(false);

            loaderCircle.fillAmount = 0f;
            loaderCircle.gameObject.SetActive(true);
            loaderImage.SetActive(true);

            StartCoroutine(LoadingSequence());
        }
        else
        {
            // Այլ դեպքերում Loader-ը ընդհանրապես չի երևում
            loaderCircle.gameObject.SetActive(false);
            loaderImage.SetActive(false);
            startButton.SetActive(true);
            hubButton.SetActive(true);
        }
    }

    IEnumerator LoadingSequence()
    {
        float elapsed = 0f;

        // Առաջին փուլ
        while (elapsed < firstPhaseTime)
        {
            elapsed += Time.deltaTime;
            loaderCircle.fillAmount = Mathf.Lerp(0f, 0.5f, elapsed / firstPhaseTime);
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        // Երկրորդ փուլ
        elapsed = 0f;
        while (elapsed < secondPhaseTime)
        {
            elapsed += Time.deltaTime;
            loaderCircle.fillAmount = Mathf.Lerp(0.5f, 1f, elapsed / secondPhaseTime);
            yield return null;
        }

        loaderCircle.gameObject.SetActive(false);
        loaderImage.SetActive(false);
        startButton.SetActive(true);
        hubButton.SetActive(true);
    }
}
