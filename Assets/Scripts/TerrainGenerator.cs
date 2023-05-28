using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]

public class TerrainGenerator : MonoBehaviour
{
    Mesh mesh;
    int[] triangle;
    Vector3[] vertices;
    Vector2[] uv;
    public int xSize = 20;
    public int zSize = 20;
    [Range(0,1)]public float obstacleThreshold;
    [Range(0, 1)] public float collectiblesThreshold;
    public Transform[] obstacles;
    public Transform[] collectibles;
    int numberOfCollectiblesInScene = 0;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        Createmesh();
       
    }
    private void Update()
    {
        updatemesh();
    }

    // Update is called once per frame
  

    void Createmesh()
    {

        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        uv = new Vector2[(xSize + 1) * (zSize + 1)];

        for(int i = 0,z = -zSize / 2; z <= zSize/2; z++)
        {
            for(int x = -xSize/2; x <= xSize/2; x++)
            {
                float y = Mathf.PerlinNoise(x * .3f, z * .3f) * 2f;
                vertices[i] = new Vector3(x, 0, z);
                // Debug.Log(y);
                if (y < obstacleThreshold){
                    if(Vector3.Distance(vertices[i], Vector3.zero) > 5.0f)
                        Instantiate(obstacles[Random.Range(0, obstacles.Length)], vertices[i], Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f)).SetParent(transform, true);
                }else{
                    if (y < collectiblesThreshold)
                    {
                        Instantiate(collectibles[Random.Range(0, collectibles.Length)], vertices[i], Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f)).SetParent(transform, true);
                        numberOfCollectiblesInScene++;
                    }
                }
                //uv[i] = new Vector2(x / xSize, z / zSize);
                i++;
            }
        }

        triangle = new int[xSize * zSize * 6];
        int verts = 0;
        int tris = 0;

        for (int i = 0; i < zSize; i++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangle[tris + 0] = verts + 0;
                triangle[tris + 1] = verts + xSize + 1;
                triangle[tris + 2] = verts + 1;
                triangle[tris + 3] = verts + 1;
                triangle[tris + 4] = verts + xSize + 1;
                triangle[tris + 5] = verts + xSize + 2;

                verts++;
                tris += 6;
            }
            verts++;
        }
    }

    void updatemesh()
    {
        mesh.Clear();
        //mesh.uv = uv;
        mesh.vertices = vertices;
        mesh.triangles = triangle;
        mesh.RecalculateNormals();
    }

 
}