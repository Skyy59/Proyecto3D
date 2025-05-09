using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.Scripting.APIUpdating;

public class AIController : MonoBehaviour
{

    [SerializeField] private NavMeshAgent _navAgent;
    [SerializeField] private float _startWaitTime = 4f;
    [SerializeField] private float _timeToRotate = 2f;
    [SerializeField] private float _speedWalk = 6f;
    [SerializeField] private float _speedRun = 9f;

    [SerializeField] private float _viewRadius = 15f;
    [SerializeField] private float _viewAngle = 90f;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private LayerMask _obstacleMask;


    public Transform[] waypoints;
    int _CurrentWaypointIndex;

    Vector3 playerLastPosition = Vector3.zero;
    Vector3 _PlayerPosition;

    float _WaitTime;
    float _TimeRotate;
    bool _PlayerInRange;
    bool _PlayerNear;
    bool _IsPatrol;
    public bool caughtPlayer;

    public float leftAngle = -45f;
    public float rightAngle = 45f;
    public float speed = 1f;

    void Start()
    {
        _PlayerPosition = Vector3.zero;
        _IsPatrol = true;
        caughtPlayer = false;
        _PlayerInRange = false;
        _WaitTime = _startWaitTime;
        _TimeRotate = _timeToRotate;

        _startWaitTime = 4;

        _CurrentWaypointIndex = 0;
        _navAgent = GetComponent<NavMeshAgent>();

        _navAgent.isStopped = false;
        _navAgent.speed = _speedWalk;
        _navAgent.SetDestination(waypoints[_CurrentWaypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        EnvironmentView();

        if (!_IsPatrol)
        {
            Chasing();
        }
        else
        {
            Patrolling();

        }

        
    }

    private void Chasing()
    {
        _PlayerNear = false;
        playerLastPosition = Vector3.zero;

        if (!caughtPlayer)
        {
            Move(_speedRun);
            _navAgent.SetDestination(_PlayerPosition);
        }
        if(_navAgent.remainingDistance <= _navAgent.stoppingDistance)
        {
            if (_WaitTime <= 0 && !caughtPlayer && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 6f)
            {
                _IsPatrol = true;
                _PlayerNear = false;
                Move(_speedWalk);
                _timeToRotate = _TimeRotate;
                _WaitTime = _startWaitTime;
                _navAgent.SetDestination(waypoints[_CurrentWaypointIndex].position);
            }
            else
            {
                if(Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) >= 2.5f)
                {
                    Stop();
                    _WaitTime -= Time.deltaTime;
                    
                }
            }
        }
    }

    private void Patrolling()
    {
        if (_PlayerNear)
        {
            if (_timeToRotate <= 0)
            {
                Move(_speedWalk);
                LookingPlayer(playerLastPosition);
            }
            else
            {
                Stop();
                _timeToRotate -= Time.deltaTime;
            }
        }
        else
        {
            _PlayerNear = false;
            playerLastPosition = Vector3.zero;
            _navAgent.SetDestination(waypoints[_CurrentWaypointIndex].position);

            if (_navAgent.remainingDistance <= _navAgent.stoppingDistance)
            {
                if (_WaitTime <= 0)
                {
                    NextWaypoint();
                    Move(_speedWalk);
                    _WaitTime = _startWaitTime; 
                }
                else
                {
                    Stop();
                    _WaitTime -= Time.deltaTime;
                }
            }
            else
            {
                Move(_speedWalk); 
            }
        }
    }



    void Move(float speed)
    {
        _navAgent.isStopped = false;
        _navAgent.speed = speed;
    }
    void Stop()
    {
        _navAgent.isStopped = true;
        _navAgent.speed = 0;
    }

    public void NextWaypoint()
    {
        _CurrentWaypointIndex = (_CurrentWaypointIndex + 1) % waypoints.Length;
        _navAgent.SetDestination(waypoints[_CurrentWaypointIndex].position);
    }

    void CaughtPlayer() 
    {
        caughtPlayer = true;
    }



    void LookingPlayer(Vector3 player)
    {
        _navAgent.SetDestination(player);
        if (Vector3.Distance(transform.position, player) <= 0.3)
        {
            if (_WaitTime <= 0)
            {
                _PlayerNear = false;
                Move(_speedWalk);
                _navAgent.SetDestination(waypoints[_CurrentWaypointIndex].position);
                _WaitTime = _startWaitTime;
                _TimeRotate = _timeToRotate;
            }
            else
            {
                Stop();
                _WaitTime -= Time.deltaTime;
                
            }
        }
    }

    void EnvironmentView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, _viewRadius, _playerMask);

        for (int i = 0; i < playerInRange.Length; i++)
        {
            Transform player = playerInRange[i].transform;
            Vector3 dirToPlayer = (player.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToPlayer) < _viewAngle / 2)
            {
                float dstToPlayer = Vector3.Distance(transform.position, player.position);
                if (!Physics.Raycast(transform.position, dirToPlayer, dstToPlayer, _obstacleMask))
                {
                    _PlayerInRange = true;
                    _IsPatrol = false;
                }
                else
                {
                    _PlayerInRange = false;
                }
            }
            if (Vector3.Distance(transform.position, player.position) > _viewRadius)
            {
                _PlayerInRange = false;
            }

            if (_PlayerInRange)
            {
                _PlayerPosition = player.transform.position;
            }
        }
    }




    void OnDrawGizmosSelected()
    {
        // Dibuja la esfera de detección (verde semitransparente)
        Gizmos.color = new Color(0f, 1f, 0f, 1f); 
        Gizmos.DrawWireSphere(transform.position, _viewRadius);

        // Dibuja el cono de visión (rojo semitransparente)
        Gizmos.color = new Color(1f, 0f, 0f, 1f); 
        Vector3 dir1 = Quaternion.Euler(0, _viewAngle / 2, 0) * transform.forward;
        Vector3 dir2 = Quaternion.Euler(0, -_viewAngle / 2, 0) * transform.forward;
        Gizmos.DrawLine(transform.position, transform.position + dir1 * _viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + dir2 * _viewRadius);
    }
}
