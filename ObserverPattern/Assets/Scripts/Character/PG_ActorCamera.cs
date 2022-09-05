using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PG_ActorCamera : MonoBehaviour
{
    private static PG_ActorCamera instance;
    public Vector3 offset;
    public float delayTime;
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

        transform.position = Vector3.Lerp(transform.position, fixedPos, Time.deltaTime * delayTime);
    }
}
