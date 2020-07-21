using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;

    public int points = 0;

    private void Awake()
    {
        sharedInstance = this;
    }
}
