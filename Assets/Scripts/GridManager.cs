using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Transform _cam;
    private Dictionary<Vector2, Tile> _tiles;

    void Start() {
        GenerateGrid();
    }

    void GenerateGrid() {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.tag = "UnclearedTile";

                // Determine if the tile is offset based on its position
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
                
                // Set the tile collider to active initially
                var tileCollider = spawnedTile.GetComponent<Collider2D>();
                if (tileCollider != null)
                {
                    tileCollider.enabled = true; // Make sure collider is active at first
                }

                //Clear Spawn Tiles
                //print( _tiles[new Vector2(x,y)]);

                // Store tile in dictionary
                _tiles[new Vector2(x, y)] = spawnedTile;
                
                
                if( _tiles[new Vector2(x,y)].name == "Tile 50 90" || _tiles[new Vector2(x,y)].name == "Tile 51 90" 
                || _tiles[new Vector2(x,y)].name == "Tile 49 90"|| _tiles[new Vector2(x,y)].name == "Tile 50 91"){
                    
                    spawnedTile.tag = "startingTile";
                    //_tiles[new Vector2(x,y)].ClearTile(true);
                }
                
            }
        }

        // Adjust camera position to fit the grid
        //_cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);
        //_cam.transform.position = player.position;
       
    }

    public Tile GetTileAtPosition(Vector2 pos) {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}