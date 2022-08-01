using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    /*
     * Counts towards Gold if destroyed, is destroyed by colliding with it
     * Will move around the map and avoid the player
     * Either by rotating and moving away from player, or moving side of map to other side of map and destroy itself
     * 
     * May need to spawn in more Enemy Navy ships with every few Merchants destroyed
     */
    public float speed = 1;
    public GameObject cargoPrefab;
    public GameObject enemyPrefab;
    private float xbound = 9;
    private float zbound = 9;
    private float ybound = 0.05f;

    private GameManager gameManager;
    private int shipGold;

    //public Transform target;
    //public float turnSpeed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        shipGold = Random.Range(200, 500);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        /*
        Vector3 targetDirection = target.position - transform.position;

        float singleStep = turnSpeed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);
        */

        if (transform.position.x > xbound)
            Destroy(gameObject);
        if (transform.position.x < -xbound)
            Destroy(gameObject);
        if (transform.position.z > zbound)
            Destroy(gameObject);
        if (transform.position.z < -zbound)
            Destroy(gameObject);
        if (transform.position.y != ybound)
            transform.position = new Vector3(transform.position.x, ybound, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trade ship boarded and looted!");
            Destroy(gameObject);
            gameManager.UpdateScore(shipGold);
            AlertNavy();
        }
        else if (other.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Direct Hit!");
            Destroy(gameObject);
            Instantiate(cargoPrefab, transform.position, transform.rotation);
            // Call to spawn Enemy object in MoveRight.cs and MoveLeft.cs instead to avoid unecessary spawning
        }
    }

    //call to spawn Enemy object
    void AlertNavy()
    {
        Vector3 enemySpawnPos = new Vector3(9, 0.05f, Random.Range(-9, 9));
        Instantiate(enemyPrefab, enemySpawnPos, enemyPrefab.transform.rotation);
    }


}
