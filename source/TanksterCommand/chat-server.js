var express = require('express')
  , sio = require('socket.io')
  , redis = require('socket.io/node_modules/redis');

var app = express.createServer();
app.listen(process.env.PORT || 80);

var io = sio.listen(app);

io.configure(function () {
    io.set('transports', [
                'xhr-polling',
                'jsonp-polling',
                'htmlfile'
            ]);
    io.set("polling duration", 10);
});

var sub = redis.createClient(9474, 'pike.redistogo.com');
sub.auth("ef3646ef1bbdf1ab5df2b4b18664dc16");

var pub = redis.createClient(9474, 'pike.redistogo.com');
pub.auth("ef3646ef1bbdf1ab5df2b4b18664dc16");

var store = redis.createClient(9474, 'pike.redistogo.com');
store.auth("ef3646ef1bbdf1ab5df2b4b18664dc16");

var RedisStore = require('socket.io/lib/stores/redis');
io.set('store', new RedisStore({ redisPub: pub, redisSub: sub, redisClient: store }));
io.set('log level', 1);

io.on('connection', function (socket) {
    socket.on('connect', function (userInfo) {
        socket.userInfo = userInfo;
        socket.broadcast.emit('announcement', userInfo.nickname + ' connected.');
    });

    socket.on('user message', function (text) {
        var message = { nickname: socket.userInfo.nickname,
            text: text,
            type: 'chat',
            userImageId: socket.userInfo.userImageId,
            backgroundColor: socket.userInfo.backgroundColor,
            fromme: true
        };

        socket.broadcast.emit('user message', message);
    });

    socket.on('disconnect', function () {
        socket.broadcast.emit('announcement', socket.userInfo.nickname + ' disconnected.');
    });
});