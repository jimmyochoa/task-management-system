namespace backend.DTOs
{
    public class AuthResponseDTO
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public string Token { get; set; }
    }
}
