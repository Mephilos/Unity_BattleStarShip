using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 25f;
    [SerializeField] float xClampRange = 11f, yClampRange = 7f;

    [SerializeField] float controlPitchFactor = 25f;
    [SerializeField] float controlRollFactor = 25f;
    [SerializeField] float rotationSpeed = 10f;
    
    Vector2 movement;
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void OnMove(InputValue val)
    {
        movement = val.Get<Vector2>();
    }

    void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);
        float clampYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampXPos, clampYPos, 0f);
    }
    
    void ProcessRotation()
    {
        float pitch = -controlPitchFactor * movement.y;
        float roll = -controlRollFactor * movement.x;

        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
        
    }

}
