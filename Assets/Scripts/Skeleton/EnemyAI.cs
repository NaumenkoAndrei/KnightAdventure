using UnityEngine;
using UnityEngine.AI;
using KnigthAdventure.Utils;

public class EnemyAI : MonoBehaviour {
    [SerializeField] private State _startingState;
    [SerializeField] private float _roamingDistanceMax = 7f;
    [SerializeField] private float _roamingDistanceMin = 3f;
    [SerializeField] private float _roamingTimerMax = 2f;

    [SerializeField] private bool _isChasingEnemy = false;
    private float _chasingDistance = 4f;
    private float _chasingSpeedMultiplayer = 2f;

    private NavMeshAgent _navMeshAgent;
    private State _state;
    private float _roamingTime;
    private Vector2 _roamPosition;
    private Vector2 _startingPisition;

    public bool IsRunning {
        get{
            if (_navMeshAgent.velocity == Vector3.zero) {
                return false;
            } else {
                return true;
            }
        }
    }

    private enum State {
        Idle,
        Roaming,
        Chasing,
        Attacking,
        Death
    }

    private void Awake() {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        _state = _startingState;
    }

    private void Update() {
        switch (_state) {
            case State.Roaming:
                _roamingTime -= Time.deltaTime;
                if (_roamingTime < 0) {
                    Roaming();
                    _roamingTime = _roamingTimerMax;
                }
                break;
            case State.Chasing:
                break;
            case State.Attacking:
                break;
            case State.Death:
                break;
            default:
            case State.Idle:
                break;
        }
    }

    private void Roaming() {
        _startingPisition = transform.position;
        _roamPosition = GetRoamingPosition();
        ChangeFacingDirection(_startingPisition, _roamPosition);
        _navMeshAgent.SetDestination(_roamPosition);
    }

    private Vector2 GetRoamingPosition() {
        return _startingPisition + Utils.GetRandomDirection() * UnityEngine.Random.Range(_roamingDistanceMin, _roamingDistanceMax);
    }

    private void ChangeFacingDirection(Vector2 soursePosition, Vector2 targetPosition) {
        if (soursePosition.x > targetPosition.x) {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        } else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
