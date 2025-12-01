using ApplicationService.DTOs;
using ApplicationService.Interfaces;
using Core;
using DAL.UnitOfWork;
using Entities;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.Extensions.Configuration;

public class FirebaseNotificationService : INotificationService
{
    private readonly FirebaseMessaging _messaging;
    private readonly IUnitOfWork _uow;


    public FirebaseNotificationService(IConfiguration config, IUnitOfWork uow)
    {
        var path = config["Firebase:ServiceAccountPath"];

        if (FirebaseApp.DefaultInstance == null)
        {
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(path)
            });
        }
        _uow = uow;

        _messaging = FirebaseMessaging.DefaultInstance;
    }

    public async Task<ServiceResult<bool>> SendAsync(NotificationCreateDto dto)
    {
        try
        {
            var result = new ServiceResult<bool>();

            var notification = new Entities.Notification
            {
                PersonId = dto.PersonId,
                Title = dto.Title,
                Message = dto.Message,
                Type = dto.Type,
                Metadata = dto.MetaData
            };

            await _uow.NotificationRepository.SaveAsync(notification);
            await _uow.CommitAsync();

            result.IsSuccess = true;
            result.Message = ExceptionMessage.SendNoficationSuccessFully;
            result.Data = true;

            return result;
        }
        catch (Exception)
        {
            return new ServiceResult<bool>
            {
                IsSuccess = false,
                Message = ExceptionMessage.SendNoficationFeild
            };
        }
    }

    public async Task<ServiceResults<NotificationDto>> GetForUserAsync(int personId)
    {
        var list = await _uow.NotificationRepository.GetForUserAsync(personId);

        var dto = list.Select(n => new NotificationDto
        {
            Id = n.Id,
            Title = n.Title,
            Message = n.Message,
            SentAt = DateTime.Now,
            IsRead = n.IsRead,
            MetaData = n.Metadata
        }).ToList();

        return new ServiceResults<NotificationDto>
        {
            Data = dto,
            IsSuccess = true,
            Message = ExceptionMessage.GetNotificationListSuccessfully
        };
    }

    public async Task<ServiceResult<bool>> MarkAsReadAsync(int id)
    {
        try
        {
            await _uow.NotificationRepository.MarkAsReadAsync(id);
            return new ServiceResult<bool>
            {
                Data = true,
                IsSuccess = true,
                Message = ExceptionMessage.NotficationReadSuccessfull
            };
        }
        catch (Exception)
        {
            return new ServiceResult<bool>
            {
                IsSuccess = false,
                Data = false,
                Message = ExceptionMessage.RegisterReadForNotficationFeild
            };
        }
    }

    public async Task<ServiceResult<int>> GetUnreadCountAsync(int personId)
    {
        try
        {
            var count = await _uow.NotificationRepository.GetUnreadCountAsync(personId);
            return new ServiceResult<int>
            {
                Data = count,
                IsSuccess = true,
                Message = ExceptionMessage.GetCountNotificationSuccessfully
            };
        }
        catch (Exception)
        {
            return new ServiceResult<int>
            {
                IsSuccess = false,
                Data = -1,
                Message = ExceptionMessage.GetCountNoficationFeild
            };
        }
    }
    public async Task<bool> SendPushAsync(string deviceToken, string title, string body)
    {
        var message = new Message
        {
            Token = deviceToken,
            Notification = new FirebaseAdmin.Messaging.Notification
            {
                Title = title,
                Body = body
            },
            Data = new Dictionary<string, string>
            {
                { "click_action", "FLUTTER_NOTIFICATION_CLICK" },
            }
        };

        try
        {
            var result = await _messaging.SendAsync(message);
            return !string.IsNullOrEmpty(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("FCM Error: " + ex.Message);
            return false;
        }
    }
}
