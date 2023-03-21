using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour{
    // no card is allowed to be flipped
    bool initialized = false;
    public static bool DO_NOT = false;
    [SerializeField]
    int state;
    [SerializeField]
    int cardValue;
    [SerializeField]
    
     Sprite cardBack;
     Sprite cardFront;

    GameObject gameManager;

    void Start(){
        state = 0;
        gameManager = GameObject.FindGameObjectWithTag("Manager");
    }

    void flipCard(){
        //check if card is showing its back(1) or front(0)
        if (state == 0 && !DO_NOT)
            gameManager.GetComponent<Image>().sprite = cardBack;
        else if (state ==1 && !DO_NOT) 
            gameManager.GetComponent<Image>().sprite = cardFront;
        
    }

    //get or set card value
    public int manageCardValue(){
        get {return cardValue;}
        set {cardValue = value;}
    }

    //get or set state value
    public int manageState(){
        get {return state;}
        set {state = value;}
    }

    //get or set @initialized
    public bool initialize(){
        get {return initialized;}
        set {initialized = value;}
    }

    // initializing all Graphics
    public void setGraphics(){
        cardBack = gameManager.GetComponent<gameManager>().getCardBack();
        cardFront = gameManager.GetComponent<gameManager>().getCardFront(cardValue);

        flipCard();
    }

    public void checkPause(){
        StartCoroutine(checkPause());

        IEnumerator pause(){
            yield return new WaitForSeconds(1);
            if (state == 0)
                GetComponent<Image>().sprite = cardBack;
            else if (state == 1)
                GetComponent<Image>().sprite = cardFront;
            DO_NOT = false;
        }
    }

    

}
