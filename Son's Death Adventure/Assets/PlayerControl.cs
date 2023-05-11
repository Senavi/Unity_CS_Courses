using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Camera cam;
    private Unit selectedUnit;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click to select unit
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Unit unit = hit.collider.GetComponent<Unit>();
                if (unit != null)
                {
                    selectedUnit = unit;
                    Debug.Log("You selected the unit!");
                }
            }
        }
        else if (Input.GetMouseButtonDown(1)) // Right click to move unit
        {
            if (selectedUnit != null)
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    selectedUnit.MoveTo(hit.point);
                }
            }
        }
    }
}
