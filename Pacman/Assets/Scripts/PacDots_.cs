﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacDots_ : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}