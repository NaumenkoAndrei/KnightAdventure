using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SwordVisual : MonoBehaviour
{
    [SerializeField] private Sword _sword;

    private Animator _animator;
    private const string ATTACK = "Attack";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _sword.OnSwordSwing += Sword_OnSwordSwing;
    }

    private void Sword_OnSwordSwing(object sender, EventArgs e)
    {
        _animator.SetTrigger(ATTACK);
    }

    public void TriggerEndAttackAnimation()
    {
        _sword.AttackColliderTurnOff();
    }
}
