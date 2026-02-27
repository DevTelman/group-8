using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ImageTransition : MonoBehaviour
{
    public Image targetImage;
    private CanvasGroup canvasGroup;

    public float fadeDuration = 0.5f;
    public float scaleAmount = 1.2f;
    public float scaleDuration = 0.5f;

    void Awake()
    {
        canvasGroup = targetImage.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
            canvasGroup = targetImage.gameObject.AddComponent<CanvasGroup>();
    }

    void Start()
    {
        PlayEffect();
    }

    public void PlayEffect()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(canvasGroup.DOFade(0f, fadeDuration));
        seq.Join(targetImage.rectTransform.DOScale(scaleAmount, scaleDuration).SetEase(Ease.OutBack));

        seq.Append(canvasGroup.DOFade(1f, fadeDuration));
        seq.Join(targetImage.rectTransform.DOScale(1f, scaleDuration).SetEase(Ease.OutBack));
    }
}
