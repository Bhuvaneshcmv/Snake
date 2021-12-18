using UnityEngine;
using UnityEngine.Tilemaps;
public class FoodManager : MonoBehaviour
{
    [SerializeField]
    GameObject foodPrefab;
    [SerializeField]
    Tilemap tilemap;
    Vector3Int pos;
    [SerializeField]
    LevelData levelData;

    public static FoodManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
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
        pos.x = Random.Range(levelData.boundaryLeft.x, levelData.boundaryRight.x);
        pos.y = Random.Range(levelData.boundaryTop.y, levelData.boundaryRight.y);
    }
    public void InstantiateFood()
    {
        ChooseFoodPosition();
        Instantiate(foodPrefab, tilemap.CellToWorld(pos), Quaternion.identity);
    }
}
