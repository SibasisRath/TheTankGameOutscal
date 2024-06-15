using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private TankModel tankModel;

    private float movement;
    private float rotation;

    private bool isReadyToFire;
    public event Action OnFire;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private MeshRenderer[] children;

    private Vector3 tagetCameraPosition;
    private Quaternion tagetCameraRotation;
    private const float transitionDuration = 2f;

    public bool IsReadyToFire { get => isReadyToFire; set => isReadyToFire = value; }

    private void Awake()
    {
        IsReadyToFire = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LerpCameraPositionAndRotation());
        tankModel = tankController.GetTankModel();
    }

    IEnumerator LerpCameraPositionAndRotation()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
        tagetCameraPosition = new Vector3(0, 15, -10);
        tagetCameraRotation = Quaternion.Euler(50, 0, 0);
        Vector3 startPosition = cam.transform.position;
        Quaternion startRotation = cam.transform.rotation;

        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            cam.transform.SetPositionAndRotation(
                Vector3.Lerp(startPosition, tagetCameraPosition, elapsedTime / transitionDuration),
                Quaternion.Slerp(startRotation, tagetCameraRotation, elapsedTime / transitionDuration));

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position and rotation are set
        cam.transform.SetPositionAndRotation(tagetCameraPosition, tagetCameraRotation);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (movement != 0)
        {
            tankController.Move(movement, tankModel.movementSpeed);
        }

        if (rotation != 0)
        {
            tankController.Rotate(rotation, tankModel.rotationSpeed);
        }
        OnFire?.Invoke();

        //tankModel.shootingBehavior.Shoot(this);
    }
    private void Movement()
    {
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
    }

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }

    public Rigidbody GetRigidbody()
    {
    return rb;
    }

    public void ChangeMaterials(Material color)
    {
        foreach (MeshRenderer child in  children)
        {
            child.material = color;
        }
    }

    private void OnDestroy()
    {
        tankController?.Unsubscribe();
    }
}
