using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    public Transform playerTransform;
    public Text displayText;

    // Update is called once per frame
    void Update()
    {
        displayText.text = playerTransform.GetComponent<PlayerShoot>().displayAmmo().ToString();
    }
}
