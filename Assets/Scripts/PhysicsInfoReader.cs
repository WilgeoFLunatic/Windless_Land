using UnityEngine;

public class PhysicsInfoReader : MonoBehaviour
{
    // 物理组件
    private Rigidbody2D rb;
    private Collider2D col;
    private SpriteRenderer spriteRenderer;
    private Animator animator;


    // 基础属性
    public Vector2 position;
    public Vector2 velocity;
    public float speed;
    public float angularVelocity;

    public float mass;
    public bool isKinematic;
    public bool isSimulated;


    // 碰撞属性
    public bool isTrigger;
    public Vector2 colliderSize;


    // 渲染属性
    public bool spriteEnabled;
    public string currentAnimation;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        ReadTransform();
        ReadPhysics();
        ReadCollider();
        ReadRenderer();
        ReadAnimator();
    }


    private void ReadTransform()
    {
        position = transform.position;
    }


    private void ReadPhysics()
    {
        if (rb == null)
            return;


        velocity = rb.linearVelocity;

        //速度大小
        speed = rb.linearVelocity.magnitude;


        angularVelocity = rb.angularVelocity;


        mass = rb.mass;


        isKinematic = rb.bodyType == RigidbodyType2D.Kinematic;


        isSimulated = rb.simulated;
    }


    private void ReadCollider()
    {
        if (col == null)
            return;


        isTrigger = col.isTrigger;


        if (col is BoxCollider2D box)
        {
            colliderSize = box.size;
        }

        else if (col is CircleCollider2D circle)
        {
            colliderSize = Vector2.one * circle.radius;
        }
    }


    private void ReadRenderer()
    {
        if (spriteRenderer == null)
            return;


        spriteEnabled = spriteRenderer.enabled;
    }


    private void ReadAnimator()
    {
        if (animator == null)
            return;


        AnimatorStateInfo info =
            animator.GetCurrentAnimatorStateInfo(0);


        currentAnimation = info.fullPathHash.ToString();
    }



    // 在Inspector显示
    private void OnGUI()
    {
        GUILayout.BeginArea(
            new Rect(10, 10, 300, 300)
        );


        GUILayout.Label(
            "Object: " + gameObject.name
        );


        GUILayout.Label(
            "Position: " + position
        );


        GUILayout.Label(
            "Velocity: " + velocity
        );


        GUILayout.Label(
            "Speed: " + speed
        );


        GUILayout.Label(
            "Angular Velocity: "
            + angularVelocity
        );


        GUILayout.Label(
            "Mass: " + mass
        );


        GUILayout.Label(
            "Simulated: " + isSimulated
        );


        GUILayout.EndArea();
    }
}