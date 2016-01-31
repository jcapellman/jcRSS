# jcRSS
Originally this was created with the intention of replacing the now non-existent Google Reader. This would have entailed an MVC, WebAPI and Windows Phone component.  Over time it became clear that a WebAPI/SQL Server backend wasn't necessary as the device itself could sync and maintain the feed.  This would allow me to focus on the device platform itself and without worrying about scalability since I would have been hosting the WebAPI/SQL Server on Azure and may have switched to an Ad based model.

Now fast forward to 2016 - having grown annoyed with services like Feedly, while a decent replacement for Google Reader I've come back to this project with a fresh code base targeting Windows 10 (Mobile and Desktop).

Initial release functionality:
-Ability to manage subscriptions (Add/Delete)
-Roaming support across Windows 10 devices (If you mark the feed as viewed on one device it will mark the others)
-Ability to Share links and open feeds in Edge (or whatever the default browser is)
