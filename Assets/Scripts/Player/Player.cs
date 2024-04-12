using System;
using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public bool IsRunning { get; private set; }

    [SerializeField] private float _movingSpeed = 5f;

    private Rigidbody2D _rb;
    private float _minMovingSpeed = 0.1f;
    private Vector2 _movementVector;

    private void Awake()
    {
        Instance = this;
        IsRunning = false;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameInput.Instance.OnPlayerAttack += GameInput_OnPlayerAttack;
    }

    private void OnDestroy()
    {
        GameInput.Instance.OnPlayerAttack -= GameInput_OnPlayerAttack;
    }

    public Vector2 GetPlayerScreenPosition()
    {
        Vector2 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }

    private void GameInput_OnPlayerAttack(object sender, EventArgs e)
    {
        ActiveWeapon.Instance.GetActiveWeapon().Attack();
    }

    private void Update()
    {
        _movementVector = GameInput.Instance.GetMovementVector();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        _rb.MovePosition(_rb.position + _movementVector * (_movingSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(_movementVector.x) > _minMovingSpeed || Mathf.Abs(_movementVector.y) > _minMovingSpeed)
        {
            IsRunning = true;
        }
        else
        {
            IsRunning = false;
        }
    }
}