using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/LevelData",fileName ="LevelData")]
public class LevelData : ScriptableObject
{
    public Vector3 boundaryLeft;
    
    public Vector3 boundaryRight;
    
    public Vector3 boundaryTop;
    
    public Vector3 boundaryBottom;

    public GameObject bgTilePrefab;

    public List<int> backgroundTypeArray;
    public Dictionary<int, GameObject> backgroundTypeMap;


}
