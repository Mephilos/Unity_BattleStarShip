using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] Collider[] hitboxes;

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
        Debug.Log($"Hit {other.gameObject.name}");
    }
}
