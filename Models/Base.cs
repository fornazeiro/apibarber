using Barber.Api.Models.Token;

namespace BarberApi.Models
{
    public class Base
    {
        public int Id { get; set; }
        public TokenSecurity Token { get; set; }
    }
}
