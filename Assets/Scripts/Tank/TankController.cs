using System.Collections;
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

        this.tankView.OnFire += HandleFire;
    }

    public void Move(float movement, float movementSpeed)
    {
        rb.velocity = tankView.transform.forward * (movement * movementSpeed);
    }

    public void Rotate(float rotation, float rotationSpeed) {
        Vector3 vector3 = new Vector3(0f, rotation * rotationSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector3 * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    private void HandleFire()
    {
        //Debug.Log("HandleFire called. IsReadyToFire: " + tankView.IsReadyToFire);
        if (tankView.IsReadyToFire)
        {
            //Debug.Log("Firing!");
            Fire();
        }
    }

    private void Fire()
    {
        //Debug.Log("Fire method called.");
        if (tankModel.shootingBehavior.Shoot(tankView)) 
        {
            tankView.IsReadyToFire = false;
            tankView.StartCoroutine(FireCooldownCoroutine());
        }
        return;
        
    }

    private IEnumerator FireCooldownCoroutine()
    {
        //Debug.Log("Starting cooldown coroutine. IsReadyToFire: " + tankView.IsReadyToFire);
        yield return new WaitForSeconds(tankModel.fireCoolDown);
        tankView.IsReadyToFire = true;
        //Debug.Log("Cooldown ended. IsReadyToFire: " + tankView.IsReadyToFire);
    }

    public TankModel GetTankModel() { return tankModel; }

    public void Unsubscribe()
    {
        this.tankView.OnFire -= HandleFire;
    }
}
