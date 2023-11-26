using UnityEngine;
using UnityEngine.AI;

public class aggro : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
    }
    public void aggroState()
    {
        agent.SetDestination(player.transform.position);
    }
}
