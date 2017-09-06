# DictionaryRange
 Show English Dictionary Words between provided range.
 
 Task description:
 Create a Web API project.
 
The following file contains an English dictionary list: http://www.math.sjsu.edu/~foster/dictionary.txt .
Download this file and add it to your project.
Create a controller "WordController" that will allow range queries against this dictionary list file.
 
Create an HTML web page with Javascript (you may use JQuery or anything else)
Call the WordController from the web page.
 
If you display your web page with manually typed-in query params:
http://myserver/DefaultPage?from=apple&to=zebra
it should make an AJAX call to your Web API: 
http://myserver/api/Word?from=apple&to=zebra
 
The result should display on your web page as a tabular list of words, visually grouped by the first letter, between the "from" and "to" parameter words.
(Your WordController API should only return the list of words between the "from" and "to" query values)
