using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField]
    SnakeCell snakeTailPrefab;
    [SerializeField]
    SnakeCell snakeHeadPrefab;
    [SerializeField]
    Vector3 initialPos;
    
    [SerializeField]
    float distanceBetweenCells;
    [SerializeField]
    int snakeLength;
    [SerializeField]
    float snakeMoveSpeed;
    int horizontalDir;
    int verticalDir;


    List<SnakeCell> snakeCellContainer = new List<SnakeCell>();
    List<Vector3> snakeCellPostions = new List<Vector3>();

    Vector3 snakeMoveVelocity;
    WaitForSeconds waitForHalfSecond = new WaitForSeconds(0.5f);
    Vector3 tempSnakeHeadPos;

    public void SnakeInit()
    {
        horizontalDir = 1;
        verticalDir = 0;
        snakeLength = 5;
        LoadSnakeCellPositions();
        SpawnSnake();
        MoveSnake();
    }
    private void OnEnable()
    {
        Food.ateFood += AddCell;
    }

    private void OnDisable()
    {
        Food.ateFood -= AddCell;
    }
    public void DestroySnake()
    {
        foreach(var snakeCell in snakeCellContainer)
        {
            Destroy(snakeCell.gameObject);
        }
        snakeCellContainer.Clear();
        snakeCellPostions.Clear();

    }
    void Update()
    {
        GetInput();
    }

    void LoadSnakeCellPositions()
    {
        for(int i = 0;i<snakeLength;i++)
        {
            snakeCellPostions.Add(initialPos);
            initialPos -= Vector3.right* distanceBetweenCells;
        } 
    }
    
    void SpawnSnake()
    {
        for(int i=0;i< snakeLength;i++)
        {
            if (i == 0)
            {
                snakeCellContainer.Add(Instantiate(snakeHeadPrefab, gameObject.transform));
                snakeCellContainer[i].transform.localPosition = snakeCellPostions[i];
                continue;
            }
            snakeCellContainer.Add(Instantiate(snakeTailPrefab, gameObject.transform));
            snakeCellContainer[i].transform.localPosition = snakeCellPostions[i];

        }
    }

    void GetInput()
    {
        if(Input.GetKeyDown(KeyCode.W) && verticalDir == 0)
        {
            verticalDir = 1;
            horizontalDir = 0;
        }        
        if(Input.GetKeyDown(KeyCode.S) && verticalDir == 0)
        {
            verticalDir = -1;
            horizontalDir = 0;
        }        
        if(Input.GetKeyDown(KeyCode.A) && horizontalDir == 0)
        {
            verticalDir = 0;
            horizontalDir = -1;
        }       
        if(Input.GetKeyDown(KeyCode.D) && horizontalDir == 0)
        {
            verticalDir = 0;
            horizontalDir = 1;
        }
        snakeMoveVelocity.y = verticalDir;
        snakeMoveVelocity.x = horizontalDir;
    }
    
    void MoveSnake()
    {
        StartCoroutine(MoveSnakeCoroutine());        
    }

    IEnumerator MoveSnakeCoroutine()
    {
        yield return waitForHalfSecond;
        
        CalculateCellPositions();
        StartCoroutine(MoveSnakeCoroutine());
    }

    void CalculateCellPositions()
    {
        tempSnakeHeadPos = snakeCellContainer[0].transform.position;
        tempSnakeHeadPos += snakeMoveVelocity * snakeMoveSpeed;

        for (int i = 0; i < snakeCellContainer.Count; i++)
        {
            snakeCellPostions[i] = snakeCellContainer[i].transform.position;
        }

        snakeCellContainer[0].transform.position = tempSnakeHeadPos;
        for(int i = 0;i < snakeCellContainer.Count-1; i++)
        {
            snakeCellContainer[i+1].transform.position = snakeCellPostions[i];
        }
    }

    void AddCell(FoodType foodType)
    {
        snakeCellContainer.Add(Instantiate(snakeTailPrefab, gameObject.transform));
        
        snakeCellPostions.Add(snakeCellPostions[snakeCellPostions.Count - 1]);

        snakeCellContainer[snakeCellContainer.Count-1].transform.localPosition = snakeCellPostions[snakeCellContainer.Count-1];
    }
}
