using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    public bool halfSized = false;
    public GameObject playerBody;
    private Vector3 playerBodyOriginalSize;
    //private Vector3 playerBodyOriginalPos;

    public float cooldown = 5f;
    private float originalCooldown;
    public bool cooldownIsWorking = false;

    public GameObject portal1;
    public GameObject portal2;

    public GameObject escalera;

    private void Start()
    {
        originalCooldown = cooldown;
        playerBodyOriginalSize = playerBody.transform.localScale;
        //playerBodyOriginalPos = playerBody.transform.position;
        portal1.SetActive(true);
        escalera.SetActive(false);
    }

    void Update()
    {
        Cooldown();

    }

    void Cooldown()
    {
        if (cooldownIsWorking == true && cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            portal1.SetActive(false);
            portal2.SetActive(false);
        }
        if (cooldown <= 0)
        {
            cooldown = originalCooldown;
            cooldownIsWorking = false;
            portal1.SetActive(true);
            portal2.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Portal"))
        {
            if (halfSized == false && cooldownIsWorking == false)
            {
                cooldownIsWorking = true;
                halfSized = true;
                Debug.Log("Se achica");
                playerBody.transform.localScale = playerBody.transform.localScale / 2;
            }
            if (halfSized == true && cooldownIsWorking == false)
            {
                cooldownIsWorking = true;
                halfSized = false;
                Debug.Log("Vuelve a su tamaño origial");
                playerBody.transform.localScale = playerBodyOriginalSize;
                //playerBody.transform.position = new Vector3(playerBody.transform.position.x, playerBodyOriginalPos.y, playerBody.transform.position.z);
            }
        }

        if (other.gameObject.name == ("PortalColider2"))
        {
            escalera.SetActive(true);
        }
    }
}
