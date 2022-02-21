using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{

    public int length; // the number of positions to create in the line renderer
    public LineRenderer lineRend; // reference to the line renderer component
    public Vector3[] segmentPoses; // positions for each point in the line renderer
    private Vector3[] segmentV; // used in the smoothdamp function for positioning each line renderer point

    public Transform targetDir; // initial position for the first point in the line renderer

    public float targetDist; // distance from one point in the line renderer to the next
    public float smoothSpeed; // speed with which to adjust line renderer positions in the smooth damp function

    public float wiggleSpeed;
    public float wiggleMagnitude;
    public Transform wiggleDir;

    void Start()
    {
        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];

        ResetPos();
    }

    void Update()
    {
        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            //Vector3 targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;
            //segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentV[i], smoothSpeed);
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i - 1] + targetDir.right * targetDist, ref segmentV[i], smoothSpeed);
        }
        lineRend.SetPositions(segmentPoses);
    }

    private void ResetPos()
    {
        segmentPoses[0] = targetDir.position;
        for (int i = 1; i < length; i++)
        {
            segmentPoses[i] = segmentPoses[i - 1] + targetDir.right * targetDist;
        }
        lineRend.SetPositions(segmentPoses);
    }
}
