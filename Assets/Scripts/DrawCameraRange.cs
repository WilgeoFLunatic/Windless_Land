using UnityEngine;

public class DrawCameraRange : MonoBehaviour
{
    public Vector2 cameraRange = new Vector2(21.333f, 12);
    private void OnDrawGizmosSelected()
    {
        //Gizmos.DrawWireSphere((Vector2)transform.position, checkRaduis);
        Gizmos.DrawWireCube(transform.position, cameraRange);
    }
}
