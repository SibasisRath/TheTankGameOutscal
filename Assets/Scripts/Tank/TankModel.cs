using UnityEngine;

public class TankModel
{
    private TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;

    public TankTypes types;
    public Material color;

    public TankAmmunitionTypes typesAmmunitionType;
    public ShootingBehavior shootingBehavior;
    public float fireCoolDown;

    public TankModel(float movementSpeed, float rotationSpeed, TankTypes types, Material color, float fireCoolDown, TankAmmunitionTypes typesAmmunitionType, ShootingBehavior shootingBehavior)
    {
        this.movementSpeed = movementSpeed;
        this.rotationSpeed = rotationSpeed;
        this.types = types;
        this.color = color;
        this.fireCoolDown = fireCoolDown;
        this.typesAmmunitionType = typesAmmunitionType;
        this.shootingBehavior = shootingBehavior;
    }

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
    
}
