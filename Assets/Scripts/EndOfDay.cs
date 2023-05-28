using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfDay : MonoBehaviour
{
    public GameObject collectedObjectContainer;
    public GameObject leftBehindObjectContainer;
    public GameObject environment;
    public GameObject player;
    public PlayerMovement playerMovementScript;

    // Start function
    void Start()
    {
        // Reference the terrain generator script
        TerrainGenerator terrainGeneratorScript = environment.GetComponent<TerrainGenerator>();
        // Reference the player movement script
        playerMovementScript = player.GetComponent<PlayerMovement>();

        // Render collectibles
        RenderCollected(playerMovementScript.collectedItems);
    }

    // Render and add collected items to the collectible container
    public void RenderCollected(List<GameObject> collected)
    {
        float halfWidth = 30;
        float itemCount = collected.Count;
        float itemWidth = (halfWidth * 2) / itemCount;
        // Loop through the collectibles
        for (int i = 0; i < itemCount; i++)
        {
            // Instantiate the collectible
            GameObject collectible = Instantiate(collected[i], collectedObjectContainer.transform.position, collected[i].transform.rotation);
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

    // Render and add left-behind items to the left-behind container
    public void RenderLeftBehind(List<GameObject> leftBehind)
    {
        float halfWidth = 30;
        float itemCount = leftBehind.Count;
        float itemWidth = (halfWidth * 2) / itemCount;
        // Loop through the left-behind items
        for (int i = 0; i < itemCount; i++)
        {
            // Instantiate the left-behind item
            GameObject leftBehindItem = Instantiate(leftBehind[i], leftBehindObjectContainer.transform.position, leftBehind[i].transform.rotation);
            // Set the layer of the left-behind item to the UI layer
            leftBehindItem.layer = 6;
            // Scale the left-behind item to 5
            leftBehindItem.transform.localScale = new Vector3(8, 8, 8);
            // Spread out the items on the x-axis
            float newX = leftBehindObjectContainer.transform.position.x - halfWidth + itemWidth * 0.5f + itemWidth * i;
            leftBehindItem.transform.position = new Vector3(newX, leftBehindItem.transform.position.y, leftBehindItem.transform.position.z);
            // Set the left-behind item parent to the left-behind container
            leftBehindItem.transform.SetParent(leftBehindObjectContainer.transform);
        }
    }
}
