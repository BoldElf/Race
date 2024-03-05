using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class UiButtonSound : MonoBehaviour
{
    private new AudioSource audio;
    [SerializeField] private AudioClip click;
    [SerializeField] private AudioClip hover;

    private UIButton[] uIButtons;

    private void Start()
    {
        audio = GetComponent<AudioSource>();

        uIButtons = GetComponentsInChildren<UIButton>(true);

        for(int i = 0; i < uIButtons.Length;i++)
        {
            uIButtons[i].PointerEnter += OnPointerEnter;
            uIButtons[i].PointerClick += OnPointerClick;
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < uIButtons.Length; i++)
        {
            uIButtons[i].PointerEnter -= OnPointerEnter;
            uIButtons[i].PointerClick -= OnPointerClick;
        }
    }

    private void OnPointerClick(UIButton button)
    {
        audio.PlayOneShot(click);
    }

    private void OnPointerEnter(UIButton button)
    {
        audio.PlayOneShot(hover);
    }
}
