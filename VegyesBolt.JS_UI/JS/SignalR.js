function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:7207/hub")
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
        log("SignalR Connected.");
    } catch (err) {
        log(err);
        setTimeout(start, 5000);
    }
};
