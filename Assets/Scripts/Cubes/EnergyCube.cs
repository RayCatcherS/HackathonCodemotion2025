using UnityEngine;

public class EnergyCube : MonoBehaviour
{

    
    private void OnTriggerEnter(Collider other)
    {

        WindCube windCube = other.gameObject.GetComponent<WindCube>();
        EnergyField energyField = other.gameObject.GetComponent<EnergyField>();


        if (windCube != null )
        {

            windCube.EnableWind(true);
        }
        if (energyField != null)
        {
            energyField.EnableForceField(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {

        WindCube windCube = other.gameObject.GetComponent<WindCube>();
        EnergyField energyField = other.gameObject.GetComponent<EnergyField>();

        if (windCube != null)
        {
            windCube.EnableWind(false);
        }
        if (energyField != null) { 
            energyField.EnableForceField(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        WindCube windCube = other.gameObject.GetComponent<WindCube>();
        EnergyField energyField = other.gameObject.GetComponent<EnergyField>();


        if (windCube != null)
        {
            windCube.EnableWind(true);
        }
        if (energyField != null)
        {
            energyField.EnableForceField(true);
        }
    }
}
