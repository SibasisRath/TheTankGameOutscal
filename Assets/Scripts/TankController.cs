using UnityEngine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;


    private Rigidbody rb;

    public TankController( TankModel tankModel, TankView tankView)
    {
        this.tankModel = tankModel;
        this.tankView = GameObject.Instantiate<TankView>(tankView);
        rb = this.tankView.GetRigidbody();
        tankModel.SetTankController(this);
        this.tankView.SetTankController(this);
        this.tankView.ChangeMaterials(this.tankModel.color);
    }

    public void Move(float movement, float movementSpeed)
    {
        rb.velocity = tankView.transform.forward * movement * movementSpeed;
    }

    public void Rotate(float rotation, float rotationSpeed) {
        Vector3 vector3 = new Vector3(0f, rotation * rotationSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector3 * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public TankModel GetTankModel() { return tankModel; }
}
