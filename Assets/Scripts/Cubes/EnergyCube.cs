using UnityEngine;

public class EnergyCube : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        WindCube windCube = other.gameObject.GetComponent<WindCube>();

        if (windCube != null )
        {

            windCube.EnableWind(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {

        WindCube windCube = other.gameObject.GetComponent<WindCube>();

        if (windCube != null)
        {
            windCube.EnableWind(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        WindCube windCube = other.gameObject.GetComponent<WindCube>();

        if (windCube != null)
        {

            windCube.EnableWind(true);
        }
    }
}
