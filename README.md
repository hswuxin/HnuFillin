淮师疫情填报
===
环境配置
---
* .NET Framework 4.7.2
* Selenium 3.141
* ChromeDriver 89.0.4389.2300

使用手册
-----
安装Chrome浏览器89版 [下载链接](https://www.chromedownloads.net/chrome64win-stable/1137.html)<br><br>
以管理员身份运行Debug文件夹下的WindowsFormsApp1.exe<br><br>
`服务器`：填写学号与密码后无需点击保存，每天8：00 (UTC+08:00)准时进行签到<br><br>
`个人主机`：第一次管理员身份运行后填写学号与密码点击保存，会在C盘生成txt文件，之后运行无需填写信息自动获取身份信息，将运行程序设置为开机启动项<br><br>
***不推荐使用个人主机的方法，如需使用请在load事件加载submit()方法***
