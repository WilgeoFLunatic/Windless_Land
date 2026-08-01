using UnityEngine;

public class WindCell : MonoBehaviour
{

    public Vector2 direction;
    public float power;

    public float duration = 0.5f;

    public GameObject windPrefab;


    private bool isBlock = false;




    void Start()
    {
        Destroy(gameObject, duration);
    }


    public void SetWind(
        Vector2 dir,
        float strength,
        GameObject prefab
    )
    {
        direction = dir.normalized;
        power = strength;
        windPrefab = prefab;
    }


    private void OnDestroy()
    {
        // 防止场景关闭或者编辑器删除时报错
        if (!Application.isPlaying)
            return;


        // 被阻挡或者已经没有强度
        if (isBlock || power <= 1)
            return;


        Vector3 nextPos =
            transform.position +
            (Vector3)direction;


        GameObject obj = Instantiate(
            windPrefab,
            nextPos,
            Quaternion.identity
        );


        WindCell nextWind =
            obj.GetComponent<WindCell>();


        nextWind.SetWind(
            direction,
            power - 1,
            windPrefab
        );
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        var receiver =
            other.GetComponent<IWindReceiver>();

        if (receiver != null)
        {
            receiver.ReceiveWind(
                direction,
                power
            );
        }


        if (other.GetComponent<IWindBlocker>() != null)
        {
            isBlock = true;
        }
    }
}