using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDialoguePosition : MonoBehaviour
{
    public Transform mashiTransform;
    public Camera cam;
    public float offset;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mashiScreenPos = cam.WorldToScreenPoint(mashiTransform.position);
        transform.position = mashiScreenPos + new Vector3(0, offset, 0);
    }
}
