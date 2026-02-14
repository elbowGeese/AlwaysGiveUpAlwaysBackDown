using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public GameObject followTarget;
    public float followThreshold;
    public float followSpeed;
    public Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        followTarget = GameObject.FindAnyObjectByType<BunnyController>().gameObject;
    }

    // Update is called once per frame

    private void LateUpdate()
    {
        float distance = Vector3.Distance(transform.position, followTarget.transform.position + offset);

        if (distance > followThreshold)
        {
            Vector3 targetPosition = followTarget.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed);
        }
    }
    void Update()
    {
        
    }
}
