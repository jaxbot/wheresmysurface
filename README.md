wheres my surface
===============

Simple GPS tracking for Windows 8 devices. I use it for anti-theft of my Surface Pro 2

This project is not ready to use as it is, as it needs a remote endpoint to connect to. I left mine in as an example.

On the server, it can be as simple as this:

`file_put_contents("surface.txt", date("m-d-y h:i:s a").":: " . $_GET['lat'] . "," . $_GET['long'], FILE_APPEND);`

Or more complicated.
