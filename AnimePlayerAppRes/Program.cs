using System.Net;

Console.WriteLine("AnimePlayerAppRes - innstaller/updater");
try
{
    WebClient WebClient = new WebClient();
    DirectoryInfo tempDirectoryInfo = Directory.CreateTempSubdirectory();
    string LinkToRepo = @"https://github.com/ProGraMajster/AnimePlayerAppRes/archive/refs/heads/master.zip";
    WebClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
    WebClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
    if(File.Exists(tempDirectoryInfo.FullName + "\\AnimePlayerAppRes.zip"))
    {
        File.Delete(tempDirectoryInfo.FullName + "\\AnimePlayerAppRes.zip");
    }
    WebClient.DownloadFile(LinkToRepo, tempDirectoryInfo.FullName + "\\AnimePlayerAppRes.zip");
}
catch(Exception ex)
{
    Console.WriteLine(ex.ToString());
}

void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
{
    Console.WriteLine(e.ProgressPercentage.ToString()+ "% | "+e.BytesReceived+"/"+e.TotalBytesToReceive);
}

void WebClient_DownloadFileCompleted(object? sender, System.ComponentModel.AsyncCompletedEventArgs e)
{
    if(e.Error != null)
    {
        Console.WriteLine(e.Error.ToString());
    }
    Console.WriteLine("End!");
}

return;