using UnityEngine;
using UnityEngine.AI;

public class RoverBehavior : MonoBehaviour {
    protected NavMeshAgent agent;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveTo(Vector3 destination) {
        agent.SetDestination(destination);
    }
}
