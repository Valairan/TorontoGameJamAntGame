using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfDay : MonoBehaviour
{
    public GameObject collectedObjectContainer;
    public GameObject leftBehindObjectContainer;
    public GameObject environment;
    public GameObject player;

    // Start function
    void Start()
    {
        // Reference the terrain generator script
        TerrainGenerator terrainGeneratorScript = environment.GetComponent<TerrainGenerator>();

        // Render collectibles
        RenderCollected(terrainGeneratorScript.obstacles);
    }

    // Render and add collected items to the collectible container
    public void RenderCollected(Transform[] collected)
    {
        float halfWidth = 30;
        float itemCount = collected.Length;
        float itemWidth = (halfWidth * 2) / itemCount;
        // Loop through the collectibles
        for (int i = 0; i < collected.Length; i++)
        {
            // Instantiate the collectible
            GameObject collectible = Instantiate(collected[i].gameObject, collectedObjectContainer.transform.position, collected[i].rotation);
            // Set the layer of the collectible to the UI layer
            collectible.layer = 6;
            // Scale the collectible to 5
            collectible.transform.localScale = new Vector3(8, 8, 8);
            // Spread out the items on the x-axis
            float newX = collectedObjectContainer.transform.position.x - halfWidth + itemWidth * 0.5f +  itemWidth * i;
            collectible.transform.position = new Vector3(newX, collectible.transform.position.y, collectible.transform.position.z);
            // Set the collectible parent to the collectible container
            collectible.transform.SetParent(collectedObjectContainer.transform);
        }
    }
}
