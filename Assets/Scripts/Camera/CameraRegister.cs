using UnityEngine;
using Unity.Cinemachine;

public class CameraRegister : MonoBehaviour
{
    // Componente responsável por adicionar a câmera à lista de câmeras do CameraManager

    void OnEnable()
    {
        CameraManager.Register(GetComponent<CinemachineCamera>());
    }

    void OnDisable()
    {
        CameraManager.Unregister(GetComponent<CinemachineCamera>());
    }
}
