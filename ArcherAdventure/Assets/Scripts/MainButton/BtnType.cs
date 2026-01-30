using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ButtonType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;

    void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    public void OnBtnClick()
    {
        switch (currentType)
        {
            case ButtonType.New:
                Debug.Log("새게임");
                break;
            case ButtonType.Continue:
                Debug.Log("이어하기");
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}    