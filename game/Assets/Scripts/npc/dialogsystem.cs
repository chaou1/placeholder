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
    public bool doneSpeaking=true;
    private Queue<string> dialogs;


    private float lol;
 
    // Start is called before the first frame update

    private void Start()
    {
        dialogs = new Queue<string>();
    }
    private void Update()
    {
        if (BasicMovement.devtools == true) {
            lol = 0f;
        }
        if (BasicMovement.devtools == false)
        {
            lol = 1f;
        }

    } 
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

        if (inrange == true && Input.GetKeyDown(KeyCode.F)&& doneSpeaking==true)
        {
            BasicMovement.frozen = true;
            DialogBox.SetActive(true);
            Text();
            StartCoroutine(dialogSpamCooldown());
            dialogText.text = contents;
            if (DialogBox.activeInHierarchy&&doneSpeaking==true) {
                finishDialog();
            }
        }
        
    }
    protected virtual void Text() {
        contents = "if u see dis then its wrong";
        timespoken++;
    }
    IEnumerator dialogSpamCooldown() {
        yield return new WaitForSeconds(lol);
    }
    void finishDialog() {
        BasicMovement.frozen = false;
        DialogBox.SetActive(false);
    }
}
