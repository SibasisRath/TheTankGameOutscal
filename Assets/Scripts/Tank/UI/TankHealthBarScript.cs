using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealthBarScript : MonoBehaviour
{
    // need a camera ref
    // need initial and updated health values
    private Camera m_Camera;
    [SerializeField] private Slider healthSlider;
    private float m_Health;

    private void Start()
    {
        m_Camera = Camera.main;
        m_Health = 500;
    }
}
