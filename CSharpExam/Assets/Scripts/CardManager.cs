using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    [Header("卡牌")]
    public List<GameObject> cards = new List<GameObject>();

    /// <summary>
    /// 場景上的卡牌
    /// </summary>
    private List<GameObject> cardsObject = new List<GameObject>();

    /// <summary>
    /// 花色名稱
    /// </summary>
    private string[] cardType = { "Club", "Diamond", "Heart",  "Spades" };

    private void Awake()
    {
        GetCards();
    }

    private void Start()
    {
        StartCoroutine(ShowCard());
    }
    
    /// <summary>
    /// 取得卡片
    /// </summary>
    private void GetCards()
    {
        if (cards.Count < 52)
        {
            for (int i = 0; i < cardType.Length; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    string index = j.ToString();

                    switch (j)
                    {
                        case 1:
                            index = "A";
                            break;
                        case 11:
                            index = "J";
                            break;
                        case 12:
                            index = "Q";
                            break;
                        case 13:
                            index = "K";
                            break;
                    }
                    string name = "PlayingCards_" + index + cardType[i];
                    GameObject card = Resources.Load<GameObject>(name);
                    cards.Add(card);
                }
            }
        }
    }

    /// <summary>
    /// 顯示卡片
    /// </summary>
    private IEnumerator ShowCard()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Transform temp = Instantiate(cards[i]).transform;
            temp.eulerAngles = new Vector3(0, 180, 0);
            temp.localScale = Vector3.one * 20;
            temp.position = new Vector3((i % 13 - 6f) * 1.5f, 4 - i / 13 * 2f, 0);

            cardsObject.Add(temp.gameObject);

            yield return null;
        }
    }

    /// <summary>
    /// 開始刪除偶數卡片
    /// </summary>
    public void StartDeleteEvenCard()
    {
        StartCoroutine(DeleteEvenCard());
    }

    /// <summary>
    /// 刪除偶數卡片
    /// </summary>
    private IEnumerator DeleteEvenCard()
    {
        for (int i = 0; i < cardsObject.Count; i++)
        {
            if ((i % 13) % 2 == 0) continue;

            Destroy(cardsObject[i]);

            yield return null;
        }
    }
}
