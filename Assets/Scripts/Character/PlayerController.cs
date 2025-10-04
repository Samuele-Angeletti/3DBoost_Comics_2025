using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] bool isActive;
    [SerializeField] Transform rightHandObject;
    [SerializeField] Transform targetObject;
    [SerializeField] float movementSpeed = 10f;
    Animator bodyController;

    private void Awake()
    {
        bodyController = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isActive)
        {
            rightHandObject.position = Vector3.Lerp(rightHandObject.position, targetObject.position, Time.deltaTime * movementSpeed);
        }
    }
}
