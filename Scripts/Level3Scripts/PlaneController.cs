using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] float controlSpeed = 400f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 5f;
    [SerializeField] float rollSpeed = 10f;


    float yThrow, xThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void ProcessRotation()
    {
        float rollDueToControlThrow = xThrow * rollSpeed;
        transform.localRotation = Quaternion.Euler(0f, 0f, -rollDueToControlThrow);
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float clampedXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float clampedYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

   

}
