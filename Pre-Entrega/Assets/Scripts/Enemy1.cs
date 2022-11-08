using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Transform posPlayer;
    public GameObject caraDefault;
    public GameObject caraEnojada;

    public float distEnojado;
    public float lerpRotSpeed;

    public GameObject granadePrefab;
    public Transform spawnPoint;

    public float range;

    public float cooldown = 5f;
    private float originalCooldown;
    public bool cooldownIsWorking;

    // Start is called before the first frame update
    void Start()
    {
        caraDefault.SetActive(true);
        caraEnojada.SetActive(false);

        originalCooldown = cooldown;
        cooldownIsWorking = false;

    }

    // Update is called once per frame
    void Update()
    {
        DistanceCheck();
        LookAtPlayerLerp();
        
    }

    void DistanceCheck()

    {
        float dist = Vector3.Distance(posPlayer.position, transform.position);

        if (dist < distEnojado)
        {
            Launch();
            caraDefault.SetActive(false);
            caraEnojada.SetActive(true);
        }
        else
        {
            caraDefault.SetActive(true);
            caraEnojada.SetActive(false);
        }
    }

    void LookAtPlayerLerp()
    {
        // creo un vector que me devuelve la posición del jugador para mirar hacia ese lugar
        Quaternion rot = Quaternion.LookRotation(posPlayer.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, lerpRotSpeed);
    }

    void Launch()
    {
        if (cooldown == originalCooldown)
        {
            GameObject go = Instantiate(granadePrefab, spawnPoint.position, spawnPoint.rotation);
            go.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * range, ForceMode.Impulse);
        }

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            //cooldownIsWorking = true;
        }
        if (cooldown <= 0)
        {
            cooldown = originalCooldown;
            //cooldownIsWorking = false;
        }

    }
}
