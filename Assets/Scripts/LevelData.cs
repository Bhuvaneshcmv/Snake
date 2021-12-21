using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/LevelData",fileName ="LevelData")]
public class LevelData : ScriptableObject
{
    public Vector3 boundaryTopLeft;
    
    public Vector3 boundaryTopRight;
    
    public Vector3 boundaryBottomLeft;
    
    public Vector3 boundaryBottomRight;

    public GameObject bgTilePrefab;

    public List<int> backgroundTypeArray;
    public Dictionary<int, GameObject> backgroundTypeMap;


}
