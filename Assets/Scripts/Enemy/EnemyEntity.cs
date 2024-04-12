using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class EnemyEntity : MonoBehaviour
{
    [SerializeField] private int _maxHealt = 10;
    private int _currentHealt;

    private PolygonCollider2D _polygonCollider2D;

    private void Awake()
    {
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    private void Start()
    {
        _currentHealt = _maxHealt;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Attack");
    }

    public void TakeDamage(int damage)
    {
        _currentHealt -= damage;

        DetectDeath();
    }

    public void polygonColliderTurnOff()
    {
        _polygonCollider2D.enabled = false;
    }

    public void polygonColliderTurnOn()
    {
        _polygonCollider2D.enabled = true;
    }

    private void DetectDeath()
    {
        if (_currentHealt <= 0)
        {
            Destroy(gameObject);
        }
    }
}
