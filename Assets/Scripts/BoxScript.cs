using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private bool hasScored = false;
    void OnCollisionEnter(Collision collision)
    {
        if (!hasScored && collision.gameObject.CompareTag("Ground"))
        {
            ScoreManager.Instance.AddScore(10);
            hasScored = true;
        }
    }
}
