using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacDots_ : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GameManager.sharedInstance.points += 100;
            UIManager.sharedInstance.points.text = "SCORE: " + GameManager.sharedInstance.points.ToString();
            Destroy(this.gameObject);  
        }
    }
}
