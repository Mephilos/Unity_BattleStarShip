using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] Collider[] hitboxes;
    [SerializeField] GameObject playerDestroyVFX;

    void Start()
    {
        hitboxes = GetComponentsInChildren<Collider>();

        foreach (var hitbox in hitboxes)
        {
            hitbox.isTrigger = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Instantiate(playerDestroyVFX, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
