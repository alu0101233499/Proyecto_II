using UnityEngine;
using System.Collections;
using TMPro;

public class Geolocation : MonoBehaviour
{
    private string latitude;
    private string longitude;
    private TMP_Text text;

    IEnumerator Start()
    {
        text = GetComponent<TMP_Text>();

        // latitude = "28.4378";
        // longitude = "-16.2945";

        if (!Input.location.isEnabledByUser)
        {
            text.text = "Latitud: " + latitude + "\nLongitud: " + longitude;
            yield break;
        }

        Input.location.Start();

        int maxWait = 20;

        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
            yield break;

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            longitude = Input.location.lastData.longitude.ToString();
            latitude = Input.location.lastData.latitude.ToString();
        }

        Input.location.Stop();

        text.text = "Latitud: " + latitude + "\nLongitud: " + longitude;
    }
}
