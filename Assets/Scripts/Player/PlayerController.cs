using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField]
    public PlayerModel model;
    private PlayerView _view;
    private CharacterController _ctr;
    private PlayerStateMachine _fsm;
    private Animator _animator;


    private Vector3 _horizontalMove;
    private Vector3 _verticalMove;
    private bool _grounded;
    private float _verticalVelocity;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Instance = this;
       

        _animator = transform.parent.GetComponentInChildren<Animator>();
        _view = transform.parent.GetComponentInChildren<PlayerView>();
        _ctr = transform.parent.GetComponentInChildren<CharacterController>();
        _fsm = transform.parent.GetComponentInChildren<PlayerStateMachine>();

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        ApplyGravity();
        UpdateView();
    }

    void HandleInput()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        bool space = Input.GetButtonDown("Jump");

        _horizontalMove = Camera.main.transform.forward * moveY + Camera.main.transform.right * moveX;
        _horizontalMove = _horizontalMove.normalized;
        _horizontalMove *= model.speed;
        _horizontalMove.y = 0;
        _animator.SetFloat("Speed", _horizontalMove.magnitude);



        if (Physics.Raycast(_view.transform.position , -Vector3.up, 0.3f, model.layerMask))
        {
            Debug.Log("Grounded");
            _grounded = true;
        }
        else
        {
            _grounded = false;
        }

         

        PlayerRotation();
    }

    void ApplyGravity()
    {
        // Aplicamos gravedad siempre que no estemos en el suelo
        if (!_grounded)
        {
            _verticalVelocity += model.gravity * Time.deltaTime;
        }

        // Aplicamos el movimiento vertical
        _verticalMove = new Vector3(0, _verticalVelocity, 0); 
    }

    void UpdateView()
    {
        _view.UpdateCharacter(_horizontalMove, _verticalMove);
        _view.UpdateTransform();
    }

    void PlayerRotation()
    {
        if (_horizontalMove.magnitude > 0.1f) // Rotate only when moving
        {
            float targetAngle = Mathf.Atan2(_horizontalMove.x,_horizontalMove.z) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);

            _view.transform.rotation = Quaternion.Slerp(
            _view.transform.rotation, targetRotation, Time.deltaTime * model.rotationSpeed);
        }

    }

    public bool IsGrounded()
    {
        return _grounded;
    }


}
