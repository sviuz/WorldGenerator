using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TerrainGenerator : MonoBehaviour {

  [SerializeField]
  private int _depth = 20;

  [SerializeField]
  private int _width = 256;

  [SerializeField]
  private int _height = 256;

  [SerializeField]
  private int scale = 20;

  private void Update() {
    Init();
  }

  private void Init() {
    Terrain terrain = GetComponent<Terrain>();
    terrain.terrainData = GenerateTerrain(terrain.terrainData);
  }

  private TerrainData GenerateTerrain(TerrainData terrainData) {
    terrainData.heightmapResolution = _width+ 1;
    terrainData.size = new Vector3(_width, _depth, _height);
    terrainData.SetHeights(0,0,GenerateHeights());
    return terrainData;
  }

  private float[,] GenerateHeights() {
    float[,] heights = new float[_width, _height];
    for (int x = 0; x < _width; x++) {
      for (int y = 0; y < _height; y++) {
        heights[x, y] = CalculateHeight(x,y);
      }
    }

    return heights;
  }

  private float CalculateHeight(int x, int y) {
    float xCoord = (float)x / _width * scale;
    float yCoord = (float)y / _width * scale;
    return Mathf.PerlinNoise(xCoord, yCoord);
  }
}