using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    Vector3 position;
    void Start()
    {
        position = transform.position;
    }
    void Update()
    {
        transform.position = player.transform.position + position;
    }
}
