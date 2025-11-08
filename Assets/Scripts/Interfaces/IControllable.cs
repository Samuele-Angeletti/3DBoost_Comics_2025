using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IControllable
    {
        void Move(Vector3 direction);
        void MoveCanceled();
        void Interact();
    }
}