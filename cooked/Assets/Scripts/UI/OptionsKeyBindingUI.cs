using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OptionsKeyBindingUI : MonoBehaviour
{
    public GameInput.Binding binding;

    [SerializeField] private TMP_Text label;
    [SerializeField] private TMP_Text buttonLabel;
    [SerializeField] private Button button;
    [SerializeField] private OptionsUI optionsUI;

    private void Start()
    {
        label.text = binding.ToString();
        UpdateVisual();
        button.onClick.AddListener(Rebind);
    }

    public void Rebind()
    {
        optionsUI.ShowPressKeyToRebind();
        GameInput.Instance.RebindBinding(binding, RebindFinished);
    }

    private void RebindFinished()
    {
        optionsUI.HidePressKeyToRebind();
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        buttonLabel.text = GameInput.Instance.GetBindingText(binding);
    }
}
