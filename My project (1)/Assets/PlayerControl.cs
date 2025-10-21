using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator anim;
    public float moveSpeed;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetFloat("Height", GetComponent<Rigidbody2D>().velocity.y);
        anim.SetBool("Grounded", grounded);



        if(Input.GetKeyDown(Spacebar)&& grounded){
            Jump();
        }

         if(Input.GetKey(L)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,GetComponent<Rigidbody2D>().velocity.y);
        
        if(GetComponent<SpriteRenderer>()!=null){
            GetComponent<SpriteRenderer>().flipX=true;
        
        }
        
        }
         if(Input.GetKeyDown(R)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed,GetComponent<Rigidbody2D>().velocity.y);        
        
            if(GetComponent<SpriteRenderer>()!=null){
                GetComponent<SpriteRenderer>().flipX=true;
            }

        }

    
    }

    void Jump(){
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
    }

    void FixedUpdate(){
        grounded=Physics2D.OverlapCircle(groundCheck.position ,groundCheckRadius, whatIsGround);
    }
}
