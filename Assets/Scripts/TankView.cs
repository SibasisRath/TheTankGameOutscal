using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;

    private float movement;
    private float rotation;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private MeshRenderer[] children;

    private Vector3 tagetCameraPosition;
    private Quaternion tagetCameraRotation;
    private const float transitionDuration = 2f;

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
            cam.transform.position = Vector3.Lerp(startPosition, tagetCameraPosition, elapsedTime / transitionDuration);
            cam.transform.rotation = Quaternion.Slerp(startRotation, tagetCameraRotation, elapsedTime / transitionDuration);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final position and rotation are set
        cam.transform.position = tagetCameraPosition;
        cam.transform.rotation = tagetCameraRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (movement != 0)
        {
            tankController.Move(movement, tankController.GetTankModel().movementSpeed);
        }

        if (rotation != 0)
        {
            tankController.Rotate(rotation, tankController.GetTankModel().rotationSpeed);
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
}
