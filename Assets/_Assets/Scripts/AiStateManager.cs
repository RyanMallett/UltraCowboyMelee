using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiStateManager : MonoBehaviour {

    public AiDude.AiState selectedState = AiDude.AiState.Wonder;
    public GameObject aiObj;
    AiDude ai;
	// Use this for initialization
	void Start () {
        ai = aiObj.GetComponent<AiDude>();
	}
	
	// Update is called once per frame
	void Update () {
        //ai.ChangeState(selectedState);
	}
}
