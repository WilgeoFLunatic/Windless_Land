using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float stopDistance = 0.1f;
    public Transform holdPoint;
    public float linearVelocityXDarg = 0.9f;
    //public InputSystem_Actions inputControl;
    private PlayerInput _playerInput;
    private InputAction _moveAction;

    public Vector2 inputDirection;
    public Vector2 mouseInputDirection;
    private Vector3 mousePos;
    public Vector2 facingDirection { get; private set; } = Vector2.right;
    private Rigidbody2D rb;
    public Vector3 vector3Meta = Vector3.one;
    private Vector2 vector2Meta = Vector2.one;
    private Vector3 holdPointPos = new Vector3(1, 0, 0);
    //private Animator anim;
    private bool useMouse = false;

    public bool isDead = false;
    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];

        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();

        if (_playerInput.currentControlScheme == "Mouse")
        {
            useMouse = true;
        }


    }
    void Update()
    {
        inputDirection = _moveAction.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        HandleMove();
    }
    private void HandleMove()
    {
        //Mouse Move Solution
        if (useMouse)
        {

            mousePos = Camera.main.ScreenToWorldPoint(new Vector3(inputDirection.x, inputDirection.y, Mathf.Abs(Camera.main.transform.position.z)));

            mouseInputDirection = (mousePos - transform.position).normalized;

            if ((mousePos - transform.position).magnitude < stopDistance)
            {
                rb.linearVelocity = Vector2.zero;
                return;
            }
            rb.linearVelocity = mouseInputDirection * speed;

            facingDirection = mouseInputDirection.normalized;
            if (mouseInputDirection.x > 0)
            {
                vector3Meta.x = 1;
            }
            else if (mouseInputDirection.x < 0)
            {
                vector3Meta.x = -1;
            }
            transform.localScale = vector3Meta;
        }
        //Keyboard and Gamepad Move Solution
        else
        {
            if (inputDirection.x != 0)
            {
                rb.AddForce(
                    new Vector2(inputDirection.x * speed, 0),
                    ForceMode2D.Force
                );
            }
            Vector2 velocity = rb.linearVelocity;
            velocity.x *= linearVelocityXDarg;
            rb.linearVelocity = velocity;

            //rb.linearVelocity = inputDirection * speed;
            /*
            if (inputDirection.x != 0)
            {
                rb.linearVelocity = new Vector2(
                    inputDirection.x * speed,
                    rb.linearVelocity.y
                );
            }
            */
            /*
            Vector2 velocity = rb.linearVelocity;

            if (inputDirection.x != 0)
            {
                velocity.x = inputDirection.x * speed;
            }
            else
            {
                velocity.x *= linearVelocityXDarg;
            }

            rb.linearVelocity = velocity;
            */

            if (inputDirection.x > 0)
            {
                vector3Meta.x = 1;
                facingDirection = Vector2.right;
            }
            else if (inputDirection.x < 0)
            {
                vector3Meta.x = -1;
                facingDirection = Vector2.left;

            }
            else if (inputDirection.y > 0)
            {
                facingDirection = Vector2.up;
            }
            else if (inputDirection.y < 0)
            {
                facingDirection = Vector2.down;
            }

            if (inputDirection.y != 0 && inputDirection.x != 0)
            {
                facingDirection = inputDirection.normalized;
            }

            transform.localScale = vector3Meta;
        }




    }

    public void GamePaused()
    {
        _playerInput.enabled = false;
    }
    public void GameContinues()
    {
        _playerInput.enabled = true;
    }


    public void PlayerDead()
    {
        isDead = true;
        _playerInput.enabled = false;
    }
}
