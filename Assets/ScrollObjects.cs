using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObjects : MonoBehaviour
{
    public float Speed;
    void Update()
    {
        foreach(Transform child in transform)
        {
            child.position = new Vector3(child.position.x - (Speed * Time.deltaTime), child.position.y, child.position.z);
        }
    }
}
