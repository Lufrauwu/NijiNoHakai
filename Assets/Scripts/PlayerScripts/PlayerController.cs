using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool _heavyAttack = true;
    private PlayerMovement _playerInput = default;
    private FieldOfView _fov;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float _timer = 1;
    [SerializeField] private Transform _camera;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private Animator _anim = default;

    void Awake()
    {
        _playerInput = new PlayerMovement();
        controller = GetComponent<CharacterController>();
        _fov = GetComponent<FieldOfView>();
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
        //_bfSwordParticles.SetActive(false);
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
        //Dash();
        
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
            _heavyAttack = true;
            StartCoroutine(DeactivateParticles());
            _anim.SetFloat("Hattack", 1);
            Debug.Log("HeavyAttack");
        }
        else
        {
            _anim.SetFloat("Hattack", 0);
        }
    }

    //  WIP
    /*public void LockOn()
    {
        if (_playerInput.PlayerMain.LockOn.triggered && _fov._canSeeEnemies)
        {
            
        }
    }*/

    IEnumerator DeactivateParticles()
    {
        yield return new WaitForSeconds(1.5f);
        _heavyAttack = false;
    }
}
