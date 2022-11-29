using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator _anim = default;
    public bool _heavyAttack;
    public bool _lightAttack;
    public bool _isAttacking;
    public Vector3 move;
    public CharacterController controller;
    private PlayerMovement _playerInput = default;
    private Vector3 playerVelocity;
    private Transform _camera;
    private float _timer = 1;
    [SerializeField] private StaminaBar _staminaBar;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private AudioSource _walkSteps;
    [SerializeField] private AudioSource _runSteps;

    void Awake()
    {
        _playerInput = new PlayerMovement();
        controller = GetComponent<CharacterController>();
        _isAttacking = false;
        _heavyAttack = false;
        _lightAttack = false;
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

        if (!_isAttacking)
        {
            MovePlayer();
        }
    }

    public void MovePlayer()
    {
        Vector2 movementInput = _playerInput.PlayerMain.Move.ReadValue<Vector2>();
        move = new Vector3(movementInput.x, 0f, movementInput.y);
        move = _camera.forward * move.z + _camera.right * move.x;
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            _anim.SetFloat("VelocityZ", Mathf.Abs(move.z));
            _anim.SetFloat("Velocity", Mathf.Abs(move.x));
            _walkSteps.Play();
            if (_anim.GetFloat("VelocityZ") <= 0.5 || _anim.GetFloat("Velocity") <= 0.5)
            {
                Debug.Log("Camina");
                _walkSteps.Play();
            }
            else if (_anim.GetFloat("VelocityZ") >= 0.5 || _anim.GetFloat("Velocity") >= 0.5)
            {
                Debug.Log("Corre");
                _walkSteps.Stop();
                _runSteps.Play();
            }
            else if (_anim.GetFloat("VelocityZ") <= 0 && _anim.GetFloat("Velocity") <= 0)
            {
                Debug.Log("nah");
                _walkSteps.Stop();
                _runSteps.Stop();
            }
        }
        else
        {
            _anim.SetFloat("VelocityZ", Mathf.Abs(move.y));
            _anim.SetFloat("Velocity", Mathf.Abs(move.y));
            _walkSteps.Stop();
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    
    public void LightAttack()
    {
        if (_playerInput.PlayerMain.LightAttack.triggered && _staminaBar._currentStamina >= 20)
        {
            StartCoroutine(IsAttacking());
            _lightAttack = true;
            Debug.Log("attack");
            _anim.SetFloat("attack", 1);
            StaminaBar.instance.UseStamina(20);
        }
        else
        {
           // Debug.Log("Not Enough Stamina");
            _anim.SetFloat("attack", 0);
        }
    }

    public void HeavyAttack()
    {
        if (_playerInput.PlayerMain.HeavyAttack.triggered && _staminaBar._currentStamina >= 33)
        {
            StartCoroutine(IsAttacking());
            _heavyAttack = true;
            StartCoroutine(DeactivateParticles());
            _anim.SetFloat("Hattack", 1);
            StaminaBar.instance.UseStamina(33);
            Debug.Log("HeavyAttack");
        }
        else
        {
           // Debug.Log("Not Enough Stamina");
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

    IEnumerator IsAttacking()
    {
        _isAttacking = true;
        yield return new WaitForSeconds(1f);
        _isAttacking = false;
        _lightAttack = false;
    }
}
