SearchHappens IE Plugin

This plugin intended for getting information from a web page, such as
input fields, texts. IE plugins build on BHO, with details you can follow next link:
http://msdn.microsoft.com/en-us/library/bb250436(v=vs.85).aspx .

# Getting started 

## Requirements

Following items are required for start developing IE Add-on.

1. Microsoft Visual Studio Express 2013 for Desktop(.NetFramework 4+)
http://www.microsoft.com/en-us/download/details.aspx?id=40787

2. IE Explorer (we are using for tests IE10 and IE11, we hope other version are partially compatible (= )

2. Install GIT (http://git-scm.com)

3. Clone project from GitHub

## Install Add-on

To install IE Add-on it must be registered.
We are using command prompt to sign .dll using regasm.exe(recommended register .dll file from realise),
at this stage signing without strong keys.

Now Add-on must appears in Manage add-ons tab of IE.

Next step IE->Setting->Advanced->Enable Enhanced Protected Mode flag to false.

Now Add-on will starts with each new tab.

To delete add-on need unregister .dll with regasm.exe .dll /u , or clean up a regestry manualy.



