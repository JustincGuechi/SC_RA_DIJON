using CesiumForUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class API_KEY : MonoBehaviour
{
    public Cesium3DTileset tileset;
    // Start is called before the first frame update
    void Start()
    {
        var cesiumApiKey = Environment.GetEnvironmentVariable("CESIUM_API_KEY");
        tileset.url = tileset.url.Replace("REMOVED_KEY", cesiumApiKey);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
