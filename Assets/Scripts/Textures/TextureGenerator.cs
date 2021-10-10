using Data;
using UnityEngine;

namespace Textures {
  public static class TextureGenerator {
    public static Texture2D GetTexture(int width, int height, Tile[,] tiles) {
      var texture = new Texture2D(width, height);
      var pixels = new Color[width * height];

      for (int i = 0; i < width; i++) {
        for (int j = 0; j < height; j++) {
          float value = tiles[i, j].HeightValue;
          pixels[i + j * width] = Color.Lerp(Color.black, Color.white, value);
        }
      }
      texture.SetPixels(pixels);
      texture.wrapMode = TextureWrapMode.Clamp;
      texture.Apply();
      return texture;
    }
    
    
  }
}