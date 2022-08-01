using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCollision : MonoBehaviour
{
    private int gold; // used to update score by a random amount
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
       gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
       gold = Random.Range(20, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Treasure obtained! We now have " + gold + " gold.");
            gameManager.UpdateScore(gold);
        }
    }
}
