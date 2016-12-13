![ScreenShot](https://hostr.co/file/970/ceiIRJBaonDT/sboticon.png) sBot
===

[![ScreenShot](https://hostr.co/file/970/ilF6vwgDVrVJ/SBOTTT.png)](https://www.youtube.com/watch?v=tv7Q7u_CF0A)

Credits: Andrew Justin Solesa (https://github.com/Shrooms)

References: http://jahpre.me/

References: http://www.supremenewyork.com/

Disclosure: _ xxxx _ /_;-.__ / _\ _.-;_\ `-._`'`_/'`.-' `\ /` | / /-.( \_._\ \ \`; > |/ / // |// ajs \(\ ``

------------------------------------------------------------------------------------------------------------------------------------------


The issue when running as the standalone.exe was that it would not call out a function in the process of automation maybe due to the HTMLAGILITYPACK.dll not being present?

I was going to fix this issue but I discovered that SUPREME decided to block the native .NET WEBBROWSER control from the /checkout link (debugged and when I navigate to checkout the page will not load); therefore, I am going to fix this issue first than the standalone .exe issue (worked then 100% if you run via VISUAL STUDIO).

So as of this moment, the functions in the program work 100% (automation of to selection, checkout and paying) but the method of using the native .net control is BLOCKED as far as I know (when navigating to checkout link it does not load).

Thanks for your patience.

After reviewing what is the problem, it has been determined 100% that upon navigating to checkout link, if you are using a .net WEBBROWSER control you will be BLOCKED.

I may or may not fix this as I never really intended to carry this project this far out into development (originally bypassed encryption name, etc).

Thanks.
