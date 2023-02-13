
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class SceneController : MonoBehaviour {
	private const int GridRows = 5;
	private const int GridCols = 4;
	private const float OffsetX = 0.7f;
	private const float OffsetY = 0.7f;

	[SerializeField] private MemoryCard originalCard;
	[SerializeField] private Sprite[] images;

	private MemoryCard _firstRevealed;
	private MemoryCard _secondRevealed;
	public static int _score = 0;

	public GameObject winButton;

	public bool canReveal {
		get {return _secondRevealed == null;}
	}

	// Use this for initialization
	private void Start() {
		Vector3 startPos = originalCard.transform.position;

		// create shuffled list of cards
		int[] numbers = {0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 6, 6};
		numbers = ShuffleArray(numbers);

		// place cards in a grid
		for (int i = 0; i < GridCols; i++) {
			for (int j = 0; j < GridRows; j++) {
				MemoryCard card;

				// use the original for the first grid space
				if (i == 0 && j == 0) {
					card = originalCard;
				} else {
					card = Instantiate(originalCard) as MemoryCard;
				}

				// next card in the list for each grid space
				int index = j * GridCols + i;
				int id = numbers[index];
				card.SetCard(id, images[id]);

				float posX = (OffsetX * i) + startPos.x;
				float posY = -(OffsetY * j) + startPos.y;
				card.transform.position = new Vector3(posX, posY, startPos.z);
			}
		}
	}

	// Knuth shuffle algorithm
	private int[] ShuffleArray(int[] numbers)
	{
		int[] newArray = numbers.Clone() as int[];
		for (int i = 0; i < newArray.Length; i++)
		{
			int tmp = newArray[i];
			int r = Random.Range(i, newArray.Length);
			newArray[i] = newArray[r];
			newArray[r] = tmp;
		}

		return newArray;
	}

	public void CardRevealed(MemoryCard card) {
		if (_firstRevealed == null) {
			_firstRevealed = card;
		} 
		else {
			_secondRevealed = card;
			StartCoroutine(CheckMatch());
		}
		Debug.Log(_score);
		if (_score >= 10)
		{
			Debug.Log("Вы победили!!!");
			winButton.SetActive(true);
		}
	}
	
	private IEnumerator CheckMatch() {

		// increment score if the cards match
		if (_firstRevealed.id == _secondRevealed.id) {
			_score++;
		}

		// otherwise turn them back over after .5s pause
		else {
			yield return new WaitForSeconds(.5f);

			_firstRevealed.Unreveal();
			_secondRevealed.Unreveal();
		}
		
		_firstRevealed = null;
		_secondRevealed = null;
	}
}
