using UnityEngine;

public class PlayerVisual : MonoBehaviour {
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private const string IS_RUNNING = "IsRunning";

    private void Awake() {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        _animator.SetBool(IS_RUNNING, Player.Instance.IsRunning);
        AdjustPlayerFacingDirection();
    }

    private void AdjustPlayerFacingDirection() {
        Vector2 mousePosirion = GameInput.Instance.GetMousePosition();
        Vector2 playerPosirion = Player.Instance.GetPlayerScreenPosition();

        if (mousePosirion.x < playerPosirion.x) {
            _spriteRenderer.flipX = true;
        } else {
            _spriteRenderer.flipX = false;
        }
    }
}
