using UnityEngine;

public class IdleStateController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        
       // InvokeRepeating(nameof(SwitchIdleAnimation), 0f, 3f); // pour changer d'anim toutes les 3 secondes
       SwitchIdleAnimation();
    }

    void SwitchIdleAnimation()
    {
        int randomIdle = Random.Range(0, 2); 
        animator.SetFloat("IdleType", randomIdle);
        Debug.Log("anim idle en cours: " + randomIdle);
    }
}
