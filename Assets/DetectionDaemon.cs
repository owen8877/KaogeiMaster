using System;
using System.Threading;

public class DetectionDaemon {
    int i = 0;
    public DetectionDaemon() {
        var thread = new Thread(new ThreadStart(HelloWorld));
        thread.Start();
    }

    public void HelloWorld() {
        i = 1;
    }
}
