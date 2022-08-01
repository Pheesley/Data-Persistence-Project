using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float force;
    public bool reload = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.X) && reload == true)
        {
            //GameObject cannonBall = Instantiate(projectilePrefab, transform.position, transform.rotation);
            //cannonBall.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(1, 0, 0) * force);

            Instantiate(projectilePrefab, transform.position, transform.rotation);
            reload = false;
            StartCoroutine(CannonCooldown());
        }

        IEnumerator CannonCooldown()
        {
            Debug.Log("Right Cannon reloading!");
            yield return new WaitForSeconds(3);
            Debug.Log("Right Cannon loaded!");
            reload = true;
        }
    }
}
