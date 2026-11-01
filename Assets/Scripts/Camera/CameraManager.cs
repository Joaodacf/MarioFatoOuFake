using UnityEngine;
using System.Collections.Generic;
using Unity.Cinemachine;

public class CameraManager : MonoBehaviour
{
    static List<CinemachineCamera> cameras = new List<CinemachineCamera>();

    public static void SwitchCamera(CinemachineCamera newCamera)
    {
        newCamera.Priority = 2;
        foreach (CinemachineCamera cam in cameras)
        {
            if (cam != newCamera)
            {
                cam.Priority = 0;
            }
        }
    }

    public static void Register(CinemachineCamera camera)
    {
        cameras.Add(camera);
    }

    public static void Unregister(CinemachineCamera camera)
    {
        cameras.Remove(camera);
    }
}
