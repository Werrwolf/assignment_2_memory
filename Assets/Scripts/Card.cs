using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{   
    // if true no user actions are allowed
    public static bool GAME_INTERRUPTED = false;

    [SerializeField]
    private int _state; 
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized = false;

    private Sprite _cardBack;
    private Sprite _cardFace;

    private GameObject _gameManager;


    void Start(){
        _state = 1;
        _gameManager = GameObject.FindGameObjectWithTag("Manager");
    }

    // initializing card graphics
    public void setupGraphics(){
        _cardBack = _gameManager.GetComponent<GameManager>().getCardBack();
        _cardFace = _gameManager.GetComponent<GameManager>().getCardFace(_cardValue);
    
        flipCard();
    }

    public void flipCard(){

        if (_state == 0)
            _state = 1;
        else if (_state == 1)
            _state = 0;

        //check if card is showing its back(1) or front(0)
        if (_state == 0 && !GAME_INTERRUPTED)
            GetComponent<Image>().sprite = _cardBack;
        else if  ( _state == 1 && !GAME_INTERRUPTED)
            GetComponent<Image>().sprite = _cardFace;
    }

    //get or set cardValue
    public int cardValue{
        get => _cardValue; 
        set => _cardValue = value; 
    }

   //get or set state value
    public int state{
        get => _state;
        set => _state = value;
    }

    //get or set @initialized
    public bool initialized{
        get {return _initialized;}
        set {_initialized = value;}
    }

    public void falseCheck(){
        StartCoroutine(pause ());
    }

    IEnumerator pause(){
        yield return new WaitForSeconds(1);
        //no match (_state = 0)
        if (_state == 0)
            GetComponent<Image>().sprite = _cardBack;
        // match (_state = 1)
        else if (_state == 1)
            GetComponent<Image>().sprite = _cardFace;
        GAME_INTERRUPTED = false;
    }
}