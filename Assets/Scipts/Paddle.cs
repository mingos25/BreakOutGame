using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float MoveSpeed;

    GameObject ball;

    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        ball = FindObjectOfType<Ball>().gameObject;
    }

    public void Move(Vector2 _direction)
    {
        transform.Translate(_direction * MoveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Pickup pickup = collision.transform.GetComponent<Pickup>();
        if (pickup)
        {
            if (pickup.PickUpType == Pickup.ePickUpType.Extralife)
            {
                gameController.AddLife();
            }
            
            Destroy(pickup.gameObject);
        }
    }
}
