using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfDay : MonoBehaviour
{
    public GameObject environment;
    public Transform[] collectibles;
    public GameObject collectibleContainer;
    public GameObject leftBehindContainer;

    // Start function
    void Start()
    {
        // Reference the terrain generator script
        TerrainGenerator terrainGeneratorScript = environment.GetComponent<TerrainGenerator>();
        collectibles = terrainGeneratorScript.obstacles;

        // Render collectibles
        RenderCollected(collectibles);
    }

    // Render and add collected items to the collectible container
    public void RenderCollected(Transform[] collected)
    {
        // Loop through the collectibles
        for (int i = 0; i < collected.Length; i++)
        {
            // Instantiate the collectible
            GameObject collectible = Instantiate(collected[i].gameObject, collected[i].position, collected[i].rotation);
            // Set the collectible parent to the collectible container
            collectible.transform.SetParent(collectibleContainer.transform, true);
            // Set the layer of the collectible to the UI layer
            collectible.layer = 5;
        }
    }
}
