using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRangeBasedShootingBehavior", menuName = "ScriptableObjects/ShootingBehavior/RangedBased")]
public class RangeBasedShooting : ShootingBehavior
{
    public float maxChargeTime = 2f;
    private float chargeTime;
    private bool isShootSuccessful;

    public override bool Shoot(TankView tankView)
    {
        isShootSuccessful = false;
        if (Input.GetMouseButtonDown(0))
        {
            chargeTime = 0f;
        }

        if (Input.GetMouseButton(0))
        {
            chargeTime += Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            float power = Mathf.Clamp(chargeTime / maxChargeTime, 0f, 1f);
            // Fire a powerful shot based on chargeTime
            Debug.Log($"Fire with power: {power}");
            chargeTime = 0f;
            isShootSuccessful = true;
        }
        return isShootSuccessful;
    }
}