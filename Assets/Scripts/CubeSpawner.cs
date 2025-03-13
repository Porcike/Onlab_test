using Fusion;
using UnityEngine;
using UnityEngine.UI;

public class CubeSpawner : NetworkBehaviour
{
    public GameObject cubePrefab;
    public GameObject buttonCanvas;
    private GameObject _spawnCanvas = null;

    public void Update()
    {
        if(_spawnCanvas == null)
        {
            _spawnCanvas = GameObject.FindWithTag("spawnCanvas");
            if(_spawnCanvas != null)
            {
                var button = _spawnCanvas.transform.Find("SpawnButton").GetComponent<Button>();
                button.onClick.AddListener(SpawnCube);
                Debug.Log("Listener added to spawn button.");
            }
        }
    }

    public void SpawnCube()
    {
        Debug.Log("Spawn button pressed.");
        if(Runner != null)
        {
            _spawnCanvas.SetActive(false);
            Runner.Spawn(cubePrefab, new Vector3(0, 0.01f, 0), Quaternion.identity);
            buttonCanvas.SetActive(true);
        }
    }
}
