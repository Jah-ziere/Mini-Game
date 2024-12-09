using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private Rigidbody PlayerRb;
    public float speed = 5.0f;
    float horizontalInput;
    float forwardInput;
    public float jumpForce;
    public bool isOnGround = true;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (forwardInput > 0)
        {
            playerAnim.SetBool("Static_b",true);
            playerAnim.SetFloat("Speed_f",1);
        }
        else if(forwardInput == 0)
        {
            playerAnim.SetBool("Static_b",false);
            playerAnim.SetFloat("Speed_f",0f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            PlayerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");

        }
    }

    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            Debug.Log("Tasty");
            explosionParticle.Play();
        }

        else if (other.gameObject.CompareTag("Banana"))
        {
            Debug.Log("Yummy");
            Destroy(other.gameObject);
            explosionParticle.Play();

        }
    
    }
}
