using UnityEngine;

public class StartAnimiControl : MonoBehaviour
{
    public Animator animator;

    void OnMouseEnter()
    {
        animator.Play("StartCatAnim");
    }

    void OnMouseExit()
    {
        animator.Play("StartCatAnim2");
    }
}
