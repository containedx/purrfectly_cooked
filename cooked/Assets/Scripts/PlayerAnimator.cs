using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string WALK_ANIM = "Walk";

    [SerializeField] private Player player;
    private Animator animator;

    

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(WALK_ANIM, player.IsWalking());
    }


}
