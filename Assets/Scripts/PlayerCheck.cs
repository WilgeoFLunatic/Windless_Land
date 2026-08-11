using UnityEngine;

public class PlayerCheck : MonoBehaviour
{
    public Transform spawnPoint;
    private Transform cameraPos;
    public float moveSpeed = 5f;

    private bool moving;
    /*
    public void SetCameraPos()
    {
        moving = true;
    }

    void Update()
    {
        if (moving)
        {
            Vector3 target = cameraPos.position;
            target.z = Camera.main.transform.position.z;

            Camera.main.transform.position = Vector3.Lerp(
                Camera.main.transform.position,
                target,
                Time.deltaTime * moveSpeed
            );

            if (Vector3.Distance(Camera.main.transform.position, target) < 0.01f)
            {
                Camera.main.transform.position = target;
                moving = false;
            }
        }
    }
*/
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            //cameraPos = collision.GetComponent<CheckPoint>().cameraPos;
            CheckPoint checkPoint = collision.gameObject.GetComponent<CheckPoint>();

            if (checkPoint != null && checkPoint.audioSet != null)
            {
                checkPoint.audioSet.SetActive(true);
            }
            spawnPoint = collision.transform;
            //SetCameraPos();
        }
    }
}
