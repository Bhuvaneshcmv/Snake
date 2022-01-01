using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] BgTileBorder bgTileBorder;
    [SerializeField] BgTileNormal bgTileNormal;
    
    List<BgTile> bgTiles;

    [SerializeField] Transform levelParent;
    [SerializeField] LevelData levelData;
    [SerializeField] Vector3 deltaTilePos;

    [SerializeField] List<GameObject>gameplayElements;
    [SerializeField] List<GameObject>gameOverElements;


    public void OnEnable()
    {
        SnakeHead.GameOver += GameOver;
    }
    public void OnDisable()
    {
        SnakeHead.GameOver -= GameOver;
    }
    private void Awake()
    {
        bgTiles = new List<BgTile>();
        GameInit();
        
    }

    void CreateLevel()
    {
        
        Vector3 tilePos = levelData.boundaryTopLeft;
        BgTile tempTile;

        for (int i = 0; i < 5000;i++)
        {
            if (tilePos.x == levelData.boundaryTopLeft.x || tilePos.x == levelData.boundaryBottomRight.x 
                || tilePos.y == levelData.boundaryTopLeft.y || tilePos.y == levelData.boundaryBottomRight.y)
            {
                tempTile = Instantiate(bgTileBorder, tilePos, Quaternion.identity);
            }
            else
            {
                tempTile = Instantiate(bgTileNormal, tilePos, Quaternion.identity);
            }

            tempTile.transform.SetParent(levelParent);
            bgTiles.Add(tempTile);
            tempTile.index = i;
            tempTile.position = tilePos;

            tilePos = new Vector3(tilePos.x += deltaTilePos.x, tilePos.y,tilePos.z);

            if (tilePos.x > levelData.boundaryTopRight.x)
            {
                tilePos.x = levelData.boundaryTopLeft.x;
                tilePos = new Vector3(tilePos.x, tilePos.y -= deltaTilePos.y, tilePos.z);
                if (tilePos.y < levelData.boundaryBottomLeft.y)
                    return;
            }
        }
    }

    void GameInit()
    {
        for (int i = 0; i < gameplayElements.Count; i++)
        {
            gameplayElements[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < gameOverElements.Count; i++)
        {
            gameOverElements[i].gameObject.SetActive(false);
        }
        CreateLevel();
    }
    void GameOver()
    {
        for (int i = 0; i < gameplayElements.Count; i++)
        { 
            gameplayElements[i].gameObject.SetActive(false);
        }
        for(int i = 0;i< gameOverElements.Count;i++)
        {
            gameOverElements[i].gameObject.SetActive(true); 
        }
    }
}
