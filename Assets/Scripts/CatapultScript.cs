using UnityEngine;
using UnityEngine.UI;
using System;

public class CatapultScript : MonoBehaviour
{
    public Transform launchPosition;
    public Rigidbody ammoBody;
    public Transform turret;
    public Animator armAnimator;
    public Slider forceSlider;
    public Slider angleSlider;
    public Vector3 launchDirection = new Vector3(0, 1, 1);
    public float launchForce = 10f;
    public float launchAngle = 1;
    public float rotationSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        forceSlider.onValueChanged.AddListener(delegate {ForceSliderChange();});
        angleSlider.onValueChanged.AddListener(delegate {AngleSliderChange();});
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetCatapult();
        }
        HandleRotation();
    }
    void Launch()
    {
        ammoBody.isKinematic = false;
        launchDirection = turret.forward * MathF.Cos(launchAngle) + Vector3.up * MathF.Sin(launchAngle);
        ammoBody.AddForce(launchDirection.normalized * launchForce, ForceMode.Impulse);
        ammoBody.transform.parent = null;
        armAnimator.SetTrigger("Launch");
    }
    void ResetCatapult()
    {
        ammoBody.isKinematic = true;
        ammoBody.transform.position = launchPosition.position;
        ammoBody.transform.parent = launchPosition;
    }
    void HandleRotation()
    {
        float rotation = Input.GetAxis("Horizontal");
        turret.Rotate(Vector3.up, rotation * rotationSpeed * Time.deltaTime);
    }
    public void ForceSliderChange()
    {
        launchForce = forceSlider.value * 40f;
    }
    public void AngleSliderChange()
    {
        launchAngle = angleSlider.value * (MathF.PI / 2);
    }
}
