function setupSignalR() {
    //Dat S was missing and I debugged it for a long time :(
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http"+"s"+"://localhost:7207/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("Changed", (user, message) => {
        window.location.reload();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
