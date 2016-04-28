using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour
{
    private const string typeName = "UniqueGameName";
    private const string gameName = "RoomName";

    private bool isRefreshingHostList = false;
    private HostData[] hostList;

    public GameObject player1Prefab;
    public GameObject player2Prefab;

    void OnGUI()
    {
        if (!Network.isClient && !Network.isServer)
        {
            if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
                StartServer();

            if (GUI.Button(new Rect(100, 250, 250, 100), "Refresh Hosts"))
                RefreshHostList();

            if (hostList != null)
            {
                for (int i = 0; i < hostList.Length; i++)
                {
                    if (GUI.Button(new Rect(400, 100 + (110 * i), 300, 100), hostList[i].gameName))
                        JoinServer(hostList[i]);
                }
            }
        }
    }

    private void StartServer()
    {
        Network.InitializeServer(5, 25000, !Network.HavePublicAddress());
        MasterServer.ipAddress = "127.0.0.1";
        MasterServer.port = 23466;
        Network.natFacilitatorIP = "127.0.0.1";
        Network.natFacilitatorPort = 50005;
        MasterServer.RegisterHost(typeName, gameName);
    }

    void OnServerInitialized()
    {
        SpawnPlayer1();
    }


    void Update()
    {
        if (isRefreshingHostList && MasterServer.PollHostList().Length > 0)
        {
            isRefreshingHostList = false;
            hostList = MasterServer.PollHostList();
        }
    }

    private void RefreshHostList()
    {
        if (!isRefreshingHostList)
        {
            isRefreshingHostList = true;
            MasterServer.RequestHostList(typeName);
        }
    }


    private void JoinServer(HostData hostData)
    {
        Network.Connect(hostData);
    }

    void OnConnectedToServer()
    {
        SpawnPlayer2();
    }


    private void SpawnPlayer1()
    {
        Network.Instantiate(player1Prefab, new Vector3(-7,0,0), Quaternion.identity, 0);
    }

    private void SpawnPlayer2()
    {
        Network.Instantiate(player2Prefab, new Vector3(7, 0, 0), Quaternion.identity, 0);
    }
}
