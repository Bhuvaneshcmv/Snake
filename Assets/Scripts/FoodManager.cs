using UnityEngine;
using UnityEngine.Tilemaps;
public class FoodManager : MonoBehaviour
{
    [SerializeField]
    GameObject foodPrefab;
    [SerializeField]
    Tilemap tilemap;
    Vector3Int pos;

    public static FoodManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        //InvokeRepeating("SpawnFood",0,5);
        ChooseFoodPosition();

    }
    void ChooseFoodPosition()
    {
        pos = Vector3Int.zero;
        pos.x = Random.Range(-14, 15);
        pos.y = Random.Range(-8, 9);

    }
    public void InstantiateFood()
    {
        ChooseFoodPosition();
        Instantiate(foodPrefab, tilemap.CellToWorld(pos), Quaternion.identity);
    }
}
