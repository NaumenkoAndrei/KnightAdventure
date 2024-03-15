using UnityEngine;

public class EnemyEntity : MonoBehaviour{
    [SerializeField] private int _maxHealt = 10;
    private int _currentHealt;

    private void Start() {
        _currentHealt = _maxHealt;
    }

    public void TakeDamage(int damage) {
        _currentHealt -= damage;

        DetectDeath();
    }

    public void DetectDeath() {
        if (_currentHealt <= 0) {
            Destroy(gameObject);
        }
    }
}
