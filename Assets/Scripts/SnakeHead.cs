using System;
using UnityEngine;

public class SnakeHead : SnakeCell
{
    public static Action GameOver;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver?.Invoke();
    }
}
