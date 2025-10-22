using UnityEngine;
using UnityEngine.Events;

public class RestartButtonContoller : MonoBehaviour
{

    public UnityEvent gameRestart;

    public void ButtonClick()
    {
        gameRestart.Invoke();
    }

}
