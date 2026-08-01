using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChargeWind : MonoBehaviour
{
    public List<float> windCharge = new List<float>();
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
            GetComponent<CastWind>().windPower = (int)windCharge[0];
        }
        else
        {
            GetComponent<CastWind>().windPower = 3;
        }
    }
}
