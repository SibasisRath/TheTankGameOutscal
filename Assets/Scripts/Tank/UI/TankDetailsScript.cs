using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TankDetailsScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tankType;
    [SerializeField] TextMeshProUGUI tankSpeed;
    [SerializeField] TextMeshProUGUI tankRotation;
    [SerializeField] TextMeshProUGUI tankHealth;
    [SerializeField] TextMeshProUGUI tankAmmunitionType;
    [SerializeField] TextMeshProUGUI tankFireCoolDown;

    [SerializeField] List<TankSO> tankSOs;

    public void ViewingTankDetails(TankTypes tankType)
    {
        foreach (TankSO tank in tankSOs)
        {
            if(tank.TankType == tankType)
            {
                UpdateTankDetails(tank);
            }
        }
    }

    private void UpdateTankDetails(TankSO tank)
    {
        tankType.text = "Type: " + tank.TankType.ToString();
        tankSpeed.text = "Speed: " + tank.TankSpeed.ToString();
        tankRotation.text = "Rotation: " + tank.TankRotation.ToString();
        tankHealth.text = "Health: " + tank.TankHealth.ToString();
        tankAmmunitionType.text = "Ammunition Type: " + tank.TankAmmunitionType.ToString();
        //tankFireCoolDown.text = "Fire Cooldown: (in sec) " + tank.FireCoolDown.ToString();
    }
}
