using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the dragging behaviour
public class Dragger : MonoBehaviour
{
    void OnMouseDrag(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            // Moves only if the player hovers the cursor over a Grid object with the isOccupied bool set to false.
            if (hit.transform.gameObject.GetComponent<GridScript>() != null && hit.transform.gameObject.GetComponent<GridScript>().isOccupied == false && hit.transform.gameObject.GetComponent<GridScript>().isSpawner == false)
            {
                transform.rotation = Quaternion.identity;
                transform.position = new Vector3(hit.transform.position.x, 0.5f, hit.transform.position.z);
            }
        }
    }
}
