using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SwordSlashVisual : MonoBehaviour
{
    [SerializeField] private Sword _sword;

    private const string ATTACK = "Attack";
    private Animator _animator;

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
}
