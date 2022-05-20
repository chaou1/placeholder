using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class dialogsystem : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public GameObject DialogBox;
    public TMP_Text dialogText;
    public string contents = "if u see dis then its wrong";
    private bool inrange= false;
    public int timespoken=0;
    // Start is called before the first frame update

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inrange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inrange = false;

        }
    }
    public virtual void dialog() {

        if (inrange == true && Input.GetKeyDown(KeyCode.F))
        {

            DialogBox.SetActive(true);
            Text();
            dialogText.text = contents;
            
        }
    }
    protected virtual void Text() {
        contents = "if u see dis then its wrong";
        timespoken++;
    }
}
