using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCannon : MonoBehaviour
{
    /*
     * Not using Gravity on Rigidbody makes projectiles drift throught the air more slowly
     * 
     * 
     */
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
        //Maybe make cannon shoot further by increasing Force physics while fire button is held down?
        if (Input.GetKeyDown(KeyCode.Z) && reload == true)
        {
            // Projectile using rigidbody
            //GameObject cannonBall = Instantiate(projectilePrefab, transform.position, transform.rotation);
            //cannonBall.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-1, 0, 0) * force);

            // Projectile using translate
            GameObject cannonBall = Instantiate(projectilePrefab, transform.position, transform.rotation);
            // line of code below does not work
            //cannonBall.transform.Translate(Vector3.left * Time.deltaTime * force);

            reload = false;
            StartCoroutine(CannonCooldown());
        }
    }

    IEnumerator CannonCooldown()
    {
        Debug.Log("Left Cannon reloading!");
        yield return new WaitForSeconds(3);
        Debug.Log("Left Cannon loaded!");
        reload = true;
    }
}
