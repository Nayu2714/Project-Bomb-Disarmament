using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public LayerMask layerInteract;
    [Space(5)]
    public Texture2D cursorDefault;
    public Texture2D cursorInteract;
    public Texture2D cursorCut;

    private GameObject objRaycastHit;

    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f, layerInteract))
        {
            objRaycastHit = hit.collider.gameObject;
            if (objRaycastHit.CompareTag("Cut"))
            {
                Cursor.SetCursor(cursorCut, new Vector2(180f, 180f), CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(cursorInteract, new Vector2(30f, 30f), CursorMode.Auto);
            }
        }
        else
        {
            objRaycastHit = null;
            Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
        }
    }

    public GameObject GetCursorObject()
    {
        return objRaycastHit;
    }
}
