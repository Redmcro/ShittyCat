using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warden : MonoBehaviour
{
    public Sprite idleSprite;
    public Sprite prepareWalkSprite;
    public Sprite discoverWalkSprite;
    public Animator playerAnimator;
    public GameManager gameManager;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WardenBehavior());

    }

    void Update()
    {
    }

    IEnumerator WardenBehavior()
    {
        while(gameManager.isRunning)
        {
            spriteRenderer.sprite = idleSprite;
            yield return new WaitForSeconds(Random.Range(1f, 3f));

            spriteRenderer.sprite = prepareWalkSprite;
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));

            spriteRenderer.sprite = discoverWalkSprite;
            float discoverTime = Random.Range(1f, 3f);
            float timer = 0f;
            while(timer < discoverTime)
            {
                if (playerAnimator.GetBool("IsWalking"))
                {
                    SceneManager.LoadScene("EndScene");
                    yield break;
                }
                timer += Time.deltaTime;
                yield return null;
            }

            spriteRenderer.sprite = idleSprite;
        }
    }
}
