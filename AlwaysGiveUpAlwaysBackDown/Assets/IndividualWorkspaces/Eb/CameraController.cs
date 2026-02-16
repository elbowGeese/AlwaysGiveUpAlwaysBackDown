using UnityEngine;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineCamera[] cameras;

    void Start()
    {
        SetPriorityCamera(0);
    }

    public void SetPriorityCamera(int num)
    {
        cameras[num].Prioritize();
    }
}
