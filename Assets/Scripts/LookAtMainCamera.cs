using UnityEngine;

public class LookAtMainCamera : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, _camera.transform.position) * 100f;
        transform.LookAt((transform.position - _camera.transform.position) * distance);
    }
}
