using UnityEngine;

public class WireTouchTrigger : MonoBehaviour
{
    public VoltageMeter voltageMeter; // Drag ton GameObject Multimeter ici
    public GameObject wire1;          // Drag ton fil 1 ici
    public GameObject wire2;          // Drag ton fil 2 ici

    private bool wire1Touched = false;
    private bool wire2Touched = false;

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si le fil qui touche la sphère est wire1 ou wire2
        if (other.gameObject == wire1)
            wire1Touched = true;

        if (other.gameObject == wire2)
            wire2Touched = true;

        // Si les deux fils touchent la sphère, lance la mesure
        if (wire1Touched && wire2Touched)
        {
            voltageMeter.StartMeasuring();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si un fil quitte la sphère, le marque comme non-touché
        if (other.gameObject == wire1)
            wire1Touched = false;

        if (other.gameObject == wire2)
            wire2Touched = false;

        // Si un des fils quitte, reset le multimètre
        if (!wire1Touched || !wire2Touched)
        {
            voltageMeter.ResetMeter();
        }
    }
}