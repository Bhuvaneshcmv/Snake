using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/LevelData",fileName ="LevelData")]
public class LevelData : ScriptableObject
{
    public Vector3Int boundaryLeft;
    
    public Vector3Int boundaryRight;
    
    public Vector3Int boundaryTop;
    
    public Vector3Int boundaryBottom;

    public GameObject cellPrefab;

    public List<int> backgroundTypeArray;
    public Dictionary<int, GameObject> backgroundTypeMap;


}
