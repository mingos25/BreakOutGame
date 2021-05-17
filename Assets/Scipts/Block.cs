using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int Hits = 1;
    public int ScoreValue = 100;

    public void OnHit()
    {
        Hits--;
        
        if (Hits <= 0)
        {
            FindObjectOfType<GameController>().AddScore(ScoreValue);
            Destroy(gameObject);
        }
    }
}