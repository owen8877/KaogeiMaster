﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Text;
using UnityEngine;

public class ServerInteraction {
    const string address = "127.0.0.1";
    const int port = 9999;
    static int time = 0;

    public static float[] fetchData(bool mockup) {
        if (mockup)
            return fetchMockupData();
        /*
        System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
        PingOptions options = new PingOptions();

        options.DontFragment = true;
        string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        byte[] buffer = Encoding.ASCII.GetBytes (data);
        int timeout = 10;
        PingReply reply = pingSender.Send("127.0.0.1:9999", timeout, buffer, options);
        if (reply.Status != IPStatus.Success)
            return fetchMockupData();
        */
        try {
            System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
            clientSocket.Connect(address, port);
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] inStream = new byte[100000];
            serverStream.Read(inStream, 0, (int) clientSocket.ReceiveBufferSize);
            string returnData = System.Text.Encoding.ASCII.GetString(inStream);
            string[] numberStrings = returnData.Split();
            float[] results = new float[numberStrings.Length - 1];
            for (int i = 0; i < results.Length - 1; ++i) {
                results[i] = (float) double.Parse(numberStrings[i]);
            }
            return results;
        } catch (Exception e) {
            Debug.Log("Cannot connect");
            return fetchMockupData();
        }
    }

    private static float[] fetchMockupData() {
        time++;
        return new float[] {
            - 6 * Mathf.Sin(time / 13f),
            - 8 * Mathf.Sin(time / 8f),
            - 10 * Mathf.Sin(time / 10f),
            0.5f + 0.5f * Mathf.Sin(time / 17f),
            0.5f + 0.5f * Mathf.Sin(time / 17f),
            0.3f + 0.2f * Mathf.Sin(time / 21f)
        };
    }
}

