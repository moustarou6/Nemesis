using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewManager : MonoBehaviour, IVew
{

    public MenuFlow.GameState trigger = MenuFlow.GameState.STATE_None;
    private bool AlwaysActivate = false;

    void Awake()
    {
        if (!AlwaysActivate)
        {
            GetComponent<CanvasGroup>().alpha = 0;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        else
            StartInterface();
    }

    public virtual void ExitState(MenuFlow.GameState state)
    {
        if (!AlwaysActivate)
        {
            Debug.Log("ExitState - " + state);
            if (state == trigger) {

                GetComponent<CanvasGroup>().alpha = 0;
                GetComponent<CanvasGroup>().blocksRaycasts = false;

            } ;
        }
    }

    public virtual void EnterState(MenuFlow.GameState state)
    {
        if (!AlwaysActivate)
        {
            Debug.Log("EnterState " + state);
            if (state == trigger)
            {
                GetComponent<CanvasGroup>().alpha = 1;
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                StartInterface();
            }
        }
    }

    public virtual void StartInterface()
    {
    }

    public virtual void ExitInterface()
    { }

}
