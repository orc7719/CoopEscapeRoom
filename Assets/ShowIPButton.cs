using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using TMPro;

public class ShowIPButton : MonoBehaviour
{
    bool mouseHover = false;
    [SerializeField] TMP_Text ipText;
    string startingText;

    private void Start()
    {
        startingText = ipText.text;
    }

    public static string LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = "0.0.0.0";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }

        return localIP;
    }

    public static string PublicIPAddress()
    {
        string externalip = new WebClient().DownloadString("http://checkip.dyndns.org");
        string[] a = externalip.Split(':');
        string a2 = a[1].Substring(1);
        string[] a3 = a2.Split('<');
        string a4 = a3[0];

        return a4;
    }

    public void UpdateMouseHover(bool newStatus)
    {
        mouseHover = newStatus;
    }

    public void UpdateMouseDown(bool newStatus)
    {
        ipText.text = newStatus ? PublicIPAddress() : startingText;
    }
}
