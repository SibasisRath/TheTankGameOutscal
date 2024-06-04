using UnityEngine;

public class TankModel
{
    private TankController tankController;

    public float movementSpeed;
    public float rotationSpeed;

    public TankTypes types;
    public Material color;

    public TankModel(float movementSpeed, float rotationSpeed, TankTypes types, Material color)
    {
        this.movementSpeed = movementSpeed;
        this.rotationSpeed = rotationSpeed;
        this.types = types;
        this.color = color;
    }

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
    
}
