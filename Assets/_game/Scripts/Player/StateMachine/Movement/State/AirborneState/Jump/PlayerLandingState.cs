using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandingState : PlayerGroundedState
{
    float landingTime = 0.15f;
    float timer;
    public PlayerLandingState(PlayerMovementStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timer = 0;
        stateMachine.playerStateReusebleData.MovementSpeedMotifier = 0;
        ResetVelocity();
    }
    public override void Update()
    {
        base.Update();
        timer += Time.deltaTime;
        if (timer >= landingTime)
        {
            stateMachine.ChangeState(stateMachine.idleState);
        }
    }
    protected override void AddInoutActionsCallback()
    {
        base.AddInoutActionsCallback();
        stateMachine.player.playerInput.PlayerActions.WalkToggle.started += OnWalkToggleStarted;
        stateMachine.player.playerInput.PlayerActions.Movement.canceled += OnMovementCanceled;

    }

    protected override void RemoveInputActionsCallback()
    {
        base.RemoveInputActionsCallback();
        stateMachine.player.playerInput.PlayerActions.WalkToggle.started -= OnWalkToggleStarted;
        stateMachine.player.playerInput.PlayerActions.Movement.canceled -= OnMovementCanceled;
    }
}
