using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Assets
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] public GameObject travelTarget;
        [SerializeField] private float distanceToTarget;

        [SerializeField] public List<GameObject> attackTargets;

        [SerializeField] public float engagementDistance;

        [SerializeField] public string faction;
        [SerializeField] public string unitName;


        [SerializeField] private float moraleLevel;
        [SerializeField] public int soldierCount;
        [SerializeField] private int vehicleCount;

        //litres
        [SerializeField] private float waterCount;

        [SerializeField] private float foodCount;
        [SerializeField] public int ammoCount;
        /**
         * Fuel ammount in gallons 
         */
        [SerializeField] private float fuelCount;

        /**
         * The current order
         * 
         * Fire orders: 
         * hold fire
         * return fire
         * fire when ready
         * 
         * Movement orders:
         * advance
         * hold position
         * 
         * [fireOrder, MovementOrder]
         */
        [SerializeField] public string[] order;


        /**
         * hours of combat experience the unit has combined
         * looses experience if it gains new recruits
         */
        [SerializeField] private decimal experience;



        /**
         * Speed in meters per second
         */
        [SerializeField] private float speed;
        /**
         * View distance in meters
         */
        [SerializeField] private float viewDistance;

        [SerializeField] private BoxCollider2D boxCollider;


        /**
         * Sets the current fire order
         */
        //public string SetFireOrder(string order)
        //{
            //this.order[0] = order;
        //}
        /**
         * Sets the current move order
         */
        //public string SetMoveOrder(string order)
        //{
            //this.order[1] = order;
        //}

        /**
         * returns: the distance from this to an observed object
         */
        public float GetDistance()
        {
            return Vector2.Distance(transform.position, travelTarget.transform.position);
        }

        public bool TargetInRange() 
        {
            float scale = 25;
            //Debug.Log("Distance: " + GetDistance() * scale);
            if (GetDistance() * scale < this.engagementDistance)
            {
                return true;
            }
            else 
            {
                return false;
            }
        
        }
        /**
         * returns: the direction of an observed object
         */
        public Vector2 GetDirection()
        {
            return (travelTarget.transform.position - transform.position);
        }
        /**
         * This approaches the travel target
         */
        public void ApproachTravelTarget()
        {
            distanceToTarget = GetDistance();
            Vector2 direction = GetDirection();
            transform.position = Vector2.MoveTowards(this.transform.position, travelTarget.transform.position, speed * Time.deltaTime);

        }
        /**
         * This approaches the travel target till in firing range
         */
        public void ApproachTravelTargetTillInFireRange()
        {
            //TODO:make scale in Settings and use by reference
            //multiply to cords to get proper scale
            //how many meters per tile
            int scale = 25;
            
            distanceToTarget = GetDistance();
            if (distanceToTarget * scale > engagementDistance)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, travelTarget.transform.position, speed * Time.deltaTime);
            }
            

        }



        /**
         * Attacks the target
         */
        public void AttackTarget()
        {
            if (attackTargets == null) 
            {
                return;
            }

            int targetsInSight = attackTargets.Count;


            for (int i = 0; i < attackTargets.Count; i++) 
            {

                if ((attackTargets[i].GetComponent("Unit") as Unit) != null && TargetInRange() && this.ammoCount > 0) 
                {

                    //random kills here as placeholder for better attack system
                   

                    

                    System.Random rnd = new System.Random();
                    int randNum = rnd.Next(100000);

                    if (randNum <= 1000 * this.soldierCount)
                    {
                        this.ammoCount -= 1;

                    }

                    if (randNum <= 3 * this.soldierCount / 5) 
                    {
                        (attackTargets[i].GetComponent("Unit") as Unit).soldierCount -= 1;
                        
                    }

                    
                    //kills = / targetsInSight;
                }
                


            }
            

        }


        /**
         * Checks the current fire orders and acts based on them
         */
        public void FireOrderCheck()
        {
            //fire when ready
            if (String.Equals(order[0], "hold fire"))
            {

            }
            else if (String.Equals(order[0], "return fire"))
            {

            }
            else if (String.Equals(order[0], "fire when ready"))
            {
                AttackTarget();
            }
            else
            {

            }

        }

        /**
         * Checks the current move orders and acts based on them
         */
        public void MoveOrderCheck()
        {
            //advance, hold position, advance till in range
            if (String.Equals(order[1], "advance"))
            {
                ApproachTravelTarget();
            }
            else if (String.Equals(order[1], "hold position"))
            {

            }
            else if (String.Equals(order[1], "advance till in range"))
            {
                ApproachTravelTargetTillInFireRange();
            }
            else
            {

            }

            //ApproachTravelTarget()
        }



        //OnTriggerEnter2D not working in this script for unknown reason, but ok for now because handled by seperate script
        /*
        private void OnTriggerEnter2D(Collider2D other) 
        {
            Debug.Log("Trigger worked");
            if (other.gameObject.GetComponent("Unit") as Unit && !((other.gameObject.GetComponent("Unit") as Unit).faction.Equals(this.faction))) 
            {
                //temporary
                //TODO: Add checks for orders to make sure they are following
                this.attackTargets.Add(other.gameObject);
                this.travelTarget = other.gameObject;
            }
        }


        private void OnTriggerExit2D(Collider2D other) 
        {
            if (other.gameObject.GetComponent("Unit") as Unit && !((other.gameObject.GetComponent("Unit") as Unit).faction.Equals(this.faction)))
            {
                //temporary
                //TODO: Add checks for orders to make sure they are following
                this.attackTargets.Remove(other.gameObject);
                this.travelTarget = null;
            }

        }
        */


        // Start is called before the first frame update
        void Start()
        {
            UnitSelections.Instance.unitList.Add(this.gameObject);
            this.order = new string[2];
            this.order[0] = "fire when ready";
            this.order[1] = "advance till in range";

            this.ammoCount = 210 * this.soldierCount;
        }

        // Update is called once per frame
        void Update()
        {
            //TODO: Add if statements so it only does what the selected orders currently are.

            FireOrderCheck();
            MoveOrderCheck();

            distanceToTarget = GetDistance();

        }

        void Destroy() 
        {
            UnitSelections.Instance.unitList.Remove(this.gameObject);
        }

    }

}