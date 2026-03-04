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

    // Ավելացնում ենք երկու նոր փոփոխականները
    public GameObject star;
    public GameObject trash;

    public float firstPhaseTime = 2.5f;
    public float secondPhaseTime = 2.5f;

    private static bool loaderPlayed = false;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 && !loaderPlayed)
        {
            loaderPlayed = true;

            // Թաքցնում ենք ամեն ինչ լոդինգի սկզբում
            startButton.SetActive(false);
            hubButton.SetActive(false);
            star.SetActive(false); // Անջատում ենք աստղը
            trash.SetActive(false); // Անջատում ենք աղբամանը (կամ ինչ որ նկար է)

            loaderCircle.fillAmount = 0f;
            loaderCircle.gameObject.SetActive(true);
            loaderImage.SetActive(true);

            StartCoroutine(LoadingSequence());
        }
        else
        {
            // Եթե սա առաջին անգամը չէ, ամեն ինչ միացնում ենք միանգամից
            loaderCircle.gameObject.SetActive(false);
            loaderImage.SetActive(false);
            startButton.SetActive(true);
            hubButton.SetActive(true);
            star.SetActive(true);
            trash.SetActive(true);
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

        // Լոդինգը պրծավ, թաքցնում ենք լոդերը
        loaderCircle.gameObject.SetActive(false);
        loaderImage.SetActive(false);

        // Միացնում ենք բոլոր կոճակներն ու նկարները
        startButton.SetActive(true);
        hubButton.SetActive(true);
        star.SetActive(true);
        trash.SetActive(true);
    }
}
