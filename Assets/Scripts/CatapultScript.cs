using UnityEngine;

public class CatapultScript : MonoBehaviour
{
    public Transform launchPosition;
    public Rigidbody ammoBody;
    private Vector3 launchDirection = new Vector3(0, 1, 1);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
    }
    void Launch()
    {
        ammoBody.isKinematic = false;
        ammoBody.AddForce(launchDirection, ForceMode.Impulse);
    }
}
