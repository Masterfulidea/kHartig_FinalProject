using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PotionController : MonoBehaviour
{
    public enum PotionType
    {
        Speed,
        Jump,
        Core
    }

    public PotionType potionType;
    public int jumpPotionModAmount = 0;
    public int speedPotionModAmount = 0;

    public AudioClip pickupClip;
    public Text text;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            AudioSource.PlayClipAtPoint(pickupClip, transform.position);

            if (potionType == PotionType.Jump)
            {
                collision.gameObject.GetComponent<PlayerMovement>().hasJumpPotion = true;
                collision.gameObject.GetComponent<PlayerMovement>().jumpPotionModAmount = jumpPotionModAmount;
                text.text = "Find the Core \n Jump Upgrade Obtained";
            }
            else if (potionType == PotionType.Speed)
            {
                collision.gameObject.GetComponent<PlayerMovement>().hasSpeedPotion = true;
                collision.gameObject.GetComponent<PlayerMovement>().speedPotionModAmount = speedPotionModAmount;
                text.text = "Find the Core \n Speed Upgrade Obtained";
            }
            else if (potionType == PotionType.Core)
            {
                text.text = "Objective Secured";
            }


            Destroy(this.gameObject);
        }
    }
}    