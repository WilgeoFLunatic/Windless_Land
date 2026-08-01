using UnityEngine;
using UnityEngine.InputSystem;

public class ChargeWind : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _chargeAction;
    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _chargeAction = _playerInput.actions["Charge"];
    }
    void Update()
    {
        if (_chargeAction.IsPressed())
        {
            GetComponent<CastWind>().windPower = 6;
        }
        else
        {
            GetComponent<CastWind>().windPower = 3;
        }
    }
}
