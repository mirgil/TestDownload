# TestDownload
## .Net Test application for file download using StreamContent

A small test application that simulate downloading a file with an arbitrary size.
When deploying the application, the follwoing urls are available:
```
/Download/<File Size in bytes>/<Internal stream read delay in milliseconds>
```
For example, if I want to test downloading of a 1GB file, without any delay, the following URL should be used:
```
/Download/1073741824
```
In order to simulate a 10 mSec delay when reading from the internal stream, the following URL should be used:
```
/Download/1073741824/10
```

This application uses a dummy stream with arbitrary size and read delay, and use this stream to return am HttpResponseMessage with StreamContent.
```cpp
public class DownloadController : ApiController
{
    public HttpResponseMessage Get(long size, int delay = -1)
    {
        Stream st = new StreamSimulator(size, delay);
        var result = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StreamContent(st)
        };
        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = "file.tmp" };
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        return result;
    }
}
```

In addition to the Download API, this application contains a Test function that returns "Hello" string:
```
/Test
```
