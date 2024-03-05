using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UISelectableContainer : MonoBehaviour
{
    [SerializeField] private Transform buttonsContainer;

    public bool Interactbale = true;

    public void SetInteractable(bool interactable) => Interactbale = interactable;

    private UISelecableButton[] buttons;

    private int SelectButtonIndex = 0;

    private void Start()
    {
        buttons = buttonsContainer.GetComponentsInChildren<UISelecableButton>();

        if(buttons == null)
        {
            Debug.LogError("Button list is empty!");
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].PointerEnter += OnPointerEnter;
        }

        if (Interactbale == false) return;

        buttons[SelectButtonIndex].SetFocus();
    }

    private void OnDestroy()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].PointerEnter -= OnPointerEnter;
        }
    }

    private void OnPointerEnter(UIButton button)
    {
        SelectButton(button);
    }

    private void SelectButton(UIButton button)
    {
        if (Interactbale == false) return;

        buttons[SelectButtonIndex].SetUnFocus();

        for(int i = 0; i < buttons.Length;i++)
        {
            if(button == buttons[i])
            {
                SelectButtonIndex = i;
                button.SetFocus();
                break;
            }
        }
    }
}
