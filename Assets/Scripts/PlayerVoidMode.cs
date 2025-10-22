using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerVoidMode : MonoBehaviour
{
    public Animator animator;
    public RuntimeAnimatorController echoController;
    public RuntimeAnimatorController voidController;
    private int contamination = 0;
    public int maxContamination = 5;
    public IntGameEvent contaminationChangeEvent;
    private bool echo = true; // Echo <--> Void (mode)
    private Coroutine contaminationRoutine;

    public void OnVoidEnabled()
    {
        GetComponent<EchoStateController>().SetPowerup(PowerupType.Void);
    }

    public void OnSwap(bool b)
    {
        if (!b) return;
        var StateController = GetComponent<EchoStateController>();
        if (StateController.currentState.name != "Void") return;
        Debug.Log("Swapped!");
    }

    public void ExitVoid()
    {
        echo = true;
        animator.runtimeAnimatorController = echo ? echoController : voidController;
        if (contaminationRoutine != null) StopCoroutine(contaminationRoutine);
        contaminationRoutine = null;
    }

    private IEnumerator IncreaseContamination()
    {
        var wait = new WaitForSeconds(1f);
        while (!echo) // Void 모드에서만 감소
        {
            contamination = Mathf.Min(maxContamination, contamination + 1);
            contaminationChangeEvent.Raise(contamination);

            if (Mathf.Approximately(contamination, maxContamination))
            {
                ExitVoid();
                yield break;
            }
            yield return wait;
        }
    }

}
