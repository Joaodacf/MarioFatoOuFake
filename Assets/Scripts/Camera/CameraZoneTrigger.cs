using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CameraZoneTrigger : MonoBehaviour
{
    [SerializeField] CinemachineCamera targetCamera; // Cãmera ativada quando o jogador entra no trigger
    [SerializeField] CinemachineCamera defaultCamera; // Câmera ativada quando o jogador sai do trigger (A camera padrão)

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            CameraManager.SwitchCamera(targetCamera);
            Debug.Log("entrou");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) {
            CameraManager.SwitchCamera(defaultCamera);
            Debug.Log("saiu");
        }
    }
}
