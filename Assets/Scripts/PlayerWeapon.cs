using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] laserParticles;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 200f;
    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
    }

    private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    public void OnFire(InputValue input)
    {
        isFiring = input.isPressed;
    }

    void ProcessFiring()
    {
        foreach (var laser in laserParticles)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }
    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }
}
