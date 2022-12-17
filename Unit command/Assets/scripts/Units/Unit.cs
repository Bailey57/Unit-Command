using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Assets
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] public GameObject travelTarget;
        [SerializeField] private float distanceToTarget;

        [SerializeField] public string faction;
        [SerializeField] private string unitName;
        [SerializeField] private decimal moralLevel;
        [SerializeField] private int soldierCount;
        [SerializeField] private int vehivleCount;
        [SerializeField] private decimal foodCount;
        [SerializeField] private int ammoCount;
        [SerializeField] private decimal fuelCount;
        [SerializeField] private string order;


        //hours of combat experience the unit has combined
        //looses experience if it gains new recruits
        [SerializeField] private decimal experience;




        [SerializeField] private float speed;
        [SerializeField] private float viewDistance;

        [SerializeField] private BoxCollider2D boxCollider;


        public float GetDistance()
        {
            return Vector2.Distance(transform.position, travelTarget.transform.position);
        }
        public Vector2 GetDirection()
        {
            return (travelTarget.transform.position - transform.position);
        }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //distanceToTarget = Vector2.Distance(transform.position, travelTarget.transform.position);
            distanceToTarget = GetDistance();
            Vector2 direction = GetDirection();
            transform.position = Vector2.MoveTowards(this.transform.position, travelTarget.transform.position, speed * Time.deltaTime);
            //if (EnemyInSight())
            //{
            //attack
            //}



        }




    }


}