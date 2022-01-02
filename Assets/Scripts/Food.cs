using System;
using UnityEngine;

public class Food : MonoBehaviour
{
    public static Action<FoodType> ateFood;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ateFood?.Invoke(FoodType.normal);
        Destroy(gameObject);
    }
}
