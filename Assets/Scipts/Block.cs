using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    public int Hits = 1;
    public int ScoreValue = 100;

    GameController gameController;

    public AudioClip OnBreakAudio;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void OnHit()
    {
        Hits--;
        
        if (Hits <= 0)
        {
            gameController.AddScore(ScoreValue);
            gameController.AudioController.PlayCLip(OnBreakAudio);

            /*if (Random.Range(0,10) == 0)
            {*/
                gameController.SpawnPrefab(transform.position);
            /*}*/

            Instantiate(gameController.ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}