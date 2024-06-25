using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using TMPro;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;

    private float movement;
    private float rotation;

    private bool isReadyToFire = true;
    public event Action OnFire;
    public event Action OnSelectingTarget;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private MeshRenderer[] children;
    [SerializeField] private Transform fireTransform;

    public Transform GetFireTransform() {  return fireTransform; }

    private Vector3 tagetCameraPosition;
    private Quaternion tagetCameraRotation;
    private const float transitionDuration = 2f;

    private bool canPlayNow = false;

    public bool IsReadyToFire { get => isReadyToFire; set => isReadyToFire = value; }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LerpCameraPositionAndRotation());
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
        canPlayNow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlayNow)
        {
            Movement();
            SelectingTarget();
            HandelFire();
            if (movement != 0)
            {
                tankController.Move(movement);
            }

            if (rotation != 0)
            {
                tankController.Rotate(rotation);
            }
        }
    }

    private void SelectingTarget()
    {
        if (Input.GetMouseButtonDown(1) && tankController.GetTankModel().types == TankTypes.Blue_Tank)
        {
            OnSelectingTarget?.Invoke();
        }
    }

    private void HandelFire()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
        {
            OnFire?.Invoke();
        }
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
