﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject tankPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(tankPrefab, transform.position, Quaternion.identity);
    }

}
