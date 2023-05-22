using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Texture2D[] maps;
    public GameObject wallPrefab;
    public GameObject gemPrefab;
    public GameObject zombiePrefab;

    private Texture2D selectedMap;

    private List<Vector3> openPositions = new List<Vector3> (); // keep reference to open space(there is no wall)

    private Color wallColor = Color.black;

    public static MapManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start() 
    { 
        GenerateNewMap();
    }

    public void GenerateNewMap()
    { 
        openPositions.Clear(); // to not get anything from previous maps on our new map

        selectedMap = maps[Random.Range(0, maps.Length)];

        for (int x = 0; x < selectedMap.width; x++) {
            for (int y = 0; y < selectedMap.height; y++) { 
                GenerateTile(x, y);
            }
        }
    }

    private void GenerateTile(int x, int y) 
    {
        Color pixelColor = selectedMap.GetPixel(x, y);

        if (pixelColor.a == 0) // if a(alpha channel)=0 -> transparent 
        {
            openPositions.Add(new Vector3(x, 0, y));
            return;
        }

        if (pixelColor == wallColor)
            Instantiate(wallPrefab, new Vector3(x, 0, y), Quaternion.identity, transform);

    }

    private void GenerateZombies()
    {

    }

    private void GenerateGems()
    { 
    
    }
}
