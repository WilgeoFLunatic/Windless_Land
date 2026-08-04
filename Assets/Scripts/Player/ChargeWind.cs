using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChargeWind : MonoBehaviour
{
    public int chargeMax = 0;
    public List<float> windChargeLv = new List<float>();
    private PlayerInput _playerInput;
    private InputAction _chargeAction;
    public int chargeLv = 0;
    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _chargeAction = _playerInput.actions["Charge"];
    }
    void Update()
    {
        if (_chargeAction.triggered && chargeLv < chargeMax)
        {
            switch (chargeLv)
            {
                case 0:
                    {
                        GetComponent<CastWind>().windPower = (int)windChargeLv[0];
                        chargeLv += 1;
                        break;
                    }
                case 1:
                    {
                        GetComponent<CastWind>().windPower = (int)windChargeLv[1];
                        chargeLv += 1;
                        break;
                    }
                case 2:
                    {
                        GetComponent<CastWind>().windPower = (int)windChargeLv[2];
                        chargeLv += 1;
                        break;
                    }

            }

        }
    }


}
