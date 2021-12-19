using UnityEngine;

public class FoodManager : MonoBehaviour
{
    [SerializeField]
    GameObject foodPrefab;
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
        ChooseFoodPosition();
    }
    void ChooseFoodPosition()
    {
        //pos = Vector3Int.zero;
        //pos.x = Random.Range(levelData.boundaryLeft.x, levelData.boundaryRight.x);
        //pos.y = Random.Range(levelData.boundaryTop.y, levelData.boundaryRight.y);
    }
    public void InstantiateFood()
    {
        ChooseFoodPosition();
    }
}
