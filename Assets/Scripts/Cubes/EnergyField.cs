using UnityEngine;

public class EnergyField : ActivatableItem
{

    [Header("Energy field settings")]
    [SerializeField] private float energyFieldRadius = 5f;
    [SerializeField] private Transform energyFieldTransform;

    private void Start()
    {
        energyFieldTransform.transform.localScale = new Vector3(energyFieldRadius, energyFieldRadius, energyFieldRadius);

        EnableForceField(false);
    }

    public void SetEnergyFieldRadius(float radius)
    {
        energyFieldRadius = radius;
    }

    public override void EnableItem(bool enabled)
    {
        EnableForceField(enabled);
    }

    public void EnableForceField(bool enabled)
    {   
        if(enabled)
        {
            feedBackMeshRenderer.material = enabledMaterial;
            energyFieldTransform.gameObject.SetActive(true);
            pointLight.color = enabledLight;
        } else
        {
            feedBackMeshRenderer.material = disabledMaterial;
            energyFieldTransform.gameObject.SetActive(false);
            pointLight.color = disabledLight;
        }
        
    }



    private void OnTriggerEnter(Collider other)
    {

        WindCube windCube = other.gameObject.GetComponent<WindCube>();
        EnergyField energyField = other.gameObject.GetComponent<EnergyField>();
        Base baseItem = other.gameObject.GetComponent<Base>();


        if (windCube != null)
        {

            windCube.EnableWind(true);
        }
        if (energyField != null)
        {
            energyField.EnableForceField(true);
        }
        if (baseItem != null)
        {
            baseItem.EnableItem(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {

        WindCube windCube = other.gameObject.GetComponent<WindCube>();
        EnergyField energyField = other.gameObject.GetComponent<EnergyField>();
        Base baseItem = other.gameObject.GetComponent<Base>();


        if (windCube != null)
        {
            windCube.EnableWind(false);
        }
        if (energyField != null)
        {
            energyField.EnableForceField(false);
        }
        if (baseItem != null)
        {
            baseItem.EnableItem(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        WindCube windCube = other.gameObject.GetComponent<WindCube>();
        EnergyField energyField = other.gameObject.GetComponent<EnergyField>();
        Base baseItem = other.gameObject.GetComponent<Base>();



        if (windCube != null)
        {
            windCube.EnableWind(true);
        }
        if (energyField != null)
        {
            energyField.EnableForceField(true);
        }
        if (baseItem != null)
        {
            baseItem.EnableItem(true);
        }
    }




    // enable debug by editor
    [ContextMenu("enable field")]
    public void DebugEneableWind() { EnableForceField(true); }
    [ContextMenu("disable field")]
    public void DebugDisableWind() { EnableForceField(false); }
}
