using UnityEngine;

public abstract class AmmunitionView : MonoBehaviour
{
    protected AmmunitionController ammunitionController;

    [SerializeField] protected MeshRenderer ammunitionViewRenderer;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected Collider colider;

    public void SetAmmunitionController(AmmunitionController controller)
    {
        ammunitionController = controller;
    }

    public abstract void ShowAmmunitionTrail();

    public abstract void ShowFireEffect();
    public abstract void ShowExplosionEffect();
    public abstract void PlaySoundEffect();

    public abstract void DeactivateAmmunition();
}