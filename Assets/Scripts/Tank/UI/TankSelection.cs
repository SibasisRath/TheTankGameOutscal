using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSelection : MonoBehaviour
{
    [SerializeField] private TankSpawnerScript TankSpawnerScript;
    public void OnBlueTankSelected()
    {
        TankSpawnerScript.CreateTank(TankTypes.Blue_Tank);
        this.gameObject.SetActive(false);
    }

    public void OnGreenTankSelected()
    {
        TankSpawnerScript.CreateTank(TankTypes.Green_Tank);
        this.gameObject.SetActive(false);
    }

    public void OnRedTankSelected()
    {
        TankSpawnerScript.CreateTank(TankTypes.Red_Tank);
        this.gameObject.SetActive(false);
    }
}
