using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Assets
{
    public class TriggerTest : MonoBehaviour
    {

        [SerializeField] public GameObject unit;



        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Trigger worked!");
            if ((unit.GetComponent("Unit") as Unit) != null)
            {
                if (other.gameObject.GetComponent("Unit") as Unit && !((other.gameObject.GetComponent("Unit") as Unit).faction.Equals((unit.GetComponent("Unit") as Unit).faction)))
                {
                    //temporary
                    //TODO: Add checks for orders to make sure they are following
                    
                    //in attack list already check
                    if (!(unit.GetComponent("Unit") as Unit).attackTargets.Contains((other.gameObject)))
                    {
                        (unit.GetComponent("Unit") as Unit).attackTargets.Add(other.gameObject);

                        Debug.Log("Added " + (other.gameObject.GetComponent("Unit") as Unit).unitName + " to attack list.");
                    }
                    //(unit.GetComponent("Unit") as Unit).travelTarget = other.gameObject;
                }

            }

        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.GetComponent("Unit") as Unit && !((other.gameObject.GetComponent("Unit") as Unit).faction.Equals((unit.GetComponent("Unit") as Unit).faction)))
            {
                //temporary
                //TODO: Add checks for orders to make sure they are following
                (unit.GetComponent("Unit") as Unit).attackTargets.Remove(other.gameObject);
                //(unit.GetComponent("Unit") as Unit).travelTarget = null;
            }

        }



    }
}