using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarFlashingUI : MonoBehaviour
{
    private const string IS_FLASHING_BOOL = "IsFlashing";

    [SerializeField] private StoveCounter stoveCounter;

    private Animator animator;
    private float burnShowProgressAmount = 0.5f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool(IS_FLASHING_BOOL, false);
    }

    private void Start()
    {
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;
    }

    private void StoveCounter_OnProgressChanged(object sender, OnProgressChangedEventArgs e)
    {
        bool show = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;

        animator.SetBool(IS_FLASHING_BOOL, show);
    }
}
