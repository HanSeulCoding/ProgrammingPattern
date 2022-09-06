using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PG_ActorCamera : MonoBehaviour
{
    private static PG_ActorCamera instance;
    public Vector3 offset;
    public float delayTime;
    public float xTurnSmoothTime;
    public float yTurnSmoothTime;

    public float xTurnSmoothVelocity;
    public float yTurnSmoothVelocity;
    public static PG_ActorCamera Instance
    {
        get
        {
            return instance;
        }
    }

    public void Awake()
    {
        instance = this;
    }

    public void LookTarget(Transform target)
    {
        Vector3 fixedPos = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);

        transform.position = fixedPos;
    }

    public void LookAround()
    {
        Vector3 mouseDelta = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
        Vector3 camArmAngle = transform.eulerAngles;
        float x = camArmAngle.x - mouseDelta.y;

        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335, 360);
        }

        transform.rotation = Quaternion.Euler(x, camArmAngle.y + mouseDelta.x, camArmAngle.z);
    }
}
