using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class grab_objects : MonoBehaviour
{
    [SerializeField] private Transform grabPoint1;
    [SerializeField] private Transform rayPoint1;
    [SerializeField] private Transform grabPoint2;
    [SerializeField] private Transform rayPoint2;
    [SerializeField] private float rayDistance;

    private GameObject grabbedObject;
    private int layerIndex;

    // Start is called before the first frame update
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Key");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo1 = Physics2D.Raycast(rayPoint1.position, transform.right, rayDistance);
        RaycastHit2D hitInfo2 = Physics2D.Raycast(rayPoint2.position, transform.right, rayDistance);

        if (hitInfo1.collider != null && hitInfo1.collider.gameObject.layer == layerIndex) 
        {
            if (grabbedObject == null)
            {
                grabbedObject = hitInfo1.collider.gameObject;
                grabbedObject.transform.position = grabPoint1.position;
                grabbedObject.transform.SetParent(transform);
            }
        }
        else if (hitInfo2.collider != null && hitInfo2.collider.gameObject.layer == layerIndex)
        {
            if (grabbedObject == null)
            {
                grabbedObject = hitInfo2.collider.gameObject;
                grabbedObject.transform.position = grabPoint2.position;
                grabbedObject.transform.SetParent(transform);
            }
        }
    }
}
