from __future__ import unicode_literals
import os
from flask import Flask,request,abort
from linebot import LineBotApi,WebhookHandler
from linebot.exceptions import InvalidSignatureError
from linebot.models import MessageEvent, TextMessage, TextSendMessage,ImageSendMessage
import configparser
import urllib
import re
import random

app = Flask(__name__)

# LINE 聊天機器人的基本資料
config = configparser.ConfigParser()
config.read('config.ini')

line_bot_api = LineBotApi(config.get('line-bot', 'channel_access_token'))
handler = WebhookHandler(config.get('line-bot', 'channel_secret'))

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

# 學你說話
@handler.add(MessageEvent, message=TextMessage)
def img_search(event):
    
    if event.source.user_id != "Udeadbeefdeadbeefdeadbeefdeadbeef":
        try:
            url = f"https://www.google.com/search?{urllib.parse.urlencode({'tbm': 'isch', 'q': event.message.text})}/"
            headers = {'User-Agent':'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/76.0.3809.132 Safari/537.36'}
            
            req = urllib.request.Request(url, headers = headers)
            conn = urllib.request.urlopen(req)
            
            print('fetch page finish')
            
            pattern = 'img class="rg_i Q4LuWd" data-src="\S*"'
            img_list = []
            con = 0
            for match in re.finditer(pattern,str(conn.read())):
                con +=1
                if con > 3 :
                    break
                img_list.append(match.group()[34:-3])
                
            random_img_url = img_list[random.randint(0,len(img_list)+1)]
            print('fetch img url finish')
            print(random_img_url)
            line_bot_api.reply_message(
                event.reply_token,
                ImageSendMessage(
                        original_content_url = random_img_url,
                        preview_image_url = random_img_url
                        )
            )
        except Exception as e:
            error_class = e.__class__.__name__ #取得錯誤類型
            detail = e.args[0] #取得詳細內容
            cl, exc, tb = sys.exc_info() #取得Call Stack
            lastCallStack = traceback.extract_tb(tb)[-1] #取得Call Stack的最後一筆資料
            fileName = lastCallStack[0] #取得發生的檔案名稱
            lineNum = lastCallStack[1] #取得發生的行號
            funcName = lastCallStack[2] #取得發生的函數名稱
            errMsg = "File \"{}\", line {}, in {}: [{}] {}".format(fileName, lineNum, funcName, error_class, detail)
            line_bot_api.reply_message(
                event.reply_token,
                TextSendMessage(text=errMsg)
            )
if __name__ == "__main__":
    app.run()