using Fusion;
using UnityEngine;

public class CubeSpawner : SimulationBehaviour
{
    public GameObject cubePrefab;
    public GameObject spawnCanvas;
    public GameObject buttonCanvas;

    public void SpawnCube()
    {
        UnityEngine.Debug.Log("Spawn pressed.");
        spawnCanvas.SetActive(false);
        Runner.Spawn(cubePrefab, new Vector3(0, 0.01f, 0), Quaternion.identity);
        buttonCanvas.SetActive(true);
    }
}
