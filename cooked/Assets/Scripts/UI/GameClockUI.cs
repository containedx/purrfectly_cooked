using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClockUI : MonoBehaviour
{
    [SerializeField] private Image clockFill;

    private void Update()
    {
        clockFill.fillAmount =  GameManager.Instance.GetGamePLayingTimerNormalized();
    }
}
