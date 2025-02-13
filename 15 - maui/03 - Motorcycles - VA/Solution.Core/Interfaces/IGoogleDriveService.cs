namespace Solution.Core.Interfaces;

public interface IGoogleDriveService
{
    Task<ErrorOr<byte[]>> DownloadFileAsync(string fileId);
    Task<ErrorOr<string>> UploadFileAsync(FileResult file);
}
