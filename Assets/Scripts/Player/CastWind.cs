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
    public int defaultWindPower = 3;
    public int windPower;
    private float timer = 0;
    public float castCoolDown = 0.5f;
    private PlayerAniController _playerAniController;
    public bool isCast;
    private PlayerController _playerController;
    private Rigidbody2D rb;

    public float selfCastWindPowerBouns = 1;
    void Awake()
    {
        windPower = defaultWindPower;
        playerPos = _transform.localPosition;
        _playerInput = GetComponent<PlayerInput>();
        _playerAniController = GetComponent<PlayerAniController>();
        _playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
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
                //ModifyWindLayer(isSelfCast);
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
                TrySelfCast();
                TryCast(posSetup);
                timer = 0;
            }
            /*
            else if (timer >= castCoolDown && isSelfCast)
            {
                int posSetup = 0;
                ModifyWindLayer(isSelfCast);
                TryCast(posSetup);
                timer = 0;
            }
            */
        }

    }
    void ModifyWindLayer(bool isSelf)
    {
        if (isSelf)
        {
            windPrefab.GetComponent<Collider2D>().excludeLayers = 0;
        }
        else
        {
            windPrefab.GetComponent<Collider2D>().excludeLayers = LayerMask.GetMask("Player");
        }
    }
    private void TrySelfCast()
    {
        _playerAniController.PlayerAttack();
        PlayCastAudio();
        isCast = true;
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

        rb.AddForce(windDirection * selfCastWindPowerBouns * windPower, ForceMode2D.Impulse);

    }

    void TryCast(int posSetup)
    {
        _playerAniController.PlayerAttack();
        PlayCastAudio();
        isCast = true;

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

        _playerController.vector3Meta = new Vector3(windDirection.x == 0 ? _playerController.vector3Meta.x : windDirection.x, 1, 1);

        //summon single wind
        Vector3 spawnPos = transform.position + (Vector3)windDirection * posSetup * 0.75f + Vector3.up * 0.5f;

        float angle = Mathf.Atan2(windDirection.y, windDirection.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        GameObject obj = Instantiate(windPrefab, spawnPos, rotation);

        WindCell wind = obj.GetComponent<WindCell>();
        if (wind != null)
        {
            wind.SetWind(windDirection, windPower, windPrefab);
        }
        //reset Power
        GetComponent<ChargeWind>().chargeLv = 0;
        windPower = defaultWindPower;

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

    private void PlayCastAudio()
    {
        GetComponent<AudioDefination>().PlayAudioClip();
    }
}
