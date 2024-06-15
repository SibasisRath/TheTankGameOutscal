using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "NewTank", menuName = "ScriptableObjects/Tank")]
public class TankSO : ScriptableObject
{
    [Header("Appearance")]
    [SerializeField] private TankTypes tankType;
    [SerializeField] private Material tankColor;

    [Header("Health")]
    [SerializeField] private int tankHealth;

    [Header("Movement")]
    [SerializeField] private float tankSpeed;
    [SerializeField] private float tankRotation;

    [Header("Ammunition")]
    [SerializeField] private TankAmmunitionTypes tankAmmunitionType;
    [SerializeField] private ShootingBehavior tankShootingBehavior;
    [SerializeField] private float fireCoolDown;

    public TankTypes TankType => tankType;
    public Material TankColor => tankColor;
    public int TankHealth => tankHealth;
    public float TankSpeed => tankSpeed;
    public float TankRotation => tankRotation;
    public TankAmmunitionTypes TankAmmunitionType => tankAmmunitionType;
    public ShootingBehavior TankShootingBehavior => tankShootingBehavior;
    public float FireCoolDown => fireCoolDown;
}
