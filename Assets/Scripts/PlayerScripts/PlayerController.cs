using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool _heavyAttack = true;
    private PlayerMovement _playerInput = default;
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform _camera;
    private float _timer = 1;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private Animator _anim = default;
    public Vector3 move;

    void Awake()
    {
        _playerInput = new PlayerMovement();
        controller = GetComponent<CharacterController>();
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
        move = new Vector3(movementInput.x, 0f, movementInput.y);
        move = _camera.forward * move.z + _camera.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);
        
        
        //Dash();
        
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            _anim.SetFloat("VelocityZ", Mathf.Abs(move.z));
            _anim.SetFloat("Velocity", Mathf.Abs(move.x));
        }
        else
        {
            _anim.SetFloat("VelocityZ", Mathf.Abs(move.y));
            _anim.SetFloat("Velocity", Mathf.Abs(move.y));
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

    public void PlayerTargetAnimation(string targetAnim, bool isInteracting)
    {
        _anim.applyRootMotion = isInteracting;
        _anim.SetBool("isInteracting", isInteracting);
        _anim.CrossFade(targetAnim, 0.2f);
    }

    IEnumerator DeactivateParticles()
    {
        yield return new WaitForSeconds(1.5f);
        _heavyAttack = false;
    }
}
