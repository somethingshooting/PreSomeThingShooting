using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_StageTitle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _Stage1Text = null;

    [SerializeField] private float _FadeInTime = 0.4f, _fadeOutTime = 1.0f;

    private void Start()
    {
        StartCoroutine(FadeInAndOut(_FadeInTime, _fadeOutTime));
    }

    private IEnumerator FadeInAndOut(float fadeintime, float fadeouttime)
    {
        float timer = 0;
        Color stagecolor = new Color(_Stage1Text.color.r, _Stage1Text.color.g, _Stage1Text.color.b, 0);
        while (timer < fadeintime)
        {
            _Stage1Text.color = new Color(stagecolor.r, stagecolor.g, stagecolor.b, timer / fadeintime);
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
        timer = fadeouttime;
        _Stage1Text.color = new Color(stagecolor.r, stagecolor.g, stagecolor.b, 1);
        yield return new WaitForSeconds(1);
        while (timer > 0)
        {
            _Stage1Text.color = new Color(stagecolor.r, stagecolor.g, stagecolor.b, timer / fadeouttime);
            yield return new WaitForEndOfFrame();
            timer -= Time.deltaTime;
        }
        _Stage1Text.color = new Color(stagecolor.r, stagecolor.g, stagecolor.b, 0);
    }
}
