using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private RespawnScript rsp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rsp = GameObject.FindGameObjectWithTag("Point").GetComponent<RespawnScript>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rsp.respawnPoint = this.gameObject;
            Debug.Log("CheckPoint");
        }
    }
}
