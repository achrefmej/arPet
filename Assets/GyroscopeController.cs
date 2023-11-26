using UnityEngine;
using UnityEngine.UI;

public class GyroscopeController : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private GameObject image;
    void Start()
    {
        // V�rifiez si le gyroscope est pris en charge
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
        // Acc�dez aux donn�es du gyroscope
        Quaternion gyroRotation = Input.gyro.attitude;

        // Obtenez les angles d'inclinaison en degr�s
        float tiltX = gyroRotation.eulerAngles.x;
        float tiltY = gyroRotation.eulerAngles.y;
        float tiltZ = gyroRotation.eulerAngles.z;

        bool x = Mathf.Abs(tiltX) >= 0 && Mathf.Abs(tiltX) <= 30;
        bool y = Mathf.Abs(tiltY) >= 0 && Mathf.Abs(tiltY) <= 30;
        bool z = Mathf.Abs(tiltZ) >= 0 && Mathf.Abs(tiltZ) <= 30;

        // Comparez l'angle d'inclinaison pour d�terminer si le t�l�phone est plat
        if (x) // Ajustez cet angle selon vos besoins
        {
            // T�l�phone plat sur la table
            text.text = "Sur la table avec X = "+ tiltX.ToString()+" Y = "+ tiltY.ToString() + " Z = "+ tiltZ.ToString();
            image.SetActive(true);
        }
        else
        {
            // T�l�phone inclin�
            text.text = "inclin� avec X = " + tiltX.ToString() + " Y = " + tiltY.ToString() + " Z = " + tiltZ.ToString();
            image.SetActive(false);
        }
    }
}
