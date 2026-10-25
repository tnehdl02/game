using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int money = 0;
    public bool hasSickle = false;
    public int weedPrice = 5;
    public int sicklePrice = 100;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // 잡초 뽑았을 때
    public void CollectWeed()
    {
        money += weedPrice;
        Debug.Log($"[게임] 잡초 획득! 현재 골드: {money}원");
    }

    // 낫 구매 시도
    public bool TryBuySickle()
    {
        if (hasSickle)
        {
            Debug.Log("[상점] 이미 낫을 소유하고 있습니다.");
            return false;
        }

        if (money >= sicklePrice)
        {
            money -= sicklePrice;
            hasSickle = true;
            Debug.Log($"[상점] 낫 구매 성공! 잔액: {money}원");
            return true;
        }
        else
        {
            Debug.Log($"[상점] 골드가 부족합니다! (필요: {sicklePrice}원 / 현재: {money}원)");
            return false;
        }
    }
}
