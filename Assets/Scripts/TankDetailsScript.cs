using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TankDetailsScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tankType;
    [SerializeField] TextMeshProUGUI tankSpeed;
    [SerializeField] TextMeshProUGUI tankRotation;
    [SerializeField] TextMeshProUGUI tankFireType;
    [SerializeField] TextMeshProUGUI tankFireRate;

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
        tankFireType.text = "Fire Type: " + tank.TankFireType.ToString();
        tankFireRate.text = "Fire Rate: " + tank.TankFireRate.ToString();
    }
}
