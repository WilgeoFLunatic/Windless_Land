using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public Vector2 bottom0ffset;

    public float checkRaduis;

    public LayerMask groundLayer;

    public bool isGround;

    private void Update()
    {
        Check();
    }


    public void Check()
    {
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + bottom0ffset, checkRaduis, groundLayer);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottom0ffset, checkRaduis);
    }

}
