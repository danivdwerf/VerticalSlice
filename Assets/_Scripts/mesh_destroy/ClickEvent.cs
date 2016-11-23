using UnityEngine;
using System.Collections;

public class ClickEvent : MonoBehaviour {
    
    private DeleteTriangleMesh deleteTriangleMesh;

    public GameObject levelMap;

    void Start ()
    {
        //get the script
        deleteTriangleMesh = levelMap.GetComponent<DeleteTriangleMesh>();
    }

    void Update()
    {
        // if mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            //where raycast hits
            RaycastHit hit;
            //make ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if ray hits mesh
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                deleteTriangleMesh.deleteTri(hit.triangleIndex);
            }
        }
    }
}
