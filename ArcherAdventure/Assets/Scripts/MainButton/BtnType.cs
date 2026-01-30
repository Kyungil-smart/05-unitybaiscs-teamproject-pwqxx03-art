using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnType : MonoBehaviour
{
    public ButtonType currentType;

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
}
