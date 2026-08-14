using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ButtonDetective : MonoBehaviour
{
    public Sprite button_actiavte;
    public Sprite button_unactivate;
    public List<GameObject> changeStateObj = new();

    public float duration;
    public bool open = true;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chest"))
        {
            SetState(changeStateObj, true, duration, open);
            SetSprite(button_actiavte);

        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Chest"))
        {
            SetState(changeStateObj, true, duration, open);
            SetSprite(button_actiavte);

        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Chest"))
        {
            SetState(changeStateObj, false, duration, !open);
            SetSprite(button_unactivate);

        }
    }


    public void SetState(List<GameObject> objs, bool state, float duration, bool isKeepState)
    {
        //Debug.Log("WindToFan");
        foreach (GameObject obj in objs)
        {
            obj.GetComponent<BinaryStateObj>().Set(state, duration, isKeepState);
        }
    }

    public void SetSprite(Sprite _sprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = _sprite;
    }
}
