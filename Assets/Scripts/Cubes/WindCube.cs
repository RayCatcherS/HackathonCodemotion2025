using System.Security.Cryptography;
using UnityEngine;

public class WindCube : ActivatableItem
{
    [SerializeField] private float windCubeForce = 1.0f;
    [SerializeField] private bool windEnabled = false;

    [Header("Material References")]
    [SerializeField] MeshRenderer feedBackMeshRenderer;
    [SerializeField] private Material enabledMaterial;
    [SerializeField] private Material disabledMaterial;

    // states
    private bool blockStateActive = false;


    private void Start()
    {
        EnableWind(windEnabled);
    }

    public void EnableWind(bool enabled)
    {


        blockStateActive = enabled;
        if (enabled ) {

            feedBackMeshRenderer.material = enabledMaterial;
        } else{
            feedBackMeshRenderer.material = disabledMaterial;
        }
    }

    public override void EnableItem(bool enabled)
    {
        EnableWind(enabled);
    }


    private void ApplyForceToRB(Rigidbody rb, Vector3 direction)
    {
        if (rb != null)
        {
            rb.AddForce(direction * windCubeForce);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        // ignora se l'altro collider è un trigger
        if (other.isTrigger) return;

        if (blockStateActive)
        {
            Rigidbody rb = null;
            rb = other.GetComponent<Rigidbody>();

            // set cube direction
            ApplyForceToRB(rb, transform.up);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {

        // ignora se l'altro collider è un trigger
        if (other.isTrigger) return;

        if (blockStateActive)
        {
            Rigidbody rb = null;
            rb = other.GetComponent<Rigidbody>();
            ApplyForceToRB(rb, transform.up);
        }
    }

    // enable debug by editor
    [ContextMenu("enable wind")]
    public void DebugEneableWind() { EnableWind(true); }
    [ContextMenu("disable wind")]
    public void DebugDisableWind() { EnableWind(false); }
}
