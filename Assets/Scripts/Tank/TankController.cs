using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TankController
{
    private readonly TankModel tankModel;
    private readonly TankView tankView;

    private readonly Rigidbody rb;

   // private AmmunitionController ammunitionController;
    private readonly AmmunitionSpawner ammunitionSpawner;

    private EnemyView enemyView = null;
    private float selectedRange = 0f;

    public TankController(TankModel tankModel, TankView tankPrefab, AmmunitionSpawner ammunitionSpawner)
    {
        this.tankModel = tankModel;
        this.tankView = GameObject.Instantiate(tankPrefab);
        rb = this.tankView.GetRigidbody();

        this.tankView.SetTankController(this);
        this.tankView.ChangeMaterials(tankModel.color);

        this.ammunitionSpawner = ammunitionSpawner;

        this.tankView.OnFire += HandleFire;
        this.tankView.OnSelectingTarget += GetTargetPosition;
        
    }

    public void Move(float movement)
    {
        rb.velocity = tankView.transform.forward * (movement * tankModel.movementSpeed);
    }

    public void Rotate(float rotation)
    {
        Vector3 vector3 = new Vector3(0f, rotation * tankModel.rotationSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector3 * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    private void GetTargetPosition()
    {
        enemyView = tankModel.shootingBehavior.SelectTarget();
    }

    private void HandleFire()
    {
        HandleAmmunitionFire();       
    }

    public void HandleAmmunitionFire()
    {
        bool res = false;
        switch (tankModel.ammunitionType)
        {
            case AmmunitionType.Guided_Missiles:
                if ( enemyView != null && tankView.IsReadyToFire)
                {
                    Debug.Log("shoot");
                    tankModel.ammunitionSO.SetSelectedEnemy(enemyView);
                    GuidedMissilesController guidedMissilesController = (GuidedMissilesController)ammunitionSpawner.SpawnAmmunition(tankModel.ammunitionSO, tankView.GetFireTransform().position, tankView.GetFireTransform().rotation);
                    guidedMissilesController.Fire();
                    tankView.StartCoroutine(FireCooldownCoroutine());
                }
                break;

            case AmmunitionType.Armour_Piercing_Rounds:
                res = tankModel.shootingBehavior.Shoot(out selectedRange);
                Debug.Log(res);
                if (res && tankView.IsReadyToFire)
                {
                    tankModel.ammunitionSO.damageMultiplier = selectedRange;
                    ArmourPiercingRoundsController armourPiercingRoundsController = (ArmourPiercingRoundsController)ammunitionSpawner.SpawnAmmunition(tankModel.ammunitionSO, tankView.GetFireTransform().position, tankView.GetFireTransform().rotation);
                    armourPiercingRoundsController.Fire();
                    tankView.StartCoroutine(FireCooldownCoroutine());
                }
                break;
            case AmmunitionType.Highly_Explosive_Rounds:
                res = tankModel.shootingBehavior.Shoot(out selectedRange);
                if (res && tankView.IsReadyToFire)
                {
                    tankModel.ammunitionSO.explosionRadiousMultiplier = selectedRange;
                    HighlyExplosiveRoundsController highlyExplosiveRoundsController = (HighlyExplosiveRoundsController)ammunitionSpawner.SpawnAmmunition(tankModel.ammunitionSO, tankView.GetFireTransform().position, tankView.GetFireTransform().rotation);
                    highlyExplosiveRoundsController.Fire();
                    tankView.StartCoroutine(FireCooldownCoroutine());
                }
                break;

            default:
                Debug.LogError("Unknown ammunition type!");
                break;
        }
    }

    private IEnumerator FireCooldownCoroutine()
    {
        tankView.IsReadyToFire = false;

        yield return new WaitForSeconds(tankModel.fireCoolDown);

        tankView.IsReadyToFire = true;
    }

    public void Unsubscribe()
    {
        this.tankView.OnFire -= HandleFire;
    }

    internal TankModel GetTankModel()
    {
        return tankModel;
    }
}
