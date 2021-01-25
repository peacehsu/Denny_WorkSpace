from __future__ import unicode_literals
import os
from flask import Flask,request,abort
from linebot import LineBotApi,WebhookHandler
from linebot.exception import InvalidSignatureError

app = Flask(__name__)

# LINE 聊天機器人的基本資料
line_bot_api = LineBotApi('hTLWnAJ7d7uwEGOMpBZbzY8xn9KPI9AZbs9F+6e6V72yEHPBE7vfZCjSAHS3A/8dUx1vjE7pRI0hoTPzg8BhAK9Wzht4YvjnTvQ4HXZEVZ3CZKjPmSo2fFTV4EtfSs6AekwYRBDL14PvN72Ci/e13AdB04t89/1O/w1cDnyilFU=')
handler = WebhookHandler('7433e8deb68f53ed73617e325aa92dd0')

# 接收 LINE 的資訊
@app.route("/callback", methods=['POST'])

def callback():
    signature = request.headers['X-Line-Signature']

    body = request.get_data(as_text=True)
    app.logger.info("Request body: " + body)

    try:
        handler.handle(body, signature)
    except InvalidSignatureError:
        abort(400)

    return 'OK'

if __name__ == "__main__":
    app.run()