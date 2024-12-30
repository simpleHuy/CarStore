const express = require('express');
const http = require('http');
const { Server } = require('socket.io');

const app = express();
const server = http.createServer(app);
const io = new Server(server);

const PORT = 3000;

app.get('/api/message', (req, res) => {
  res.json({ message: 'Hello from Express + Socket.IO server!' });
});

io.on('connection', (socket) => {
    console.log('A client connected:', socket.id);

    socket.on('joinAuction', (auctionId) => {
        socket.join(`auction_${auctionId}`);
        console.log(`Client ${socket.id} joined auction ${auctionId}`);
    });

    socket.on('leaveAuction', (auctionId) => {
        socket.leave(`auction_${auctionId}`);
        console.log(`Client ${socket.id} left auction ${auctionId}`);
    });

    socket.on('placeBid', (data) => {
        console.log('Received bid data:', data);
        const { auctionId, bid } = data;
        io.to(`auction_${auctionId}`).emit('bidPlaced', { auctionId, bid });
    });

    socket.on('disconnect', () => {
        console.log('Client disconnected:', socket.id);
    });
});

server.listen(PORT, () => {
  console.log(`Server is running on http://localhost:${PORT}`);
});
