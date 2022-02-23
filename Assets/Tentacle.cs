using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{

    public int totalLineRendPositions; // the number of positions to create in the line renderer
    public LineRenderer lineRend; // reference to the line renderer component
    private Vector3[] lineRendPositions; // positions for each point in the line renderer
    private Vector3[] lineRendPositionVelocity; // used in the smoothdamp function for positioning each line renderer point

    public Transform targetDir; // initial position for the first point in the line renderer

    public float targetDist; // distance from one point in the line renderer to the next
    public float smoothSpeed; // speed with which to adjust line renderer positions in the smooth damp function

    public float wiggleSpeed; 
    public float wiggleMagnitude;
    public Transform wiggleDir;

    public bool flipWiggleDirection; // boolean to flip the direction of the initial wiggle rotation

    public Transform[] bodyParts; // use this to attach other gameobjects to points in the line renderer

    void Start()
    {
        lineRend.positionCount = totalLineRendPositions;
        lineRendPositions = new Vector3[totalLineRendPositions];
        lineRendPositionVelocity = new Vector3[totalLineRendPositions];

        ResetPos();
    }

    void Update()
    {
        // this determines the initial direction of wiggle rotation that gets applied to the lineRenderer
        if (flipWiggleDirection)
        {
            wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude * -1);
        } else
        {
            wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);
        }

        lineRendPositions[0] = targetDir.position; // set the position of the first line renderer point

        for (int i = 1; i < lineRendPositions.Length; i++)
        {
            //Vector3 targetPos = lineRendPositions[i - 1] + (lineRendPositions[i] - lineRendPositions[i - 1]).normalized * targetDist;
            //lineRendPositions[i] = Vector3.SmoothDamp(lineRendPositions[i], targetPos, ref lineRendPositionVelocity[i], smoothSpeed);
            lineRendPositions[i] = Vector3.SmoothDamp(lineRendPositions[i], lineRendPositions[i - 1] + (targetDir.right * targetDist), ref lineRendPositionVelocity[i], smoothSpeed);
        }
        lineRend.SetPositions(lineRendPositions);

        if (bodyParts != null)
        {
            for (int i = 0; i < bodyParts.Length; i++)
            {

            }
        }

    }

    private void ResetPos()
    {
        lineRendPositions[0] = targetDir.position;
        for (int i = 1; i < totalLineRendPositions; i++)
        {
            lineRendPositions[i] = lineRendPositions[i - 1] + targetDir.right * targetDist;
        }
        lineRend.SetPositions(lineRendPositions);
    }
}
