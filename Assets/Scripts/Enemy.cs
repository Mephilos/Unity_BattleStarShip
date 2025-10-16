using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;
    [SerializeField] int hitPoint = 3;
    [SerializeField] int scoreValue = 1;
    Scoreboard scoreboard;

    void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoint--;

        if (hitPoint <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(destroyVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
