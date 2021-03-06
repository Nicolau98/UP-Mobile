﻿using AspCore_Email.Services;
using AspCore_Email.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore_Email.Controllers
{
    public class TesteEmailController : Controller
    {
        private readonly IEmailSender _emailSender;
        public TesteEmailController(IEmailSender emailSender, IWebHostEnvironment env)
        {
            _emailSender = emailSender;
        }
        public IActionResult EnviaEmail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnviaEmail(EmailModel email)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TesteEnvioEmail(email.Destino, email.Assunto, email.Mensagem).GetAwaiter();
                    return RedirectToAction("EmailEnviado");
                }
                catch (Exception)
                {
                    return RedirectToAction("EmailFalhou");
                }
            }
            return View(email);
        }

        public IActionResult EnviarFaturas(EmailModel email)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TesteEnvioEmail(email.Destino, email.Assunto, email.Mensagem).GetAwaiter();
                    return RedirectToAction("EmailEnviado");
                }
                catch (Exception)
                {
                    return RedirectToAction("EmailFalhou");
                }
            }
            return View(email);
        }
        public async Task TesteEnvioEmail(string email, string assunto, string mensagem)
        {
            try
            {
                //email destino, assunto do email, mensagem a enviar;
                await _emailSender.SendEmailAsync(email, assunto, mensagem);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult EmailEnviado()
        {
            return View();
        }
        public ActionResult EmailFalhou()
        {
            return View();
        }
    }
}
