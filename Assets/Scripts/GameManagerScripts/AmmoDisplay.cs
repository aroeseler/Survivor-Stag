using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    public Transform playerTransform;
    public Text displayText;

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.GetComponent<PlayerShoot>().DisplayAmmo() >= 999f)
        {
            displayText.text = 999f.ToString();
        }
        else
        {
            displayText.text = playerTransform.GetComponent<PlayerShoot>().DisplayAmmo().ToString();
        }
    }
}
