using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupManager : MonoBehaviour
{
    public DungControl dungPrefab;
    public CornControl cornPrefab;
    public HomeManager[] homes;
    public BeetleControl beetlePrefab;

    Dictionary<int, HomeManager> homeDictionary;
    Dictionary<int, BeetleControl> beetles;

    private void Awake()
    {
        beetles = new Dictionary<int, BeetleControl>();
    }

    public HomeManager[] SetupPlayground(int playerCount)
    {
        AddDungBalls(playerCount * (10 + Random.Range(-1,4)));
        AddCorns(playerCount * (3 + Random.Range(0, 2)));

        int[] idxOrder = GetRandomeOrder(homes.Length);
        homeDictionary = new Dictionary<int, HomeManager>(playerCount);

        HomeManager[] activeHomes = new HomeManager[playerCount];
        for (int i = 0; i < playerCount; i++)
        {
            int homeIdx = idxOrder[i];
            int playerId = i + 1;
            activeHomes[i] = homes[homeIdx];
            BeetleControl bc = Instantiate<BeetleControl>(beetlePrefab);
            bc.transform.position = homes[homeIdx].transform.position;
            bc.transform.rotation = Quaternion.FromToRotation(Vector3.up, Vector3.zero - bc.transform.position);
            activeHomes[i].SetBeetle(playerId, bc);
            activeHomes[i].Activate();
        }

        return activeHomes;
    }

    public void AddDungBalls(int dungCount)
    {
        for (int i = 0; i < dungCount; i++)
        {

            Vector3 place = Quaternion.AngleAxis(Random.Range(0, 360f), Vector3.forward) * Vector2.up;
            float ratio = Random.Range(0, 1f);
            place *= (5 * (1.1f - ratio));
            float scale = 0.5f + (1f * ratio);
            float mass = 0.05f + (0.2f * ratio);

            DungControl dung = Instantiate<DungControl>(dungPrefab);
            dung.scorePoint = 5 + 10 * ratio;
            dung.transform.localScale *= scale;
            dung.transform.position = place;
            dung.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 365));
            dung.SetMass(mass);
        }
    }

    public void AddCorns(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 place = Quaternion.AngleAxis(Random.Range(0, 360f), Vector3.forward) * Vector2.up;
            float ratio = Random.Range(0, 1f);
            place *= (6 * (1.1f - ratio));
            CornControl corn = Instantiate<CornControl>(cornPrefab);
            corn.transform.position = place;
            corn.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 365));
        }
    }

    public static int[] GetRandomeOrder(int count)
    {
        int[] numbers = new int[count];
        for (int i = 0; i < count; i++)
        {
            numbers[i] = i;
        }
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int nextIdx = Random.Range(i, numbers.Length - 1);
            int temp = numbers[i];
            numbers[i] = numbers[nextIdx];
            numbers[nextIdx] = temp;
        }

        return numbers;
    }
}
