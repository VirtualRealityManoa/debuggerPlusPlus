using UnityEngine;
using System.Collections;

public class AnimateCockroach : MonoBehaviour
{


    // get random crawl speed
    public float MAX_SPEED = 6;
    public float MIN_SPEED = 3;
    public float random;
    public int size; //1 is small, 2 is medium, 3 is large

    private RaycastHit hit;

    private GameObject target;



    // Use this for initialization
    void Start()
    {

        random = Random.Range(MIN_SPEED, MAX_SPEED);
        target = GameObject.Find("target");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //should randomize speed throughout motion (or maybe make it reactive depending on environment)
        //also should randomize direction (or again, make it reactive - ex. they "see" the player and move towards them or get hit and run away)


        Rigidbody rb = GetComponent<Rigidbody>();

        /* Vector3 fwd = transform.TransformDirection(Vector3.forward);
         if (Physics.Raycast(transform.position, fwd, out hit, 1))
         {
            // Debug.Log(hit.collider.gameObject.name);
             if (hit.collider.gameObject.name == "Cube")
             {
             //    rb.AddForce(Vector3.up * 800);
             }
         }*/

        if (Vector3.Dot(transform.up, Vector3.down) > -0.8)
        {
            //Debug.Log("Roach is upside down");
            //GetComponent<Animation>().Stop("CRAWL");
            GetComponent<Animation>()["CRAWL"].speed = random;
        }


        else
        {

            float step = (random * Time.deltaTime) * size;
            Vector3 targetDir = target.transform.position - transform.position;

            GetComponent<Animation>().Play("CRAWL");
            GetComponent<Animation>()["CRAWL"].speed = random / 2;

            //rotate roach if needed
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 5.0F);
            transform.rotation = Quaternion.LookRotation(newDir);

            //move roach forward
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

            /*Vector3 moveTowards = Vector3.MoveTowards(transform.position, target.transform.position, step);
            
            rb.AddForce(moveTowards);*/
        }

    }
    // if collided with some wall or block, climb up the object

}