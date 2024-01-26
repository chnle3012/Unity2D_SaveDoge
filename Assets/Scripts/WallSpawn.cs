using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        Camera mainCamera = Camera.main;

        Vector3 pixelCoordinates = new Vector3(0, 0, 0f);
        Vector3 worldCoordinates = mainCamera.ScreenToWorldPoint(pixelCoordinates);

        Vector3 pixelCoordinates2 = new Vector3(Screen.width, 0, 0f);
        Vector3 worldCoordinates2 = mainCamera.ScreenToWorldPoint(pixelCoordinates2);

        Instantiate(wall,new Vector3(worldCoordinates.x, worldCoordinates.y),Quaternion.identity);
        Instantiate(wall,new Vector3(worldCoordinates2.x + 0.18f, worldCoordinates2.y),Quaternion.identity);

    }
}
