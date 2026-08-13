using TMPro;
using UnityEngine;

public class ShowTips : MonoBehaviour
{
    public string tip;
    public GameObject blank;

    private TMP_Text text;

    void Start()
    {
        text = blank.GetComponent<TMP_Text>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
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
        text.text = tip;
        blank.SetActive(isShow);
    }
}