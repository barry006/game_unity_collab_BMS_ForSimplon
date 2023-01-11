using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // NameSpace for use TextMeshPro

public class controller : MonoBehaviour
{
    [Header("PlayerController Settings")] // Header for display info in inspector.

    public int forceJump;
    public float speed = 20f;
    public float playerMaxVelo = 3f;
    public float timeJump;
    public float walkSpeed;
    public float runSpeed;

    bool _ground = true;

    public Camera cam;
    Rigidbody _rb;
    

    float _mouseX;
    float _mouseY;
    float _mouseSensibility = 10f;
    float _mouseAngleLock = 30f;


    public Animator anim;
    bool b;
    Vector3 v3;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private int pickUpPoints;

    public TextMeshProUGUI textmeshPro;


    public GameObject statue;

    






    void Awake()
    {

        _rb = GetComponent<Rigidbody>();        
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Start()
    {
        pickUpPoints = 0;
        v3 = respawnPoint.transform.position;
    }

    void Update()
    {
        // The camera looks at the direction of the cursor.
        _mouseX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * _mouseSensibility;
        _mouseY = _mouseY - Input.GetAxis("Mouse Y") * _mouseSensibility;
        transform.localEulerAngles = new Vector3(0, _mouseX, 0);
        //------------------------------------------------


        //Jump-------------------------------------------
        if (Input.GetKeyDown(KeyCode.Space) && _ground)
        {
            _rb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
            _ground = false;

        }
        //------------------------------------------------


        //anim jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("JUMP", true);
        }
        else
        {
            anim.SetBool("JUMP", false);
        }
        //-----

        // Controller Horizontal/Vertical and anim.
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") < 0 || Input.GetAxis("Vertical") < 0)
        {
            b = true;
            anim.SetBool("WALK", true);
        }
        else
        {
            b = false;
            anim.SetBool("WALK", false);
        }
        //------------------------------

        // active statue
        if(pickUpPoints==10)

        {
            statue.SetActive(true);
        }
        //-------------
    }

    void FixedUpdate()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        Vector3 newvelocity = Vector3.up * _rb.velocity.y;
        Vector3 abc = Vector3.zero;
        newvelocity.x = Input.GetAxis("Horizontal") * speed;
        newvelocity.z = Input.GetAxis("Vertical") * speed;
        _rb.velocity = transform.TransformDirection(newvelocity);
        //Run-----------
        if (Input.GetKey(KeyCode.LeftShift) && b)
        {
            anim.SetBool("RUN", true);
        }
        else
        {
            anim.SetBool("RUN", false);
        }
        //------------
    }



    // collisin player with ground
    private void OnCollisionEnter(Collision collision)
    {
        _ground = true;
    }
    //---------------------------


    // reset and transform position for Respawn
    void Respawn()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
        _rb.Sleep();
        transform.position = v3;
    }
    //------------------------

    private void OnTriggerEnter(Collider other)
    {
        // if player enter with enemy, respawn
        if (other.gameObject.CompareTag("Enemy"))
        {
            Respawn();
        }
        //--------------------------------

        // if player enter with PickUp, add pickUpPoints, new position for repawn, destroy PickUp, change text UI
        if (other.gameObject.CompareTag("PickUp"))
        {
            pickUpPoints++;
            v3 = other.gameObject.transform.position;
            Destroy(other.gameObject);
            textmeshPro.SetText(pickUpPoints + "/10");
        }
        //-------------------------------------
    }
   
}
