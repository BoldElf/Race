using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISelecableButton : UIButton
{
    [SerializeField] private GameObject SelectImage;

    public UnityEvent OnSelect;
    public UnityEvent OnUnSelect;


    public override void SetFocus()
    {
        base.SetFocus();
        SelectImage.SetActive(true);
        OnSelect?.Invoke();
    }

    public override void SetUnFocus()
    {
        base.SetUnFocus();
        SelectImage.SetActive(false);
        OnUnSelect?.Invoke();
    }
}
