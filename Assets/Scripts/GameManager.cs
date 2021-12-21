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

    private void Awake()
    {
        bgTiles = new List<BgTile>();  
        CreateLevel();
    }
    void CreateLevel()
    {
        Vector3 tilePos = levelData.boundaryTopLeft;
        for (int i = 0; i < 5000;i++)
        {
            var tempTile = Instantiate(bgTileBorder,tilePos, Quaternion.identity);
            tempTile.transform.SetParent(levelParent);
            tempTile.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = i.ToString() ;
            bgTiles.Add(tempTile);
            tilePos = new Vector3(tilePos.x += 0.25f, tilePos.y,tilePos.z);
            if (tilePos.x > levelData.boundaryTopRight.x)
            {
                tilePos.x = levelData.boundaryTopLeft.y;
                tilePos = new Vector3(tilePos.x, tilePos.y-= 0.25f, tilePos.z);
            }
        }
    }
}
