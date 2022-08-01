using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    /*
     * Enemy object moves and rotates toward player.
     * Needs bounds that will keep it in place, x, y, and z.
     * 
     * May need to try interacting with physics objects and terrain
     */
    public float speed;
    //public float turnSpeed;
    //private Rigidbody enemyRb;
    private GameObject player;
    public GameObject enemyPrefab;

    private float xBound = 9;
    private float zBound = 9;
    private float yBound = 0.05f;

    // The target marker
    public Transform target;

    // Angular speed in radians per sec.
    public float turnspeed = 1.0f;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        target = player.transform.Find("Target");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //adds force relative to the object's current coordinate system
        // in this case, object will move in it's current forward direction, depending on it's rotation
        //So we make the objects move forward, and Rotate towards the direction of the player.

        // Send the object forward in it's current forward direction
        //Move forward using transform
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // Move forward using rigid body
        //enemyRb.AddRelativeForce(Vector3.forward * speed * Time.deltaTime);

        // Determine which direction to rotate towards
        Vector3 targetDirection = target.position - transform.position;

        // The step size is equal to speed times frame time
        float singleStep = turnspeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);

        // Keep object inside game area
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.z > zBound)
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        if (transform.position.z < -zBound)
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        if (transform.position.y != yBound)
            transform.position = new Vector3(transform.position.x, yBound, transform.position.z);

        // Keep the objects from rotating along the x axis
        /*
        if (transform.rotation.x != 0)
            transform.Rotate(0.0f, transform.rotation.y, transform.rotation.z);
        */
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Debug.Log("You have been captured by the Navy! You Lose!");
            gameManager.GameOver();
        }
        if (other.gameObject.CompareTag("Projectile"))
        {
            //AlertFellowNavy();
        }
    }

    //WARNING: When this prefab creates a clone of itself, the clone's script is set to inactive
    /*
    void AlertFellowNavy()
    {
        Vector3 enemySpawnPos = new Vector3(9, 0.05f, Random.Range(-9, 9));
        Instantiate(enemyPrefab, enemySpawnPos, enemyPrefab.transform.rotation);
    }
    */
}
