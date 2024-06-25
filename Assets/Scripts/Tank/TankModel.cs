using UnityEngine;

public class TankModel
{
    private TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;

    public TankTypes types;
    public Material color;

    public AmmunitionType ammunitionType;
    public BaseShootingBehavior shootingBehavior;
    public AmmunitionSO ammunitionSO;
    public float fireCoolDown;

    public TankModel(TankSO tankSO)
    {
        this.movementSpeed = tankSO.TankSpeed;
        this.rotationSpeed = tankSO.TankRotation;
        this.types = tankSO.TankType;
        this.color = tankSO.TankColor;
        this.ammunitionType = tankSO.TankAmmunitionType;
        this.shootingBehavior = tankSO.ShootingBehavior;
        this.ammunitionSO = tankSO.AmmunitionSO;
        this.fireCoolDown = tankSO.FireCoolDown;
    }

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
    
}
