using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float speed = 5.0f;
    private float xBound = 10;
    private float zBound = 10;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);

        if (transform.position.x > xBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.x < -xBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z > zBound)
            Destroy(gameObject);
        if (transform.position.z < -zBound)
            Destroy(gameObject);
    }

    // Method for On Trigger on Collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boat"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("Direct Hit!");
            AlertFellowNavy();
        }
    }

    void AlertFellowNavy()
    {
        Vector3 enemySpawnPos = new Vector3(9, 0.05f, Random.Range(-9, 9));
        Instantiate(enemyPrefab, enemySpawnPos, enemyPrefab.transform.rotation);
    }
}
