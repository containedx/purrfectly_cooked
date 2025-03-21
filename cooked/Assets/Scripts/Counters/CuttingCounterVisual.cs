using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    private const string CUT = "Cut";

    [SerializeField] private CuttingCounter counter;
    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        counter.OnCut += TriggerCutCounterAnimation;
    }

    private void TriggerCutCounterAnimation(object sender, System.EventArgs e)
    {
        animator.SetTrigger(CUT);
    }
}
