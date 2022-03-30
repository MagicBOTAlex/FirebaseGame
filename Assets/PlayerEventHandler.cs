using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision is null) return;
        if (!collision.gameObject.CompareTag("DeathBox")) return;

        StartCoroutine(GameManager.Instance.StartPlayerDeathSequence());
    }


}
