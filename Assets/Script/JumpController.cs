using UnityEngine;

public class JumpController : MonoBehaviour
{
    private Animator animator;
    private bool isJumping = false;

    void Start()
    {
        animator = GetComponent<Animator>();  
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();  
        }
    }

    void Jump()
    {
        isJumping = true;
        animator.SetBool("IsJumping", true);  

        
        Invoke("StopJump", 0.98f);
    }

    void StopJump()
    {
        isJumping = false;
        animator.SetBool("IsJumping", false);  
    }
}
