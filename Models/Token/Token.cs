using BarberApi.Entidades;
using System;
using System.Collections.Generic;

namespace Barber.Api.Models.Token
{
    public class TokenSecurity
    {
        public string Token { get; set; } 
        public DateTime Criacao { get; set; }
        public DateTime Expira { get; set; }
    }
}
