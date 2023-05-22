using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishLine : MonoBehaviour
{

    public GameObject Controller;
    public GameObject FinishMenu;
    public GameObject TimerCountMen;

    public TextMeshProUGUI CountDownText;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //---------------------------------------------------------------------------

            // Parking is finished totally
            FinishMenu.SetActive(true);

            // Stop timer menu
            TimerCountMen.SetActive(false);

            CountDownText.gameObject.SetActive(false);

            /// Stop car controller
            Controller.SetActive(false);

            //---------------------------------------------------------------------------
        }
    }

}