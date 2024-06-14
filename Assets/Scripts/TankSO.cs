using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "NewTank", menuName = "ScriptableObjects/Tank")]
public class TankSO : ScriptableObject
{
    [SerializeField] private TankTypes tankType;
    [SerializeField] private Material tankColor;
    [SerializeField] private float tankSpeed;
    [SerializeField] private float tankRotation;
    [SerializeField] private TankFireTypes tankFireType;
    [SerializeField] private int tankFireRate;

    public TankTypes TankType => tankType;
    public Material TankColor => tankColor;
    public float TankSpeed => tankSpeed;
    public float TankRotation => tankRotation;
    public TankFireTypes TankFireType => tankFireType;
    public int TankFireRate => tankFireRate;
}
