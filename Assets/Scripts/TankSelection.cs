using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelection : MonoBehaviour
{
    [SerializeField] private TankSpawnerScript TankSpawnerScript;
    public void OnBlueTankSelected()
    {
        TankSpawnerScript.CreateTank(TankTypes.BlueTank);
        this.gameObject.SetActive(false);
    }

    public void OnGreenTankSelected()
    {
        TankSpawnerScript.CreateTank(TankTypes.GreenTank);
        this.gameObject.SetActive(false);
    }

    public void OnRedTankSelected()
    {
        TankSpawnerScript.CreateTank(TankTypes.RedTank);
        this.gameObject.SetActive(false);
    }
}
