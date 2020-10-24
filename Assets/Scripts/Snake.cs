using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{

    [SerializeField]
    GameObject snakeCellPrefab;
    [SerializeField]
    Vector3 initialPos = Vector3.zero;
    [SerializeField]
    float distanceBetweenCells;
    [SerializeField]
    int snakeLength;
    [SerializeField]
    float snakeMoveSpeed;

    List<GameObject> snakeCellContainer;
    List<Vector3> snakeCellPostions;

    Vector3 snakeMoveVelocity;

    // Start is called before the first frame update
    void Awake()
    {
        snakeCellContainer = new List<GameObject>();
        snakeCellPostions = new List<Vector3>();
        snakeLength = 5;
        LoadSnakeCellPositions();
        SpawnSnake();
    }
    
    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        MoveSnakeHead();
    }

    void LoadSnakeCellPositions()
    {
        for(int i = 0;i<snakeLength;i++)
        {
            snakeCellPostions.Add(initialPos);
            initialPos -=  Vector3.right* distanceBetweenCells;
        } 
    }
    
    void SpawnSnake()
    {
        for(int i=0;i< snakeLength;i++)
        {
            snakeCellContainer.Add(Instantiate(snakeCellPrefab, this.gameObject.transform));
            snakeCellContainer[i].transform.localPosition = snakeCellPostions[i];
            if(i == 0)
            {
                snakeCellContainer[i].GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }
    }
    void GetInput()
    {
        snakeMoveVelocity.x = Input.GetAxis("Horizontal");
        snakeMoveVelocity.y = Input.GetAxis("Vertical");
    }

    void MoveSnakeHead()
    {
        snakeCellPostions[0] = snakeCellContainer[0].transform.position;
        snakeCellContainer[0].transform.Translate(snakeMoveVelocity * snakeMoveSpeed * Time.deltaTime);
    }
}
