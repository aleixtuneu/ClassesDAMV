using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions inputActions;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _shootPoint;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
        _shootPoint = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _rb.linearVelocity = context.ReadValue<Vector2>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
