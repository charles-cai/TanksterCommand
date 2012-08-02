(function ($) {
    $.fn.extend({
        chat: function () {
            var chatControl = this;

            // bootstrap to enable socket.io nodejs server.
            $.get('/socket.io', function (data) {
                var backgrounds = ["#4e3d23", "#f07820", "#06467c", "#9e005d", "#64917a"];
             
                var userInfo = {
                    nickname: chatControl.attr('data-username'),
                    backgroundColor: backgrounds[Math.ceil(Math.random() * 5)],
                    userImageId: Math.ceil(Math.random() * 5)
                }

                var msgTemplate = Handlebars.compile($('#chatTemplate').html());

                function message(title, text, msgtype, imageindex, imagebg, fromme) {
                    if (msgtype === undefined) msgtype = "chat";
                    if (imageindex === undefined) imageindex = "1";
                    if (imagebg === undefined) imagebg = "#6d6b40";
                    if (fromme === undefined) fromme = false;

                    this.Title = title;
                    this.Text = text;
                    this.MessageType = msgtype;
                    this.ImageIndex = imageindex;
                    this.ImageBackground = imagebg;

                    if (fromme) this.Me = "message-me";
                };

                function writeMessage(title, text, msgtype, imageindex, imagebg, fromme) {
                    var msg = new message(title, text, msgtype, imageindex, imagebg, fromme);
                    var html = msgTemplate(msg);
                    $(html).appendTo("#messagehost-container");
                    chatControl.tinyscrollbar_update('bottom');
                    return msg;
                };

                // scrollbars setup
                $('<div class="scrollbar"><div class="track"><div class="thumb"><div class="thumb-inner"></div></div></div></div>').appendTo(chatControl);
                $('<div class="viewport"><div id="messagehost-container" class="overview"></div></div>').appendTo(chatControl);
                chatControl.tinyscrollbar();

                var socket = io.connect();

                socket.on('connect', function () {
                    socket.emit('connect', userInfo);
                });

                $('#text').keypress(function (e) {
                    if (e.keyCode == 13) {
                        $("#send").click();
                        return false;
                    }
                });

                $('#send').click(function () {
                    socket.emit('user message', $('#text').val());
                    writeMessage(userInfo.nickname, $('#text').val(), 'chat', userInfo.userImageId, userInfo.backgroundColor, true);
                    $('#text').val('');
                });

                socket.on('user message', function (message) {
                    writeMessage(message.nickname, message.text, message.type, message.userImageId, message.backgroundColor, message.fromme);
                });

                socket.on('announcement', function (text) {
                    writeMessage("Event", text, "event", Math.ceil(Math.random() * 5), null);
                });
            });
        }
    });
})(jQuery);

