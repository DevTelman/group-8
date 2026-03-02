using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using static WinZone;

public class BloomFlash : MonoBehaviour
{
    public Volume volume;
    public float maxBloom = 6f;
    public float flashDuration = 1f;

    Bloom bloom;

    void Start()
    {
        volume.profile.TryGet(out bloom);

        if (WinManager.levelCompleted)
        {
            StartCoroutine(Flash());
            WinManager.levelCompleted = false; // reset
        }
    }

    IEnumerator Flash()
    {
        float time = 0;

        while (time < flashDuration / 2)
        {
            time += Time.deltaTime;
            bloom.intensity.value = Mathf.Lerp(0, maxBloom, time / (flashDuration / 2));
            yield return null;
        }

        time = 0;

        while (time < flashDuration / 2)
        {
            time += Time.deltaTime;
            bloom.intensity.value = Mathf.Lerp(maxBloom, 0, time / (flashDuration / 2));
            yield return null;
        }

        bloom.intensity.value = 0;
    }
}