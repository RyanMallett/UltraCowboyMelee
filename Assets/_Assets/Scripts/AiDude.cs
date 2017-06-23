using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDude : MonoBehaviour {

    GameObject player;
    Player playerScript;
    Rigidbody rb;

    public float aiMoveSpeed;

    public enum AiState { Wonder, Chase, Flee }

    AiState currentState = AiState.Wonder;

    Vector3 wonderPosition;
    public float wonderDist = 2.0f;

    public float timeTillStateChange = 1.0f;
    float stateChangeTimer;

    // Use this for initialization
    void Start () {
        player =  GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
        wonderPosition = Random.insideUnitSphere * wonderDist;
        wonderPosition.y = 1 ;
        rb = gameObject.GetComponent<Rigidbody>();
        stateChangeTimer = timeTillStateChange;
    }
	
	// Update is called once per frame
	void Update () {
        stateChangeTimer -= Time.deltaTime;
        if  (stateChangeTimer <= 0) {
            ChangeState((AiState)Random.Range(0, 3));
            stateChangeTimer = timeTillStateChange;
        }

        switch (currentState) {
            case AiState.Wonder:
                Wonder();
                break;
            case AiState.Chase:
                Chase();
                break;
            case AiState.Flee:
                Flee();
                break;
            default:
                break;
        }       
	}

    void Wonder() {
        if (Vector3.Distance(transform.position, wonderPosition) <= 0) {
            wonderPosition = Random.insideUnitSphere * wonderDist;
            wonderPosition.y = 1;
        }
       
        transform.position = Vector3.MoveTowards(transform.position, wonderPosition, aiMoveSpeed * Time.deltaTime);
    }

    void Chase() {
        transform.position = Vector3.MoveTowards(transform.position, player.gameObject.transform.position, aiMoveSpeed * Time.deltaTime);
    }

    void Flee() {
        Vector3 moveDir = player.gameObject.transform.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, transform.position - moveDir, aiMoveSpeed * Time.deltaTime);
    }

    public void ChangeState(AiState newState) {
        Debug.Log(newState);
        currentState = newState;
    }
}
