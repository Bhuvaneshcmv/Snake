using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] 
    BgTileBorder bgTileBorder;
    [SerializeField] 
    BgTileNormal bgTileNormal;
    
    List<BgTile> bgTiles;

    [SerializeField]
    Transform levelParent;
    [SerializeField]
    LevelData levelData;
    [SerializeField]
    Vector3 deltaTilePos;

    private void Awake()
    {
        bgTiles = new List<BgTile>();  
        CreateLevel();
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
}
