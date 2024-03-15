using UnityEngine;

public class ActiveWeapon : MonoBehaviour {
    public static ActiveWeapon Instance { get; private set; }

    [SerializeField] private Sword _sword;

    private void Awake() {
        Instance = this;
    }

    private void Update() {
        FollowMousePosition();
    }

    public Sword GetActiveWeapon() {
        return _sword;
    }

    private void FollowMousePosition() {
        Vector2 mousePosirion = GameInput.Instance.GetMousePosition();
        Vector2 playerPosirion = Player.Instance.GetPlayerScreenPosition();

        if (mousePosirion.x < playerPosirion.x) {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
