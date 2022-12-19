using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Camera cam;
    [SerializeField] private Vector3 dragOrigin;
    [SerializeField] private GameObject target;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //this.transform.position = target.transform.position.x;
            //this.transform.position.x = target.transform.position.x;
            //this.transform.position.y = target.transform.position.y;
            this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
        }
        
        PanCamera();
        
        
        
    }


    private void PanCamera() 
    {
        
        if (Input.GetMouseButtonDown(0)) 
        {
            target = null;
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);

        }

        if (Input.GetMouseButton(0)) 
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);

            cam.transform.position += difference;
        }
    }


}
