import { createServer } from "http";
import { Server, Socket } from "socket.io";

const httpServer = createServer();
const io = new Server(httpServer);
httpServer.listen(3000);

io.on('connection', (socket : Socket) => {
    console.log("connection");
    // socket.send();
});
