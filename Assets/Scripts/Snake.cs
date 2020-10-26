using System.Collections;
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
    int horizontalDir;
    int verticalDir;
    List<GameObject> snakeCellContainer;
    List<Vector3> snakeCellPostions;

    Vector3 snakeMoveVelocity;
    WaitForSeconds waitForHalfSecond = new WaitForSeconds(0.5f);

    // Start is called before the first frame update
    void Awake()
    {
        horizontalDir = 1;
        verticalDir = 0;
        snakeCellContainer = new List<GameObject>();
        snakeCellPostions = new List<Vector3>();
        snakeLength = 5;
        LoadSnakeCellPositions();
        SpawnSnake();
    }
    private void Start()
    {
        MoveSnake();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        
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
            snakeCellContainer.Add(Instantiate(snakeCellPrefab, gameObject.transform));
            snakeCellContainer[i].transform.localPosition = snakeCellPostions[i];
            if(i == 0)
            {
                snakeCellContainer[i].GetComponent<SpriteRenderer>().color = Color.blue;
            }
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

    private IEnumerator MoveSnakeCoroutine()
    {
        yield return waitForHalfSecond;
        snakeCellContainer[0].transform.localPosition += snakeMoveVelocity * snakeMoveSpeed;
        StartCoroutine(MoveSnakeCoroutine());
    }
}
