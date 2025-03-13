using Fusion;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : NetworkBehaviour
{
    public GameObject buttonCanvas;
    public float speed = 0.1f;

    private GameObject cube = null;

    public void Start()
    {
        buttonCanvas.transform.Find("ButtonMoveUp").GetComponent<Button>().onClick.AddListener(MoveUp);
        buttonCanvas.transform.Find("ButtonMoveDown").GetComponent<Button>().onClick.AddListener(MoveDown);
        buttonCanvas.transform.Find("ButtonMoveLeft").GetComponent<Button>().onClick.AddListener(MoveLeft);
        buttonCanvas.transform.Find("ButtonMoveRight").GetComponent<Button>().onClick.AddListener(MoveRight);
    }

    public void MoveUp()
    {
        Find();
        cube.transform.Translate(speed * Vector3.up);
    }

    public void MoveDown()
    {
        Find();
        cube.transform.Translate(speed * Vector3.down);
    }

    public void MoveLeft()
    {
        Find();
        cube.transform.Translate(speed * Vector3.left);
    }

    public void MoveRight()
    {
        Find();
        cube.transform.Translate(speed * Vector3.right);
    }

    public void Find()
    {
        Debug.Log("Find called.");
        if (cube == null)
        {
            Debug.Log("Cube not found. Finding cube.");
            cube = GameObject.FindWithTag("cube");
        }
    }
}
