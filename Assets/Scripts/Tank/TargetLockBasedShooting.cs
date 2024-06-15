using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTargetLockBasedShootingBehavior", menuName = "ScriptableObjects/ShootingBehavior/TargetLockedBased")]
public class TargetLockBasedShooting : ShootingBehavior
{
    private GameObject target;
    private bool isShootSuccessful;

    public override bool Shoot(TankView tankView)
    {
        isShootSuccessful = false;
        if (Input.GetMouseButtonDown(1))
        {
            // Try to lock on to a target
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    target = hit.collider.gameObject;
                    Debug.Log("Target Locked");
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && target != null)
        {
            isShootSuccessful = true;
            // Fire at the locked target
            Debug.Log("Fire at locked target");
            // Implement the logic to fire at the target
        }

        return isShootSuccessful;
    }
}