using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GuidedMissilesShootingBehavior", menuName = "ScriptableObjects/ShootingBehavior/GuidedMissiles")]
public class GuidedMissilesShootingBehavior : BaseShootingBehavior
{
    public override EnemyView SelectTarget()
    {
        EnemyView lockedTarget = null;
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                lockedTarget = hit.collider.gameObject.GetComponent<EnemyView>();
                if (lockedTarget != null)
                {
                    Debug.Log("Target Locked");
                }
            }
        }
        return lockedTarget;
    }
}
