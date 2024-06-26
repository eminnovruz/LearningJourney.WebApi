﻿using Application.Models.Configurations;
using Application.Services;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services;

public class BlobService : IBlobService
{
    private readonly BlobStorageConfiguration _config;

    public BlobService(IOptions<BlobStorageConfiguration> options)
    {
        _config = options.Value;
    }

    public bool DeleteFile(string fileName)
    {
        var service = new BlobServiceClient(_config.ConnectionString);
        var container = service.GetBlobContainerClient(_config.ContainerName);
        var blob = container.GetBlobClient(fileName);

        return blob.DeleteIfExists().Value;
    }

    public async Task<bool> DeleteFileAsync(string fileName)
    {
        var serviceClient = new BlobServiceClient(_config.ConnectionString);
        var containerClient = serviceClient.GetBlobContainerClient(_config.ContainerName);
        var blobClient = containerClient.GetBlobClient(fileName);

        var response = await blobClient.DeleteIfExistsAsync();
        return response.Value;
    }

    public string GetSignedUrl(string fileName)
    {
        var serviceClient = new BlobServiceClient(_config.ConnectionString);
        var contaionerClient = serviceClient.GetBlobContainerClient(_config.ContainerName);
        var blobClient = contaionerClient.GetBlobClient(fileName);

        var signedUrl = blobClient.GenerateSasUri(BlobSasPermissions.Read, DateTime.Now.AddHours(2)).AbsoluteUri;

        return signedUrl;
    }

    public Task<string> GetSignedUrlAsync(string fileName) // mmmmaybe later..........
    {
        throw new NotImplementedException();
    }

    public bool UploadFile(Stream stream, string fileName, string contentType)
    {
        var serviceClient = new BlobServiceClient(_config.ConnectionString);
        var contaionerClient = serviceClient.GetBlobContainerClient(_config.ContainerName);
        var blobClient = contaionerClient.GetBlobClient(fileName);

        blobClient.Upload(stream);
        return true;
    }

    public async Task<bool> UploadFileAsync(Stream stream, string fileName, string contentType)
    {
        var serviceClient = new BlobServiceClient(_config.ConnectionString);
        var contaionerClient = serviceClient.GetBlobContainerClient(_config.ContainerName);
        var blobClient = contaionerClient.GetBlobClient(fileName);

        await blobClient.UploadAsync(stream);
        return true;
    }
}
