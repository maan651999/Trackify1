using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Trackify.Application.DTOs
{
    public class GoogleCaptchaResponse
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("challenge_ts")]
        public string ChallengeTs { get; set; }

        [JsonPropertyName("hostname")]
        public string Hostname { get; set; }
    }
    public class CaptchaService
    {
        private readonly IConfiguration _config;
        public CaptchaService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> VerifyCaptchaAsync(string token)
        {
            //var secretKey = _config["GoogleReCaptcha:SecretKey"];
            var secretKey = "6LdF4rYrAAAAAN_NPgVG12AznG-SfGnF748RC0GN";
            using var client = new HttpClient();
            var response = await client.PostAsync(
                $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={token}",
                null
            );

            var json = await response.Content.ReadAsStringAsync();
            var captchaResult = JsonSerializer.Deserialize<GoogleCaptchaResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return captchaResult != null && captchaResult.Success;
        }
    }
}
