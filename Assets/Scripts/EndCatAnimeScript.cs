using System.Collections;
using UnityEngine;

public class EndCatAnimeScript : MonoBehaviour
{
    public Animator animator;
    public float minDelay = 3f;
    public float maxDelay = 5f;

    void Start()
    {
        StartCoroutine(PlayAnimi());
    }

    IEnumerator PlayAnimi()
    {
        while(true)
        {
            animator.Play("EndCatAnim", 0, 0f);
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        }
    }
}
