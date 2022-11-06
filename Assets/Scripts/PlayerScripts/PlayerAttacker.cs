using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    private PlayerController _playerAnimator = default;
    

    private void Awake()
    {
        _playerAnimator = GetComponent<PlayerController>();
    }

    public void HandleLightAttack(WeaponItem weapon)
    {
        _playerAnimator.PlayerTargetAnimation(weapon.OH_LightAttack, true);
    }

    public void HandleHeavyAttack(WeaponItem weapon)
    {
        _playerAnimator.PlayerTargetAnimation(weapon.OH_HeavyAttack, true);
    }
}
