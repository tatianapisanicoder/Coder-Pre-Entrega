using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public Transform posPlayer;
    public GameObject caraDefault;
    public GameObject caraEnojada;

    public float distEnojado;
    public float lerpSpeed;
    private float originalLerpSpeed;
    public float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        caraDefault.SetActive(true);
        caraEnojada.SetActive(false);

        originalLerpSpeed = lerpSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        DistanceCheck();
        LookAtPlayer();
        FollowWithLerp();
    }

    void DistanceCheck()
    {
        // calculo la distancia entre el jugador y este objeto
        float dist = Vector3.Distance(posPlayer.position, transform.position);
        //Debug.Log(dist);

        if (dist < distEnojado)
        {
            caraDefault.SetActive(false);
            caraEnojada.SetActive(true);

            if (dist < maxDistance)
            {
                lerpSpeed = 0f;
                Debug.Log("enemy2 MAX distance: " + dist);
            }
            else
            {
                lerpSpeed = originalLerpSpeed;
            }
       }
        else
        {
            caraDefault.SetActive(true);
            caraEnojada.SetActive(false);
        }
    }

    void LookAtPlayer() // esta forma es más simple que la anterior
    {
        transform.LookAt(posPlayer); // lookAt pide un transform a donde mirar
    }

    void FollowWithLerp()
    {
        // al acercarse al objetivo se hace un poco más lento el movimiento
        transform.position = Vector3.Lerp(transform.position, posPlayer.position, lerpSpeed * Time.deltaTime);
    }
}
