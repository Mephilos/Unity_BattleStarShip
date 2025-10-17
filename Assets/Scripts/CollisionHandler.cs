using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] Collider[] hitboxes;
    [SerializeField] GameObject playerDestroyVFX;

    GameSceneManager gameSceneManager;
    void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();

        hitboxes = GetComponentsInChildren<Collider>();

        foreach (var hitbox in hitboxes)
        {
            hitbox.isTrigger = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        gameSceneManager.ReloadMap();
        Instantiate(playerDestroyVFX, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
