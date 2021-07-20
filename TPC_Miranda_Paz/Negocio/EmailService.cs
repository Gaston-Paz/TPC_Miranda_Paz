using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("pruebasProgramm@gmail.com", "gastonmaxi");
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        public void armarCorreo(Turno turno, int turnoNumero)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@laclinica.com");
            email.To.Add(new MailAddress(turno.Paciente.Email));
            email.Subject = "Detalle de turno";
            email.IsBodyHtml = true;
            email.Body = "<h1>¡Turno registrado con éxito!</h1> " +
                         "<br>" +
                         "<p>Atención Sr/a " + turno.Paciente.Apellido + ", " + turno.Paciente.Nombre + ": <br>" +
                         "Le informamos que su turno #" + turnoNumero + " ha sido agendado con éxito. <br>" +
                         "Fecha: " + turno.Fecha.ToShortDateString() + ". <br>" +
                         "Hora: " + turno.Horario + ". <br>" +
                         "Especialidad: " + turno.Especialidad.Nombre + ". <br>" +
                         "Profesional: " + turno.Medico.Apellido + ", " + turno.Medico.Nombre + ". <br>" +
                         "Recuerde concurrir al mismo con documento de identidad y credencial de prepaga.</p>";
            

        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
