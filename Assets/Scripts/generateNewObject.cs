﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateNewObject : MonoBehaviour
{
    public GameObject mug;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision) {
        mug.SetActive(true);
    }
}
