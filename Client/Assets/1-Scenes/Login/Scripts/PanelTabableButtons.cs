using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PanelTabableButtons : MonoBehaviour {


    EventSystem system;
    // Use this for initialization
    void Start () {
        system = EventSystem.current;
    }

    // Update is called once per frame
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();

            if (next != null)
            {

                InputField inputfield = next.GetComponent<InputField>();

                //if it's an input field, also set the text caret
                if (inputfield != null) inputfield.OnPointerClick(new PointerEventData(system));  

                system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
            }
            //else Debug.Log("next nagivation element not found");

        }
    }

    public void Login()
    {
        SceneManager.LoadScene(1);
    }
}
