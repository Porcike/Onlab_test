using System.IO;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ImageLoader : MonoBehaviour
{
    public List<Texture2D> Textures { get; private set; }

    void Start()
    {
        Textures = new List<Texture2D>();
        LoadTextures();
    }

    private void LoadTextures()
    {
        var directoryPath = "Assets/Marker";
        var filePaths = Enumerable.Concat(
                Directory.GetFiles(directoryPath, "*.png").ToList(),
                Directory.GetFiles(directoryPath, "*.jpg").ToList()
        ).ToList();

        foreach(var filePath in filePaths)
        {
            byte[] filedata = File.ReadAllBytes(filePath);
            Texture2D texture = new Texture2D(2, 2);

            if(texture.LoadImage(filedata))
            {
                Debug.Log(filePath + " successfully loaded.");
                Textures.Add(texture);
            }
            else
            {
                Debug.Log(filePath + " couldn't be loaded.");
            }
        }
    }
}