using UnityEngine;

public class PlayerAniController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator _animator;
    private PhysicsCheck _physicsCheck;
    private PlayerController _playerController;
    private CastWind _castWind;
    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _physicsCheck = GetComponent<PhysicsCheck>();
        _castWind = GetComponent<CastWind>();
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        SetAnimation();
    }

    public void SetAnimation()
    {
        _animator.SetFloat("velocityX", Mathf.Abs(rb.linearVelocityX));
        _animator.SetFloat("velocityY", rb.linearVelocityY);
        _animator.SetBool("isGround", _physicsCheck.isGround);
        _animator.SetBool("isDead", _playerController.isDead);
        _animator.SetBool("isAttack", _castWind.isCast);
    }

    public void PlayerAttack()
    {
        _animator.SetTrigger("attack");
    }
}
