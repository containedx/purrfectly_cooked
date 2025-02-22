using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private Image fillImage;

    private IHasProgress hasProgress;

    private void Start()
    {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();

        fillImage.fillAmount = 0f;
        hasProgress.OnProgressChanged += HasProgress_OnProgressChanged;

        Hide();
    }

    private void HasProgress_OnProgressChanged(object sender, OnProgressChangedEventArgs e)
    {
        fillImage.fillAmount = e.progressNormalized;

        if(e.progressNormalized == 0f || e.progressNormalized == 1f) Hide();
        else Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

}
