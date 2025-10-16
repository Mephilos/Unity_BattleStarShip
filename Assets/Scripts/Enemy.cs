using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;

    
    void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
