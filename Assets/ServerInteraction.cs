using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class ServerInteraction {
    const string address = "127.0.0.1";
    const int port = 9999;
    static int time = 0;

    public static float[] fetchData(bool mockup) {
        if (mockup)
            return fetchMockupData();

        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        clientSocket.Connect(address, port);
        NetworkStream serverStream = clientSocket.GetStream();
        byte[] inStream = new byte[100000];
        serverStream.Read(inStream, 0, (int) clientSocket.ReceiveBufferSize);
        string returnData = System.Text.Encoding.ASCII.GetString(inStream);

        //Debug.Log(returnData);

        string[] numberStrings = returnData.Split();
        float[] results = new float[numberStrings.Length - 1];
        for (int i = 0; i < results.Length - 1; ++i) {
            results[i] = (float) double.Parse(numberStrings[i]);
        }
        return results;
    }

    private static float[] fetchMockupData() {
        time++;
        return new float[] {
            - 6 * Mathf.Sin(time / 13f),
            - 8 * Mathf.Sin(time / 8f),
            - 10 * Mathf.Sin(time / 10f),
            0.5f + 0.5f * Mathf.Sin(time / 17f),
            0.5f + 0.5f * Mathf.Sin(time / 17f),
            0
        };
    }
}

