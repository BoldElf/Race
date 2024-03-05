using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettingButton : UISelecableButton,IScriptableObjectProperty
{
    [SerializeField] private Setting setting;
    [SerializeField] private Text titleText;
    [SerializeField] private Text valueText;
    [SerializeField] private Image previousImage;
    [SerializeField] private Image nextImage;

    private void Start()
    {
        ApplayProperty(setting);
    }
    public void SetNextValueSetting()
    {
        setting?.SetNextValue();
        setting?.Applay();
        UpdateInfo();
    }

    public void SetPreviouseValueSetting()
    {
        setting?.SetPreviousValue();
        setting?.Applay();
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        titleText.text = setting.Title;
        valueText.text = setting.GetStringValue();

        previousImage.enabled = !setting.isMinValue;
        nextImage.enabled = !setting.isMaxValue;
    }

    public void ApplayProperty(ScriptableObject property)
    {
        if (property == null) return;
        if (property is Setting == false) return;

        setting = property as Setting;

        UpdateInfo();
    }
}
