using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame_MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    private static InGame_MainCamera instance;

    public Vector3 offset;
    float delayTime;
    public static InGame_MainCamera Instance
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
        Vector3 fixedPos = new Vector3(transform.position.x + offset.x, transform.position.y + offset.y, transform.position.z + offset.z);

        transform.position = Vector3.Lerp(transform.position, fixedPos, Time.deltaTime * delayTime);
    }
}
