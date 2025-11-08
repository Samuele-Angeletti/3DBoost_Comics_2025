using UnityEngine;

namespace Assets.Scripts.Character
{
    public class EnterCarCharacterState : State
    {
        readonly PlayerController _owner;
        readonly Animator _animator;
        readonly float _clipLength;
        float _timePassed;

        public EnterCarCharacterState(PlayerController owner, Animator animator)
        {
            _owner = owner;
            _animator = animator;
            _clipLength = _owner.EnterCarSettings.Clip.length;
        }

        public override void OnStart()
        {
            _animator.SetTrigger(_owner.EnterCarSettings.AnimationTrigger);
            _timePassed = 0;
        }

        public override void OnUpdate()
        {
            // TODO: SE HO RAGGIUNTO IL PIVOT, ALLORA RUOTARE IL PERSONAGGIO FINO AL DRIVE PIVOT DELLA MACCHINA
            // SENZA CAMBIARE STATO

            _timePassed += Time.deltaTime;
            if (_timePassed >= _clipLength)
            {
                _owner.SetDrive();
            }
        }

        public override void OnFixedUpdate()
        {

        }

        public override void OnEnd()
        {

        }
    }
}
