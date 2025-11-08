using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Character
{
    public class WalkAgentCharacterState : State
    {
        readonly PlayerController _owner;
        readonly Animator _animator;
        float _timePassed;
        public WalkAgentCharacterState(PlayerController owner, Animator animator)
        {
            _owner = owner;
            _animator = animator;
        }

        public override void OnStart()
        {
            _animator.SetTrigger(_owner.WalkAgentSettings.AnimationTrigger);
            _timePassed = 0;
            _owner.SetAgentDestination(_owner.CurrentCar.AccessPivot);
        }

        public override void OnUpdate()
        {
            // se l'utente preme spazio, allora annulla l'operazione
            // TODO:...

            if (_owner.Agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                // ho raggiunto la destinazione

                // TODO: QUI FARE IN MODO CHE L'OWNER SI GIRI FINO ALLA STESSA ROTAZIONE DELL'ACCESSPIVOT DELLA MACCHINA
                // SENZA USCIRE DA QUESTO STATO.

                // QUANDO SONO ABBASTANZA GIRATO, ENTRO IN MACCHINA
                _owner.SetEnterCar();
                return;
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
