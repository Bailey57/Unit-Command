using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets
{
    public class UnitClick : MonoBehaviour
    {
        [SerializeField] public GameObject unitSelections;
        [SerializeField] private Camera cam;

        [SerializeField] public LayerMask clickable;
        [SerializeField] public LayerMask ground;







        /**
         * Sets the current selected units
         */
        public void SelectUnits()
        {

            if (Input.GetMouseButtonDown(0))
            {

                //RaycastHit hit;
                //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                //Debug.Log();
                //RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
                RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
                //TODO: Make it by faction and not just Blue for multiplayer
                if (rayHit.transform != null && rayHit.transform.gameObject && rayHit.transform.gameObject &&
                    (rayHit.transform.gameObject.GetComponent("Unit") as Unit).faction.Equals("Blue"))
                {
                    
                    Debug.Log("Hit " + rayHit.transform.gameObject.name);

                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        UnitSelections.Instance.ShiftClickSelect(rayHit.transform.gameObject);
                    }
                    else
                    {
                        UnitSelections.Instance.ClickSelect(rayHit.transform.gameObject);
                    }
                    //Debug.Log("Casting ray!");
                }
                else
                {
                    Debug.Log("Hit Nothing");

                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        UnitSelections.Instance.DeSelectAll();
                    }
                    //Debug.Log("Not casting ray!");
                }


            }
        }


        /**
         * Sets the travel destination of selected units 
         */
        public void SetDestination()
        {
            if (Input.GetMouseButtonDown(1))
            {
                //(gameObject.GetComponent("Unit") as Unit).travelTarget
                //(unitSelections.GetComponent("UnitSelections") as UnitSelections).unitsSelected
                //unitSelections
                if ((unitSelections.GetComponent("UnitSelections") as UnitSelections).unitsSelected[0] != null)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    //Debug.Log(worldPosition.x);
                    //Debug.Log(worldPosition.y);
                    //Destroy(g1);
                    GameObject g1 = new GameObject();
                    g1.transform.position = new Vector3(worldPosition.x, worldPosition.y, -0.02f);
                    SpriteRenderer sr = g1.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
                    Sprite downArrow = Resources.Load<Sprite>("sprites/icons/downPointingArrow15x16_1");
                    sr.sprite = downArrow;
                    //downPointingArrow15x16_1


                    //Debug.Log("Hit RMB");
                    for (int i = 0; i < (unitSelections.GetComponent("UnitSelections") as UnitSelections).unitsSelected.Count; i++)
                    {
                        //TODO: change later to be dynamic names for specific units
                        if ((((unitSelections.GetComponent("UnitSelections") as UnitSelections).unitsSelected[i]).GetComponent("Unit") as Unit).travelTarget != null &&
                            (((unitSelections.GetComponent("UnitSelections") as UnitSelections).unitsSelected[i]).GetComponent("Unit") as Unit).travelTarget.name.Equals("New Game Object"))
                        {

                            Destroy((((unitSelections.GetComponent("UnitSelections") as UnitSelections).unitsSelected[i]).GetComponent("Unit") as Unit).travelTarget);

                        }
                        (((unitSelections.GetComponent("UnitSelections") as UnitSelections).unitsSelected[i]).GetComponent("Unit") as Unit).travelTarget = null;
                        (((unitSelections.GetComponent("UnitSelections") as UnitSelections).unitsSelected[i]).GetComponent("Unit") as Unit).travelTarget = g1;
                        (((unitSelections.GetComponent("UnitSelections") as UnitSelections).unitsSelected[i]).GetComponent("Unit") as Unit).order[1] = "advance";
                        //Debug.Log("Changed travelTarget");

                    }

                }


            }

        }


        /**
         * When arrived at travel target, remove it from Unit and if its own, than destroy it 
         */
        public void ArrivedAtTarget() 
        {
        
        
        }

        // Start is called before the first frame update
        void Start()
        {
            cam = Camera.main;

        }


        // Update is called once per frame
        void Update()
        {
            SelectUnits();
            SetDestination();


        }

    }
}
