using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TreeEvolution : MonoBehaviour
{
    [Header("Tree Objects")]
    public CanvasGroup[] treeStages;

    [Header("Settings")]
    public float fadeDuration = 1.5f;

    private void Start()
    {
        int current = PlayerPrefs.GetInt("TreeStage", 0);

        int needsEvolve = PlayerPrefs.GetInt("NeedsEvolve", 0);

        for (int i = 0; i < treeStages.Length; i++)
        {
            treeStages[i].gameObject.SetActive(i == current);
            treeStages[i].alpha = (i == current) ? 1 : 0;
        }

        if (needsEvolve == 1 && current < treeStages.Length - 1)
        {
            StartCoroutine(DelayedEvolve());
        }
    }

    private IEnumerator DelayedEvolve()
    {
        yield return new WaitForSeconds(0.5f);

        int current = PlayerPrefs.GetInt("TreeStage", 0);
        int next = current + 1;

        PlayerPrefs.SetInt("TreeStage", next);
        PlayerPrefs.SetInt("NeedsEvolve", 0);
        PlayerPrefs.Save();

        StartCoroutine(FadeToNext(treeStages[current], treeStages[next]));
    }

    private IEnumerator FadeToNext(CanvasGroup oldTree, CanvasGroup newTree)
    {
        newTree.gameObject.SetActive(true);
        newTree.alpha = 0;

        float elapsed = 0;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeDuration;
            oldTree.alpha = 1 - t;
            newTree.alpha = t;
            yield return null;
        }

        oldTree.alpha = 0;
        newTree.alpha = 1;
        oldTree.gameObject.SetActive(false);
    }
}
