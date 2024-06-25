using UnityEngine;

[CreateAssetMenu(fileName = "RangeBasedShootingBehavior", menuName = "ScriptableObjects/ShootingBehavior/RangeBased")]
public class RangeBasedShootingBehavior : BaseShootingBehavior
{
    public float maxChargeTime = 2f;
    private float chargeTime;

    public override bool Shoot(out float range)
    {
        //Debug.Log("In Shoot method.");
        range = 0;

        // Check for initial mouse button press
        if (Input.GetMouseButtonDown(0))
        {
            chargeTime = 0f;
           // Debug.Log("Mouse button down, start charging.");
        }

        // Check for continuous mouse button press
        if (Input.GetMouseButton(0))
        {
            chargeTime += Time.deltaTime;
           // Debug.Log($"Charging: {chargeTime}");
        }

        // Check for mouse button release
        if (Input.GetMouseButtonUp(0))
        {
            range = Mathf.Clamp(chargeTime / maxChargeTime, 0f, 1f);
            range = Mathf.Lerp(3f, 5f, range);
            Debug.Log($"Fire with power: {range}");
            chargeTime = 0f;
            return true;
        }

        // If none of the conditions met, return false
        //Debug.Log("Mouse button not released yet.");
        return false;
    }
}
