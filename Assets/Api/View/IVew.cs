using UnityEngine;
using System.Collections;

interface IVew 
{
    void ExitState(MenuFlow.GameState state);
    void EnterState(MenuFlow.GameState state);
    void StartInterface();
}
