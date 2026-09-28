namespace DTOs
{
    public enum RolUsuario
    {
        Administrador,
        Usuario
    }

    public class LoginResponseDTO
    {
        public string Username { get; set; } = string.Empty;
        public RolUsuario Rol { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}