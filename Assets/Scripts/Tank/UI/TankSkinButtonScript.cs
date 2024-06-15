using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TankSkinButtonScript : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private TankDetailsScript tankDetailsScript;
    [SerializeField] private TankTypes tankTypes;
    public void OnPointerEnter(PointerEventData eventData)
    {
        tankDetailsScript.ViewingTankDetails(tankTypes);

    }
}
