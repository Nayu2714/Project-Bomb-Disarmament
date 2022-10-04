using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public LayerMask layerInteract;
    private GameObject objRaycastHit;

    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit, 10f, layerInteract))
        {
            objRaycastHit = hit.collider.gameObject;
        }
        else
        {
            objRaycastHit = null;
        }
    }

    public GameObject GetCursorObject()
    {
        return objRaycastHit;
    }
}
