using UnityEngine;
using UnityEngine.SceneManagement;

public class CatMove : MonoBehaviour
{
    public Animator animator;
    public GameManager gameManager;
    public float maxSpeed = 5f;
    public float acceleration = 2f;
    public float deceleration = 2f;
    public SpriteMask spriteMask;

    private float currentSpeed = 0f;
    private Vector3 initialMaskScale;
    private float initialCatX;

    void Start()
    {
        initialMaskScale = spriteMask.transform.localScale;
        initialCatX = transform.position.x;
    }

    void Update()
    {
        float currentX = transform.position.x;
        if (currentX <= 7)
        {
            HandleMovement();
        }
        else
        {
            StopMovement();
        }     
    }

    void HandleMovement()
    {
        if(Input.GetKey(KeyCode.Space))
            {
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
            animator.SetBool("IsWalking",true);
            
            }
        else
            {
            currentSpeed = Mathf.Max(currentSpeed - deceleration * Time.deltaTime, 0);
            animator.SetBool("IsWalking", false);
            }
        transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);
        spriteMask.transform.localScale = new Vector3(
                initialMaskScale.x + (transform.position.x - initialCatX) * 2,
                initialMaskScale.y,
                initialMaskScale.z
            );
    }

    void StopMovement()
    {
        animator.SetBool("IsWalking", false);
        currentSpeed = 0f;
        gameManager.StopTimer();
        SceneManager.LoadScene("WinScene");
    }
}