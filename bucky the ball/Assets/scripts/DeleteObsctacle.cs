﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObsctacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < -20f)
        {
            Destroy(gameObject);
        }
    }
}
