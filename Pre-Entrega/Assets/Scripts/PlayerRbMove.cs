using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRbMove : MonoBehaviour
{
    public Rigidbody rb;
    public float moveForce;
    public float fastForce;
    private float originalForce;

    public float sideForce;
    public float jumpForce;
    public float rotSpeed;

    public bool firstPersonCam;
    public bool isGrounded = true;
    public bool isJumping = false;
   
    
    // Start is called before the first frame update
    void Start()
    {
        originalForce = moveForce;
        firstPersonCam = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseRotation = rotSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
        transform.Rotate(0,mouseRotation,0);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveForce = fastForce;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveForce = originalForce;
        }

        
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * sideForce * Time.fixedDeltaTime;
        rb.AddForce(transform.right * horizontal * sideForce);

        float vertical = Input.GetAxis("Vertical") * moveForce * Time.fixedDeltaTime;
        rb.AddForce(transform.forward * vertical * moveForce);
        //rb.AddForce(new Vector3(moveForce * horizontal, 0, 0), ForceMode.Impulse);
        //rb.AddForce(new Vector3(0, 0, moveForce * vertical), ForceMode.Impulse);

        if (Input.GetKey(KeyCode.E) && isGrounded == true && isJumping == false)
        {
            isJumping = true;
            rb.AddForce(transform.up * jumpForce);
        }
    }

    
    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Piso"))
        {
            isGrounded = true;
            isJumping = false;
        }

       
        if (c.gameObject.CompareTag("Grenade"))
        {
            Debug.Log("Perdiste");
        }

        if (c.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Perdiste");
        }

    }

    private void OnCollisionExit(Collision c)
    {
        if (c.gameObject.CompareTag("Piso"))
        {
            isGrounded = false;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == ("Win_Col"))
        {
            Debug.Log("Win!");
        }
    }




}
