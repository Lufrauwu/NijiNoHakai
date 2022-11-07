using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraControl : MonoBehaviour
{
    [SerializeField] private float _lookSpeed = 1;
    private CinemachineFreeLook _camera;
    private PlayerMovement _playerInput;
    
    void Awake()
    {
        _playerInput = new PlayerMovement();
        _camera = GetComponent<CinemachineFreeLook>();
    }
    
    void OnEnable()
    {
        _playerInput.Enable();
    }

    void OnDisable()
    {
        _playerInput.Disable();
    }

    void Update()
    {
        Vector2 delta = _playerInput.PlayerMain.Look.ReadValue<Vector2>();
        _camera.m_XAxis.Value += delta.x * _lookSpeed * Time.deltaTime;
        _camera.m_YAxis.Value += delta.y * _lookSpeed * Time.deltaTime;
    }
}
