using EasieR.Application.Commands;
using EasieR.Application.DataTransfer;
using EasieR.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using EasieR.Domain;
using EasieR.Implementation.Validations.UserValidations;
using FluentValidation;
using AutoMapper;
using EasieR.Application.Constants;
using System.Net.Mail;
using System.Linq;

namespace EasieR.Implementation.Commands
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly EasieRContext _easieRContext;
        private readonly CreateUserValidator _validator;
        private readonly IMapper _mapper;

        public CreateUserCommand(EasieRContext easieRContext, CreateUserValidator validator, IMapper mapper)
        {
            _easieRContext = easieRContext;
            _validator = validator;
            _mapper = mapper;

        }
        public int Id => 1;
        public string Name => RolesConstants.CreateUser;

        public void Execute(UserDto userDto)
        {
            try
            {
                _validator.ValidateAndThrow(userDto);
                User user = _mapper.Map<User>(userDto);
                _easieRContext.Users.Add(user);
                _easieRContext.SaveChanges();
       /*         var currentUserId = _easieRContext.Users.FirstOrDefault(x => x.UserName == userDto.UserName).Id;
                MailMessage mailmessage = new MailMessage();
                mailmessage.To.Add(new MailAddress(userDto.Email));
                mailmessage.From = new MailAddress("acaca93@gmail.com");
                mailmessage.Subject = "User SignUp";
                mailmessage.Body = "Hello You're registered! Please click on the following link to confirm account: http://localhost:5000/api/user/verify?id=" + currentUserId;
                mailmessage.Priority = MailPriority.Normal;
                //smtp Client details
                SmtpClient smtpclient = new SmtpClient("smtp.gmail.com", 465);
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = new System.Net.NetworkCredential("acaca93@gmail.com", "62290922");
                smtpclient.Port = 587;
                smtpclient.EnableSsl = true;
                smtpclient.Host = "smtp.gmail.com";
                smtpclient.Send(mailmessage);*/
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
