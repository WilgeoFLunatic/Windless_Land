using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowTips : MonoBehaviour
{
    [Header("显示文字")]
    public GameObject blank;

    [Header("显示图标")]
    public List<GameObject> icon;


    public float fadeDuration = 0.5f;


    private TMP_Text text;

    private Coroutine fadeCoroutine;


    void Awake()
    {
        text = blank.GetComponent<TMP_Text>();

        //保证开始时隐藏
        SetAlpha(0);



        foreach (GameObject obj in icon)
        {
            obj.SetActive(true);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            blank.SetActive(true);
            foreach (var obj in icon)
            {
                obj.SetActive(true);
            }
            Show(true);
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Show(false);
        }
    }


    public void Show(bool isShow)
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
        }

        fadeCoroutine = StartCoroutine(Fade(isShow));
    }



    IEnumerator Fade(bool isShow)
    {
        float startAlpha = text.color.a;
        float targetAlpha = isShow ? 1 : 0;

        float timer = 0;


        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;

            float alpha = Mathf.Lerp(
                startAlpha,
                targetAlpha,
                timer / fadeDuration
            );

            SetAlpha(alpha);

            yield return null;
        }


        SetAlpha(targetAlpha);


        //隐藏状态不关闭GameObject
        //避免下次进入无法显示
    }



    void SetAlpha(float alpha)
    {
        //文字
        if (text != null)
        {
            Color color = text.color;
            color.a = alpha;
            text.color = color;
        }


        //图标
        foreach (GameObject obj in icon)
        {
            if (obj == null)
                continue;


            Image img = obj.GetComponent<Image>();

            if (img != null)
            {
                Color color = img.color;
                color.a = alpha;
                img.color = color;
            }
        }
    }
}