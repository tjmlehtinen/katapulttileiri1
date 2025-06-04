using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private bool hasScored = false;
    void OnCollisionEnter(Collision collision)
    {
        if (!hasScored && collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("osuu maahan");
            hasScored = true;
        }
    }
}
