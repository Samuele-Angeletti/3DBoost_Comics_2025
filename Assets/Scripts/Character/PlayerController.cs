using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] bool isActive;
    [SerializeField] Transform rightHandObject;
    [SerializeField] Transform targetObject;
    Animator bodyController;

    private void Awake()
    {
        bodyController = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (isActive)
        {
            if (targetObject != null)
            {
                bodyController.SetLookAtWeight(1);
                bodyController.SetLookAtPosition(targetObject.position);
            }

            if (rightHandObject != null)
            {
                bodyController.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                bodyController.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                bodyController.SetIKPosition(AvatarIKGoal.RightHand, rightHandObject.position);
                bodyController.SetIKRotation(AvatarIKGoal.RightHand, rightHandObject.rotation);
            }
        }
        else
        {
            bodyController.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            bodyController.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            bodyController.SetLookAtWeight(0);
        }
    }
}
