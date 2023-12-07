using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    public Camera thirdPerson;
    public Camera firstPerson;
    public Camera sideView;
    public KeyCode keyCode;
    // Start is called before the first frame update
    void Start()
    {
        thirdPerson.enabled = true;
        firstPerson.enabled = false;
        sideView.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchCamsUsingOneKey();
        //SwitchCamsUsingThreeKeys();
    }

    private void SwitchCamsUsingOneKey()//This method only works with 2 options
                                        //With 2, when 1 is disabled the other is enabled.
                                        //With 3, when 1 is disabled, the other 2 would be enabled.
    {
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    thirdPerson.enabled = !thirdPerson.enabled;
        //    sideView.enabled = !sideView.enabled;
        //    firstPerson.enabled = !firstPerson.enabled;
        //}
        if (Input.GetKeyDown(keyCode))
        {
        if (thirdPerson.enabled == true)
            {
                thirdPerson.enabled = false;
                firstPerson.enabled = true;
                sideView.enabled = false;
            }else
                if (firstPerson.enabled == true)
            {
                thirdPerson.enabled = false;
                firstPerson.enabled = false;
                sideView.enabled = true;
            }else
                if (sideView.enabled == true)
            {
                thirdPerson.enabled = true;
                firstPerson.enabled = false;
                sideView.enabled = false;
            }
        }
    }

    private void SwitchCamsUsingThreeKeys() //This function is for changing cam with multiple keys, it's not needed when I can cycle with 1 key
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchToFirstPerson();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            SwichToThirdPerson();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SwitchToSideView();
        }
    }

    void SwitchToFirstPerson()
    {
        firstPerson.enabled = true;
        thirdPerson.enabled = false;
        sideView.enabled = false;
    }

    void SwichToThirdPerson()
    {
        thirdPerson.enabled = true;
        firstPerson.enabled = false;
        sideView.enabled = false;
    }

    void SwitchToSideView()
    {
        sideView.enabled = true;
        firstPerson.enabled = false;
        thirdPerson.enabled = false;
    }
}
