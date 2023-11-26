using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAggro : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<aggro>().aggroState();
    }
    void OnCollisionStay(Collision collission)
    {
        OnCollisionEnter(collission);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
