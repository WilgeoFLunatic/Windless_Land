using UnityEngine;
using UnityEngine.InputSystem;

public class CastWind : MonoBehaviour
{

    public GameObject windPrefab;
    public Transform _transform;
    private Vector3 playerPos;
    private PlayerInput _playerInput;
    private InputAction _attackAction;
    private InputAction _selfCastAction;
    private bool isSelfCast = false;
    public int windPower = 3;
    private float timer = 0;
    public float castCoolDown = 0.5f;

    void Awake()
    {
        playerPos = _transform.localPosition;
        _playerInput = GetComponent<PlayerInput>();
        _attackAction = _playerInput.actions["Attack"];
        _selfCastAction = _playerInput.actions["SelfCast"];
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (_attackAction.triggered)
        {
            if (_selfCastAction.IsPressed())
            {
                isSelfCast = true;
            }
            else
            {
                isSelfCast = false;
            }

            if (timer >= castCoolDown && !isSelfCast)
            {
                int posSetup = 1;
                TryCast(posSetup);
                timer = 0;
            }
            else if (timer >= castCoolDown && isSelfCast)
            {
                int posSetup = 0;
                TryCast(posSetup);
                timer = 0;
            }
        }

    }

    void TryCast(int posSetup)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0;


        Vector2 mouseDirection = mousePos - transform.position;


        Vector2 windDirection;


        // 判断四方向
        if (Mathf.Abs(mouseDirection.x) > Mathf.Abs(mouseDirection.y))
        {
            windDirection = mouseDirection.x > 0
                ? Vector2.right
                : Vector2.left;
        }
        else
        {
            windDirection = mouseDirection.y > 0
                ? Vector2.up
                : Vector2.down;
        }

        //summon single wind
        Vector3 spawnPos = transform.position + (Vector3)windDirection * posSetup + (Vector3)windDirection * 0.1f;
        GameObject obj = Instantiate(windPrefab, spawnPos, Quaternion.identity);
        WindCell wind = obj.GetComponent<WindCell>();
        if (wind != null)
        {
            wind.SetWind(windDirection, windPower, windPrefab);
        }

        /*
        // summon continues wind
        for (int i = 0; i < windPower; i++)
        {
            Vector3 spawnPos = transform.position + (Vector3)windDirection * (i + posSetup);


            GameObject obj = Instantiate(
                windPrefab,
                spawnPos,
                Quaternion.identity
            );


            WindCell wind = obj.GetComponent<WindCell>();

            if (wind != null)
            {
                // 强度递减
                wind.SetWind(
                    windDirection,
                    windPower - i
                );
            }
        }
        */

    }
}
