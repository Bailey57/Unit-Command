using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTest : MonoBehaviour
{
    [SerializeField] private LayerMask clickable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame



    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (rayHit.transform != null)
            {
                Debug.Log("Hit " + rayHit.transform.gameObject.name);
            }
            else 
            {
                Debug.Log("Hit Nothing");
            }
            

        }

        
    }
}
