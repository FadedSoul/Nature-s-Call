using UnityEngine;
using System.Collections;

public class Tiles : MonoBehaviour {

    public TileType[] tileTypes;

    int[,] tiles;

    int mapsizeX = 1280;
    int mapsizeY = 720;
	// Use this for initialization
	void Start () {
        tiles = new int[mapsizeX, mapsizeY];

        for (int x = 0; x < mapsizeX; x++)
        {
            for (int y = 0; y < mapsizeY; y++)
            {
                tiles[x, y] = 0;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
