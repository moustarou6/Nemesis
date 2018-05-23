using UnityEngine;
using System.Collections;

public class MenuFlow : MonoBehaviour {

    private static MenuFlow instance = null;
    public static MenuFlow Instance
    {
		get {
            if (instance == null) instance = FindObjectOfType(typeof(MenuFlow)) as MenuFlow;
			return instance;
		}
	}

    public GameState CurrentStateValue;
 	public enum GameState
	{
		STATE_None = -1,
		STATE_View,
        STATE_Market
	};
	public GameState GetCurrentStateValue() { return CurrentStateValue; }
	
	public void Start() {
		CurrentStateValue = GameState.STATE_None;
        ChangeState(GameState.STATE_None);
	}
	
	
	
	public void ChangeState(GameState newState)
	{
        Debug.Log("BroadcastMessage : " + newState + "--" + CurrentStateValue);
		if (newState != CurrentStateValue)
		{
			BroadcastMessage("ExitState", CurrentStateValue, SendMessageOptions.DontRequireReceiver);
			
			CurrentStateValue = newState;
		
			BroadcastMessage("EnterState", CurrentStateValue, SendMessageOptions.DontRequireReceiver);
		}
	}
}
