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

    public void Start()
    {
        cursorDefault = ResizeTexture(cursorDefault, 32, 32);
        cursorInteract = ResizeTexture(cursorInteract, 32, 32);
        cursorCut = ResizeTexture(cursorCut, 32, 32);
    }

    public void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10f, layerInteract))
        {
            objRaycastHit = hit.collider.gameObject;
            if (objRaycastHit.CompareTag("Cut"))
            {
                Cursor.SetCursor(cursorCut, new Vector2(14f, 14f), CursorMode.ForceSoftware);
            }
            else
            {
                Cursor.SetCursor(cursorInteract, new Vector2(6f, 6f), CursorMode.ForceSoftware);
            }
        }
        else
        {
            objRaycastHit = null;
            Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

    static Texture2D ResizeTexture(Texture2D srcTexture, int newWidth, int newHeight)
    {
        var resizedTexture = new Texture2D(newWidth, newHeight, TextureFormat.RGBA32, false);
        Graphics.ConvertTexture(srcTexture, resizedTexture);
        return resizedTexture;
    }

    public GameObject GetCursorObject()
    {
        return objRaycastHit;
    }
}
