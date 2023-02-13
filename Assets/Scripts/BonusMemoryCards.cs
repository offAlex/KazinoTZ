using UnityEngine;

public class BonusMemoryCards : MonoBehaviour {
    [SerializeField] private GameObject cardBack;
    [SerializeField] private BonusSceneController controller;

    private int _id;
    public int id {
        get {return _id;}
    }

    public void SetCard(int id, Sprite image) {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }

    public void OnMouseDown() {
        if (cardBack.activeSelf && controller.count > 0 ) {
            cardBack.SetActive(false);
            controller.CardRevealed(this);
            controller.count--;
        }
    }
}