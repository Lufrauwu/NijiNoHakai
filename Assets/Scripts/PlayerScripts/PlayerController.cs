using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _playerInput = default;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform _camera;
    private float _timer = 1;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField]  private float gravityValue = -9.81f;
    [SerializeField] private Animator _anim = default;
    private GameManager _gameManager = default;


    void Awake()
    {
        _playerInput = new PlayerMovement();
        controller = GetComponent<CharacterController>();
        _gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        transform.position = _gameManager._lastCheckpointPos;
    }

    void OnEnable()
    {
        _playerInput.Enable();
    }

    void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Start()
    {
        _camera = Camera.main.transform;
    }

    void Update()
    {
        LightAttack();
        HeavyAttack();
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movementInput = _playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);
        Dash();
        
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            _anim.SetFloat("walking", 1);
        }
        else
        {
            _anim.SetFloat("walking", 0);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void LightAttack()
    {
        if (_playerInput.PlayerMain.LightAttack.triggered)
        {
            Debug.Log("attack");
            _anim.SetFloat("attack", 1);
        }
        else
        {
            _anim.SetFloat("attack", 0);
        }
    }

    public void HeavyAttack()
    {
        if (_playerInput.PlayerMain.HeavyAttack.triggered)
        {
            Debug.Log("HeavyAttack");
            _anim.SetFloat("Hattack", 1);
        }
        else
        {
            _anim.SetFloat("Hattack", 0);
        }
    }

    void Dash()
    {
        if (_playerInput.PlayerMain.Jump.triggered)
        {
            _timer += 1;
            for (int i = 0; i < 2; i++)
            {
                
                print("Active");
                playerVelocity.x = 1;
                controller.Move(playerVelocity * Time.deltaTime);
            }
        }
    }
}
