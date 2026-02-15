using UnityEngine;

public class SemiParallaxBG : MonoBehaviour
{
    private Vector2 centeredPos;
    public Transform cameraTransform;

    public float maxXOffset = 1f;
    public float maxYOffset = 1f;

    public float maxXCameraDistFromBG = 100f;
    public float maxYCameraDistFromBG = 50f;

    void Start()
    {
        centeredPos = transform.position;
    }

    void Update()
    {
        float xDist = cameraTransform.position.x - centeredPos.x;
        float xOffset = Mathf.Clamp(xDist / maxXCameraDistFromBG, -1f, 1f) * maxXOffset;

        float yDist = cameraTransform.position.y - centeredPos.y;
        float yOffset = Mathf.Clamp(yDist / maxYCameraDistFromBG, -1f, 1f) * maxYOffset;

        Vector2 newPos = new Vector2(centeredPos.x - xOffset, centeredPos.y - maxYOffset);
        transform.position = newPos; 
    }
}
