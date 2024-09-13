using UnityEngine;

public class ShitSpawn : MonoBehaviour
{
    public Sprite[] shitTrackPrefabs;
    public float shitSpacing = 1f;
    public float totalDistance = 14f;
    public Transform cat;

    private GameObject[] shitTracks;
    

    void Start()
    {
        GenerateShitTrack();
    }

    void Update()
    {       
    }

    void GenerateShitTrack()
    {
        int shitCounts = Mathf.FloorToInt(totalDistance / shitSpacing);
        shitTracks = new GameObject[shitCounts];

        for (int i = 0; i < shitCounts; i++)
        {
            Sprite randomTrackPrefab = shitTrackPrefabs[Random.Range(0, shitTrackPrefabs.Length)];
            
            GameObject newShitTrack = new GameObject("ShitTrack_" + i);
            SpriteRenderer spriteRenderer = newShitTrack.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = randomTrackPrefab;

            float catPosition = cat.position.x;
            Vector3 position = new Vector3(i * shitSpacing + catPosition - 0.5f, -4, 0);
            newShitTrack.transform.position = position;
            newShitTrack.transform.localScale = transform.localScale;
            spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;

            shitTracks[i] = newShitTrack;
        }
    }
}
