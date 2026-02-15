using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class CameraZoomScript : MonoBehaviour
{

    public CinemachineCamera cam;
    public float zoomOutAmount;
    public float zoomTime;
    public CinemachinePositionComposer cameraPositioner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        cam = GameObject.FindFirstObjectByType<CinemachineCamera>();
        cameraPositioner = cam.GetComponent<CinemachinePositionComposer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ZoomRoutine());
        }
    }

    IEnumerator ZoomRoutine()
    {
        float startingPosition = cameraPositioner.CameraDistance;
        float timer = 0f;
        while (timer < zoomTime)
        {
            float interp = (timer / zoomTime);
            float currentZoom = Mathf.Lerp(startingPosition, zoomOutAmount + startingPosition, interp);
            cameraPositioner.CameraDistance = currentZoom;
            timer += Time.deltaTime;
            yield return null;
        }
        cameraPositioner.CameraDistance = startingPosition + zoomOutAmount;
    }
}
