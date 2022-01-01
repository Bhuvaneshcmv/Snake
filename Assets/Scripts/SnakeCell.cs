using UnityEngine;

public class SnakeCell : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Occured");
    }
}
