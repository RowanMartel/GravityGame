using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeAfterTime : MonoBehaviour
{
    public float timer = 0;
    public float disappearAfter = 5;
    public float fadeTime = 1;
    TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (timer >= disappearAfter) return;
        timer += Time.deltaTime;
        if (timer >= disappearAfter)
            FadeText(); 
    }

    void FadeText()
    {
        text.DOFade(0, fadeTime);
    }
}