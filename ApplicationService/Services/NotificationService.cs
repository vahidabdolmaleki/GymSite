using ApplicationService.DTOs;
using ApplicationService.Interfaces;
using Azure.Core;
using Core;
using DAL.UnitOfWork;
using Entities;
using FirebaseAdmin.Messaging;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Configuration;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace ApplicationService.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _uow;

        public FirebaseNotificationService firebaseNotificationService { get; }

        public NotificationService(IConfiguration config, IUnitOfWork uow)
        {
           
            _uow = uow;
            firebaseNotificationService = new FirebaseNotificationService(config, _uow);

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
                    IsSuccess= false,
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
            try
            {
                var result = await firebaseNotificationService.SendPushAsync(deviceToken, title, body);
                if (result)
                    return result;
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }

}
