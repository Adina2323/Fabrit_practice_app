using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Mappings.DTOs;
using MimeKit;

namespace BusinessLogicLayer.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(InviteMailDTO inviteMailDTO);
        MimeMessage CreateEmailMessage(InviteMailDTO inviteMailDTO);

    }
}
