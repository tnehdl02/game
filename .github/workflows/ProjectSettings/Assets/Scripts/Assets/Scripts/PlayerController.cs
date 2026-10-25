using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float harvestTimer = 0f;

    void Update()
    {
        // 1. 단순 이동 로직 (화면 터치/클릭 지점으로 이동 또는 간단한 플레이어 이동)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(moveX, 0, moveZ).normalized;
        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);

        // 2. 잡초 채집 로직 (스페이스바 또는 자동 채집 범위 내 진입 시)
        // 낫이 있으면 채집 속도가 0.3초, 없으면 1초 소요
        float harvestDelay = GameManager.Instance.hasSickle ? 0.3f : 1.0f;
        
        harvestTimer += Time.deltaTime;
        if (harvestTimer >= harvestDelay)
        {
            // 상자/잡초에 닿았을 때 자동으로 뽑는 동작 트리거 (스페이스바 예시)
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                HarvestWeed();
                harvestTimer = 0f;
            }
        }

        // 3. 낫 구매 테스트 (B키를 누르면 구매 시도)
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameManager.Instance.TryBuySickle();
        }
    }

    void HarvestWeed()
    {
        GameManager.Instance.CollectWeed();
    }
}
