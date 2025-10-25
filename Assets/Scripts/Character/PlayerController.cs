using Assets.Scripts.Character;
using Assets.Scripts.Enums;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CommonStateSettings IdleSettings;
    public CommonStateSettings WalkSettings;
    public CommonStateSettings EnterCarSettings;
    public CommonStateSettings DriveSettings;
    public CommonStateSettings ExitCarSettings;
    GenericStateMachine<CharacterStateEnum> stateMachine;
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();

        stateMachine = new();
        stateMachine.RegisterState(CharacterStateEnum.Idle, new IdleCharacterState(this, _animator));
        stateMachine.RegisterState(CharacterStateEnum.Walk, new WalkCharacterState(this, _animator));
        stateMachine.RegisterState(CharacterStateEnum.EnterCar, new EnterCarCharacterState(this, _animator));
        stateMachine.RegisterState(CharacterStateEnum.Drive, new DriveCharacterState(this, _animator));
        stateMachine.RegisterState(CharacterStateEnum.ExitCar, new ExitCarCharacterState(this, _animator));

        SetIdle();
    }

    #region STATE MACHINE SETTERS
    [ContextMenu("Set Idle")]
    public void SetIdle()
    {
        stateMachine.SetState(CharacterStateEnum.Idle);
    }
    [ContextMenu("Set Walk")]
    public void SetWalk()
    {
        stateMachine.SetState(CharacterStateEnum.Walk);
    }
    [ContextMenu("Set Enter Car")]
    public void SetEnterCar()
    {
        stateMachine.SetState(CharacterStateEnum.EnterCar);
    }
    [ContextMenu("Set Drive")]
    public void SetDrive()
    {
        stateMachine.SetState(CharacterStateEnum.Drive);
    }
    [ContextMenu("Set Exit Car")]
    public void SetExitCar()
    {
        stateMachine.SetState(CharacterStateEnum.ExitCar);
    }
    #endregion

    private void Update()
    {
        stateMachine.OnUpdate();
    }
}

[Serializable]
public class CommonStateSettings
{
    [Tooltip("Trigger per attivare l'animazione")]
    public string AnimationTrigger;
    [Tooltip("Animazione corrispondente nell'animator")]
    public AnimationClip Clip;
}