using UnityEngine;
using System;
using System.Collections;
using Unity.Cinemachine;

public class SizeHandler : MonoBehaviour
{
    public DustReceiver dustReceiver;
    public BunnyController bc;
    public CinemachinePositionComposer positionComposer;

    public float cameraZoomTime = 0.3f;
    public AnimationCurve cameraZoomCurve;
    public AnimationCurve jumpForceCurve;
    public AnimationCurve scaleCurve;
    public AnimationCurve smallPRadius, mediumPRadius, largePRadius;

    public ParticleSystem smallP1, smallP2, mediumP, largeP1, largeP2;

    void Start()
    {
        dustReceiver.onDustReceived += UpdateSize;
        UpdateSize();
    }

    void OnDisable()
    {
        dustReceiver.onDustReceived -= UpdateSize;
    }

    public void UpdateSize()
    {
        float dustAmount = dustReceiver.DustAmount;

        // scale
        float currentScale = scaleCurve.Evaluate(dustAmount);
        transform.localScale = Vector2.one * currentScale;

        // grounded ray
        bc.groundedRayDistance = currentScale;

        // jump force
        bc.jumpForce = jumpForceCurve.Evaluate(dustAmount);

        // particles
        float sRadius = smallPRadius.Evaluate(dustAmount);
        var smallP1ShapeModule = smallP1.shape;
        smallP1ShapeModule.radius = sRadius;
        var smallP2ShapeModule = smallP2.shape;
        smallP2ShapeModule.radius = sRadius;

        float mRadius = mediumPRadius.Evaluate(dustAmount);
        var mediumPShapeModule = mediumP.shape;
        mediumPShapeModule.radius = mRadius;

        float lRadius = largePRadius.Evaluate(dustAmount);
        var largeP1ShapeModule = largeP1.shape;
        largeP1ShapeModule.radius = lRadius;
        var largeP2ShapeModule = largeP2.shape;
        largeP2ShapeModule.radius = lRadius;

        // camera zoom 
        StartCoroutine(LerpCameraDist(cameraZoomCurve.Evaluate(dustAmount)));
    }

    IEnumerator LerpCameraDist(float newDist)
    {
        float previousDist = positionComposer.CameraDistance;

        float timer = 0f;
        while(timer < cameraZoomTime)
        {
            positionComposer.CameraDistance = Mathf.Lerp(previousDist, newDist, timer / cameraZoomTime);
            timer += Time.deltaTime;
            yield return null;
        }

        positionComposer.CameraDistance = newDist;
    }
}
