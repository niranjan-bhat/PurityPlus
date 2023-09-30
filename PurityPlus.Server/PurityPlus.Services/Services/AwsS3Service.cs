using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.EntityFrameworkCore;
using PurityPlus.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace PurityPlus.Services.Services
{
    public class AwsS3Service : IAwsS3Service
    {
        private readonly IAmazonS3 _awsS3Client;
        const string bucketName = "purity-plus";
        const string productFolder = "images/product/";
        const string awsUrl = "https://purity-plus.s3.ap-south-1.amazonaws.com/";
        public AwsS3Service(IAmazonS3 awsS3Client)
        {
            this._awsS3Client = awsS3Client;
        }
        public async Task<string> UploadProductImage(string imgUrl)
        {
            if (await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(_awsS3Client, bucketName))
            {
                var objectKey = Guid.NewGuid().ToString();
                var fileExtension = Path.GetExtension(imgUrl);

                var filePath = Path.Combine(productFolder, objectKey + fileExtension);

                using (var fileTransferUtility = new TransferUtility(_awsS3Client))
                {
                    await fileTransferUtility.UploadAsync(imgUrl, bucketName, filePath);
                }


                return awsUrl + filePath;
            }
            throw new Exception($"Error in AWS S3, bucket is not found. BucketName: {bucketName}");

        }
    }
}
