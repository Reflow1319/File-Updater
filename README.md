# File-Updater
A collection of tools designed to be used for keep software up to date.

# Indexer.exe
To utilize this system, you need to have a working file server. Designate one folder in your file server for containing the first version, and updates for your software. Place the Indexer.exe inside this folder. For this runthrough, I will use C:/WebHost/Updates/ as this folder. Now create a folder with a low revision number as the name like "0.0". Place all the folders and files for your first revision in that folder. For every update that you provide for your software, create a new folder with a higher revision number. Place all the files you changed since the last update in this new folder structured in the same way. Then run Indexer.exe.


To give you some visual aid, look at these photos. This is the Updates folder with the base revision in /0.1/, and all updates in the remaining folders.

<img src="http://i.imgur.com/11juJxO.png"/>

As I have no software to give you an example with, I'll use some simple files. Assume my software was an image contained in a folder called Data/Graphics/ called Guy.png and a song called Song.m4a. In my 0.1 folder, it should look like this.

<img src="http://i.imgur.com/GRkXdBh.png"/>

In my other patch files, I have a few changes that I made. I changed the file Song.m4a to a different song under the same name, I changed the file Guy.png to a different image under the same name, and I added a file called Song.mp3. Since I've uploaded a few patches, I need to run my Indexer.exe so that these patches take effect.

<img src="http://i.imgur.com/QV3JrI6.png"/>

The Indexer takes into account all folders and files that are created, and stores all their revisions and path names into their respective files. It is very important that you run the Indexer after uploading any patch so that people who run the Updater will get the updates. It is also very important that you leave the folder where your updates are contained very clean. Otherwise, your clients might download files you didn't intend.

After you run the Indexer, you're all done on the server end.



# Updater.exe
Once you run the Indexer, you can run the Updater. On your first run, however, it'll tell you to modify a file it created called Host.txt found in the same location as the Updater.exe. It's a simple text file that should contain the location of the folder containing all your patch folders, as well as your FileList.dat and FolderList.dat. Remember that this is all over a file host, so you need to make sure you don't put in a local path from your hard drive. Make sure it follows the format of IP:PORT/subfolder/


For example, if I wanted to connect to the file server that was being hosted locally, it would look like this.
<i>http://localhost:80/updates/</i>

Once you change it, save it and run the updater again. Your files should begin to download.
