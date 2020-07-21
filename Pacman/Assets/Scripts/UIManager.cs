using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager sharedInstance;

    public Text points;

    private void Awake()
    {
        sharedInstance = this;
    }
}
