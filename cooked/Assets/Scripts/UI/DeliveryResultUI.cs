using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DeliveryResultUI : MonoBehaviour
{
    private const string POPUP_TRIGGER = "Popup";


    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI message;

    [SerializeField] private Color successColor;
    [SerializeField] private Color failColor;
    [SerializeField] private Sprite successIcon;
    [SerializeField] private Sprite failIcon;
    [SerializeField] private string successMessage = "Delivery Success";
    [SerializeField] private string failMessage = "Delivery Failed";

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator> ();
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFail += DeliveryManager_OnRecipeFail;

        gameObject.SetActive (false);
    }

    private void DeliveryManager_OnRecipeFail(object sender, System.EventArgs e)
    {
        Debug.Log("delivery manager failed ui");
        gameObject.SetActive(true);
        backgroundImage.color = failColor;
        iconImage.sprite = failIcon;
        message.text = failMessage;
        animator.SetTrigger(POPUP_TRIGGER);
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
        backgroundImage.color = successColor; 
        iconImage.sprite = successIcon;
        message.text = successMessage;
        animator.SetTrigger(POPUP_TRIGGER);
    }
}
