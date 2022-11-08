using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeExp : MonoBehaviour
{

    //public GameObject fxExplotion;
    
    public float radius;
    public float expForce;

    public float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Player"))
        {
            c.rigidbody.AddExplosionForce(expForce, transform.position, radius, 1f, ForceMode.Impulse);
            Destroy(gameObject);
        }

        if (c.gameObject.name == ("Gate"))
        {
            Debug.Log("Abre puerta");
            Destroy(c.gameObject);
            Destroy(gameObject);
        }

        if (c.gameObject.name == ("Enemy2"))
        {
            Destroy(c.gameObject);
            Destroy(gameObject);
        }
    }

    
}
