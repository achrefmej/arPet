using UnityEngine;
using UnityEngine.UI;

public class GyroscopeController : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private GameObject image;
    void Start()
    {
        // Vérifiez si le gyroscope est pris en charge
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
        else
        {
            Debug.LogError("Le gyroscope n'est pas pris en charge sur cet appareil.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Accédez aux données du gyroscope
        Quaternion gyroRotation = Input.gyro.attitude;

        // Obtenez les angles d'inclinaison en degrés
        float tiltX = gyroRotation.eulerAngles.x;
        float tiltY = gyroRotation.eulerAngles.y;
        float tiltZ = gyroRotation.eulerAngles.z;

        bool x = Mathf.Abs(tiltX) >= 0 && Mathf.Abs(tiltX) <= 30;
        bool y = Mathf.Abs(tiltY) >= 0 && Mathf.Abs(tiltY) <= 30;
        bool z = Mathf.Abs(tiltZ) >= 0 && Mathf.Abs(tiltZ) <= 30;

        // Comparez l'angle d'inclinaison pour déterminer si le téléphone est plat
        if (x) // Ajustez cet angle selon vos besoins
        {
            // Téléphone plat sur la table
            text.text = "Sur la table avec X = "+ tiltX.ToString()+" Y = "+ tiltY.ToString() + " Z = "+ tiltZ.ToString();
            image.SetActive(true);
        }
        else
        {
            // Téléphone incliné
            text.text = "incliné avec X = " + tiltX.ToString() + " Y = " + tiltY.ToString() + " Z = " + tiltZ.ToString();
            image.SetActive(false);
        }
    }
}
