using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateBaseCollision : MonoBehaviour
{
    // Collisions are not being detected... the cause was a syntax error
    // A place to store gold safely
    // Can restart Navy spawns, the idea being that the base is a hiding place
    private GameManager gameManager;
    private int bank;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //gameManager.RestartGame(); Conflict with int score carrying over different scenes...
            gameManager.UpdateBank(gameManager.score);
            Debug.Log("The gold is safe inside the pirate base! Our stash is now " + bank + " in gold.");
            
            /*
            for (int goldCount = FindObjectOfType<Gold>().Length; goldCount < 10; goldCount++)
            {
                spawnManager.SpawnLoot();
            }
            spawnManager.SpawnMerchant();
            */
            //player.transform.position = new Vector3(0.5f, 0.05f, -6.75f);
            //StartCoroutine(SetPirateBaseInactive());
        }
    }

    IEnumerator SetPirateBaseInactive()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(10);
        gameObject.SetActive(true);
    }
}
