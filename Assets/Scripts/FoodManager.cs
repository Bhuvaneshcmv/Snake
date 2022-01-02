using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField]
    Food foodPrefab;
    Vector3Int pos;
    [SerializeField]
    LevelData levelData;

    bool foodExists;

    public static FoodManager instance;

    void OnEnable()
    {
        Food.ateFood += InstantiateFood;
    }

    private void OnDisable()
    {
        Food.ateFood -= InstantiateFood;
    }

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
        ChooseFoodPosition();
    }
    void ChooseFoodPosition()
    {
        pos = Vector3Int.zero;
        pos.x = Random.Range((int) levelData.boundaryTopLeft.x, (int) levelData.boundaryTopRight.x);
        pos.y = Random.Range((int) levelData.boundaryTopLeft.y, (int) levelData.boundaryBottomRight.y);
        Instantiate(foodPrefab, new Vector3( pos.x, pos.y, pos.z), Quaternion.identity);
    }
    public void InstantiateFood(FoodType foodType)
    {
        ChooseFoodPosition();
    }
}
