using Restaurant.BusinessLogic.Services.Implementations;
using Restaurant.Data.Entities;
using Restaurant.Data.Repository.Interface;
using Restaurant.DTO;
using Restaurant.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BusinessLogic.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<GenericResponse<string>> VerifyAsync(string reference, Guid Id);
        Task<GenericResponse<string>> PaymentAsync(PaymentRequestDTO paymentRequestDTO);
    }
}
