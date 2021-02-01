using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class CharController : MonoBehaviour
{
    public float speed = 100f;
    Rigidbody rb;
    public Animator anim;
    public float xSensitivity = 2;
    public float ySensitivity = 2;
    Camera cam;
    public GameObject jumpCheck;
    private Vector3 jumpCheckSize;
    public float jumpForce = 400;
    public AudioSource fireTail;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        jumpCheckSize = new Vector3((float)0.3, (float)0.4, (float)0.5);
        
    }

    
    void Update()
    {
        //Animation
        //Reload Animation Trigger
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("reload");
        }

        //Full Auto Fire animation Trigger
        if (Input.GetMouseButton(0))
        {
            anim.SetTrigger("FullFire");
            fireTail.Play();


        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }
        //walking
        if ((Input.GetKey(KeyCode.W))|| (Input.GetKey(KeyCode.A))|| (Input.GetKey(KeyCode.S))||(Input.GetKey(KeyCode.D)))
        {
            anim.SetBool("walking", true);
            
        }
        else if ((Input.GetKeyUp(KeyCode.W))||(Input.GetKeyUp(KeyCode.A))||(Input.GetKeyUp(KeyCode.S))||(Input.GetKeyUp(KeyCode.D)))
        {
            anim.SetBool("walking", false);
            

        }
    
        

    
        //movement
        Vector2 xMov = new Vector2(Input.GetAxisRaw("Horizontal") * transform.right.x, Input.GetAxisRaw("Horizontal") * transform.right.z);
        Vector2 zMov = new Vector2(Input.GetAxisRaw("Vertical") * transform.forward.x, Input.GetAxisRaw("Vertical") * transform.forward.z);

        Vector2 velocity = (xMov + zMov).normalized * speed * Time.deltaTime;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.y);
        //Rotation
        float yRot = Input.GetAxisRaw("Mouse X") * xSensitivity * ySensitivity;
        rb.rotation *= Quaternion.Euler(0, yRot * xSensitivity, 0);

        float xRot = Input.GetAxisRaw("Mouse Y") * xSensitivity;
        float x_cam_rot = cam.transform.eulerAngles.x;
        x_cam_rot -= xRot;

        float camEulerAngleX = cam.transform.localEulerAngles.x;
        camEulerAngleX -= xRot;

        cam.transform.localEulerAngles = new Vector3(camEulerAngleX, 0, 0);

        //CLamping
        if(camEulerAngleX < 180)
        {
            camEulerAngleX += 360;
        }
        camEulerAngleX = Mathf.Clamp(camEulerAngleX, 270, 450);

        //Cursor Lock
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        //Jumping
        bool isGrounded = Physics.OverlapBox(jumpCheck.transform.position, jumpCheckSize).Length > 1;

        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        void Jump()
        {
            rb.AddForce(0, jumpForce, 0);
        }


    }
  
}
