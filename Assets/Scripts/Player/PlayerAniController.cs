using UnityEngine;

public class PlayerAniController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator _animator;
    private PhysicsCheck _physicsCheck;
    void Awake()
    {
        _physicsCheck = GetComponent<PhysicsCheck>();
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        SetAnimation();
    }

    void SetAnimation()
    {
        _animator.SetFloat("velocityX", Mathf.Abs(rb.linearVelocityX));
        _animator.SetFloat("velocityY", rb.linearVelocityY);
        _animator.SetBool("isGround", _physicsCheck.isGround);
    }
}
