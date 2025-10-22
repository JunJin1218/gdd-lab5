using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EchoState
{
    Default = -1,
    EchoState = 0,
    DashState = 1,
    VoidState = 2,
    InvincibleEcho = 3,
    DeadEcho = 99
}

public class EchoStateController : StateController
{
    public PowerupType currentPowerupType = PowerupType.Default;
    public EchoState shouldBeNextState = EchoState.Default;
    public GameVariables gameVariables;
    private SpriteRenderer spriteRenderer;


    public override void Start()
    {
        base.Start();
        GameRestart(); // clear powerup in the beginning, go to start state
    }

    // this should be added to the GameRestart EventListener as callback
    public void GameRestart()
    {
        // clear powerup
        currentPowerupType = PowerupType.Default;
        // set the start state
        TransitionToState(startState);
    }

    public void SetPowerup(PowerupType i)
    {
        currentPowerupType = i;
    }

    public void SetRendererToFlicker()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(BlinkSpriteRenderer());
    }
    private IEnumerator BlinkSpriteRenderer()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        while (string.Equals(currentState.name, "InvincibleSmallMario", StringComparison.OrdinalIgnoreCase))
        {
            // Toggle the visibility of the sprite renderer
            spriteRenderer.enabled = !spriteRenderer.enabled;

            // Wait for the specified blink interval
            yield return new WaitForSeconds(gameVariables.flickerInterval);
        }

        spriteRenderer.enabled = true;
    }

}