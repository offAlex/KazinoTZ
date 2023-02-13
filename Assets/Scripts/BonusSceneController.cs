using UnityEngine;

public class BonusSceneController : MonoBehaviour {
	private const int GridRows = 3;
	private const int GridCols = 2;
	private const float OffsetX = 1.3f;
	private const float OffsetY = 1.3f;

	[SerializeField] private BonusMemoryCards originalCard;
	[SerializeField] private Sprite[] images;

	private BonusMemoryCards _firstRevealed;
	private BonusMemoryCards _secondRevealed;

	public GameObject winButton;

	public int count = 3;

	// Use this for initialization
	private void Start() {
		Vector3 startPos = originalCard.transform.position;

		// create shuffled list of cards
		int[] numbers = {0, 1, 1, 1, 1, 1};
		numbers = ShuffleArray(numbers);

		// place cards in a grid
		for (int i = 0; i < GridCols; i++) {
			for (int j = 0; j < GridRows; j++) {
				BonusMemoryCards card;

				// use the original for the first grid space
				if (i == 0 && j == 0) {
					card = originalCard;
				} else {
					card = Instantiate(originalCard) as BonusMemoryCards;
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

	public void CardRevealed(BonusMemoryCards card)
	{
		_firstRevealed = card;
		if (_firstRevealed.id == 0)
		{
			count = 0;
			winButton.SetActive(true);
		}

	}
}
