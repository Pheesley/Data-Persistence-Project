using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    /*
     * Spawns Gold in random locations
     * Spawns Merchant ships &
     * Spawns Navy Enemy Ships peridocially
     * 
     * Merchants and Enemy scripts will need to help the SpawnManager!
     * Also help from MoveRight and Moveleft cannonball scripts.
     */
    public GameObject[] lootPrefabs;
    private int spawnRangeX = 8;
    private int spawnRangeZ = 8;

    private int merchantCount = 0;
    public GameObject merchantPrefab;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Invoke("SpawnLoot", 0.1f);
        }

        SpawnMerchant();
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * Spawn Navy and Merchants ship around the outer border,
         * Merchant ships can have any rotation, 45, 90, 135, 180; they move to the other side of the map
         * Navy Ships spawn when Merchant ships are destroyed by Player
         */
        merchantCount = FindObjectsOfType<Merchant>().Length;
        if (merchantCount == 0)
        {
            SpawnMerchant();
        }
    }

    void SpawnLoot()
    {
            int lootindex = Random.Range(0, lootPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.1f, Random.Range(-spawnRangeZ, spawnRangeZ));
            Instantiate(lootPrefabs[lootindex], spawnPos, lootPrefabs[lootindex].transform.rotation); // objects will spawn at the start
    }

    //Spawns Merchant Ships
    void SpawnMerchant()
    {
        Vector3 merchantSpawnPos = new Vector3(9, .05f, Random.Range(-9, 9));
        Instantiate(merchantPrefab, merchantSpawnPos, merchantPrefab.transform.rotation);
    }

    /*
     * Spawn Navy ships after a certain number of Merchants are destroyed
     * Number of Navy ships increases as more Merchants or more Navy ships are destroyed
     * Tracks number of ships destroyed
     * Spawn Enemy every few merchants destroyed; 3 merchants
     * Spawn 1 Enemy for every one Enemy destroyed
     */
}
