using UnityEngine;

namespace Assets.Scripts.Character
{
    public class WalkCharacterState : State
    {
        readonly PlayerController _owner;
        readonly Animator _animator;
        float _timePassed;
        readonly Rigidbody _rigidbody;
        public WalkCharacterState(PlayerController owner, Animator animator)
        {
            _owner = owner;
            _animator = animator;
            _rigidbody = _owner.GetComponent<Rigidbody>();
        }

        public override void OnStart()
        {
            _rigidbody.isKinematic = false;

            _animator.SetTrigger(_owner.WalkSettings.AnimationTrigger);
            _timePassed = 0;
        }

        public override void OnUpdate()
        {
            _owner.transform.rotation = 
                Quaternion.Euler(
                    new Vector3(
                        _owner.transform.rotation.eulerAngles.x,
                        Mathf.Lerp(_owner.transform.rotation.eulerAngles.y, _owner.CameraTransform.rotation.eulerAngles.y, _owner.RotationSpeed * Time.fixedTime),
                        _owner.transform.rotation.eulerAngles.z
                        )
                    );

            if (_owner.Direction == Vector3.zero)
            {
                _owner.SetIdle();
                return;
            }
        }

        //Vector3 dir = 
        //    _owner.transform.forward * _owner.Direction.z + 
        //    _owner.transform.right * _owner.Direction.x + 
        //    _owner.transform.up * _owner.Direction.y;
        public override void OnFixedUpdate()
        {
            Vector3 dir2 = _owner.CameraTransform.TransformDirection(_owner.Direction);

            _rigidbody.AddForce(
                _owner.Acceleration * 
                Time.fixedDeltaTime *
                dir2);

            _rigidbody.linearVelocity =
                new Vector3(
                    Mathf.Clamp(_rigidbody.linearVelocity.x, -_owner.MaxSpeed, _owner.MaxSpeed),
                    _rigidbody.linearVelocity.y,
                    Mathf.Clamp(_rigidbody.linearVelocity.z, -_owner.MaxSpeed, _owner.MaxSpeed));
        }

        public override void OnEnd()
        {

        }
    }
}
