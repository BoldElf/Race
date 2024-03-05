using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] protected bool Interactable;

    private bool focuse = false;
    public bool Focuse => focuse;

    public UnityEvent OnClick;

    public UnityAction<UIButton> PointerEnter;
    public UnityAction<UIButton> PointerExit;
    public UnityAction<UIButton> PointerClick;

    public virtual void SetFocus()
    {
        if (Interactable == false) return;
        focuse = true;
    }

    public virtual void SetUnFocus()
    {
        if (Interactable == false) return;
        focuse = false;
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (Interactable == false) return;
        PointerEnter?.Invoke(this);
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        if (Interactable == false) return;
        PointerExit?.Invoke(this);
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (Interactable == false) return;
        PointerClick?.Invoke(this);
        OnClick?.Invoke();
    }
}
