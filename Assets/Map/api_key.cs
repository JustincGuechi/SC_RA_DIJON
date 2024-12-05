using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using CesiumForUnity;

public class api_key : MonoBehaviour
{
    public Cesium3DTileset tileset;
    void Start()
    {
        string apiKey = GetApiKey();
        if (apiKey != null)
        {
            string url = $"https://tile.googleapis.com/v1/3dtiles/root.json?key={apiKey}";
            if (tileset != null)
            {
                tileset.url = url;
            }
            else
            {
                Debug.LogError("Cesium3DTileset component not found");
            }
        }
    }

    string GetApiKey()
    {
        string path = Application.dataPath + "/Map/api_key.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ApiKeyData data = JsonUtility.FromJson<ApiKeyData>(json);
            return data.google_maps_api_key;
        }
        else
        {
            Debug.LogError("API key file not found");
            return null;
        }
    }

    [System.Serializable]
    private class ApiKeyData
    {
        public string google_maps_api_key;
    }

    void Update()
    {
        
    }
}
