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
        if (buttonScale != null)
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
            case ButtonType.Quit:
                OnQuitClick();
                break;
        }
    }

    void OnQuitClick()
    {
        Application.Quit();  // 게임 완전 종료 (빌드: exe 종료 / 에디터: Unity 종료)
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonScale != null)
            buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonScale != null)
            buttonScale.localScale = defaultScale;
    }
}    