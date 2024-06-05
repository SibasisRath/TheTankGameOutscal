using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelection : MonoBehaviour
{
    [SerializeField] private TankSpawnerScript TankSpawnerScript;
    public void BlueTankSelected()
    {
        Debug.Log("blue tank selected.");
        TankSpawnerScript.CreateTank(TankTypes.BlueTank);
        this.gameObject.SetActive(false);
    }
    public void GreenTankSelected()
    {
        TankSpawnerScript.CreateTank(TankTypes.GreenTank);
        this.gameObject.SetActive(false);
    }
    public void RedTankSelected()
    {
        TankSpawnerScript.CreateTank(TankTypes.RedTank);
        this.gameObject.SetActive(false);
    }
}
